# http://lolengine.net/wiki/doc/maths/remez
# http://nicolas.limare.net/pro/notes/2014/12/16_math_speed/
# https://seblagarde.wordpress.com/2014/12/01/inverse-trigonometric-functions-gpu-optimization-for-amd-gcn-architecture/

include("remez.jl")
using Gadfly, DataFrames, Formatting

function err_eval(expected::Function, actual::Function, interval::Tuple{Number, Number}, N=1e3)
    a = interval[1]
    b = interval[2]
    d = (b-a)/N
    err_max = 0
    for i=0:N
        x = a + i * d
        err = abs(expected(x) - actual(x))
        err_max = max(err,err_max)
    end
    return Float64(err_max)
end

# output pour inclure le code C#
function print_csharp(s)
    ns = length(s)
    println("")
    for i=1:ns
        println("double s",2i-1," = ",Float64(s[i]),";")
    end

    if ns < 2
        str = "return s1 * x;"
    else
        str = "return x"
        println("double x2 = x * x;")

        for i=0:ns-3
            str = string(str," * (s",2i+1," + x2")
        end
        str = string(str," * (s",2(ns-2)+1," + x2 * s",2(ns-1)+1, repeat(")",ns-1),";")
    end

    println(str)
end

# retourne le DL de sin(x) en 0 à l'ordre n
function sin_taylor(n, output=false)
    nc = Array{BigFloat}(n+1)
    for i=0:n
        r = i%2
        p = (i-r)/2
        if i%2 == 0
            nc[i+1] = BigFloat(0)
        else
            nc[i+1] = BigFloat((-1)^p / factorial(i))
        end
    end

    # print for C#
    if output == true
        println("double x2 = x*x")
        for i=1:length(nc)
            println("double s",i-1," = ",Float64(nc[i]))
        end
    end

    dl(x) = poly_eval(nc, BigFloat(x))
    err(x) = abs(sin(x)-dl(x))
    return (dl,err)
end

# retourne le minmax de sin(x) à l'ordre n sur [-C,C]
function sin_mm_base(n, c, output=false)
    println(string("MinMax approximation of sin(x) over ","[-C,C]"))

    # max |sin(x) - P(x)| = E , over I = [-C,C]
    target(x) = sin(x)
    c = BigFloat(c)
    a = BigFloat(1e-60)

    if n < 1
        mm(x) = 0
    else
        r = n%2
        p = (r==0) ? (n-r)/2-1 : (n-r)/2

        # we search P(x) = xQ(x²) over [0,C]
        # because sin(x) = -sin(x) and sin(x) ≡ x in 0

        # we assume y = x² ∈ J=[0,C²] because x>0 over [0,C]
        # the problem is equivalent to max |sin(√y)/√y - R(y)| * √y = E over J

        f(x) = sin(sqrt(x))/sqrt(x)
        w(x,y) = sqrt(x)
        n = Integer(p)
        d = 0

        (nc, dc, e, x) = ratfn_minimax(f,(a,c*c),n,d,w)

        println("error = ",e)
        #println("  ",ratfn_to_string(nc, dc))
        for i in 1:length(nc)
            println("C",i-1, " : ", nc[i])
        end

        mm(x) = x*poly_eval(nc, BigFloat(x*x))
    end

    # print for C#
    if output == true
        print_csharp(nc)
    end

    err(x) = abs(sin(x)-mm(x))
    return (mm,err)
end

# retourne le minmax de sin(x) à l'ordre n sur [-C,C]
# ici on s'assure que le terme d'ordre 1 est le même que celui du DL
# pour une convergence accélérée au voisinage de 0
function sin_mm(n, c, output=false)
    println(string("MinMax approximation of sin(x) over ","[-C,C]"))

    # max |sin(x) - P(x)| = E , over I = [-C,C]
    target(x) = sin(x)
    c = BigFloat(c)
    a = BigFloat(1e-60)

    if n < 1
        mm(x) = 0
    elseif n < 3
        nc = []
        mm(x) = x
    else
        N = (n%2==0) ? n-1 : n

        # we search P(x) = xQ(x²) = x(1+x²R(x²))  over [0,C]
        # because sin(x) = -sin(x) and sin(x) ≡ x in 0

        # we assume y = x² ∈ J=[0,C²] because x>0 over [0,C]
        # the problem is equivalent to max |[(sin(√y)-√y)/(y√y)] - R(y)| * (y√y) = E over J

        f(x) = (sin(sqrt(x))-sqrt(x))/(x*sqrt(x))
        w(x,y) = x*sqrt(x)
        n = floor(Int,(N-1)/2)-1
        d = 0

        (nc, dc, e, x) = ratfn_minimax(f,(a,c*c),n,d,w)
        println("error = ",e)
        mm(x) = x*(1+x*x*poly_eval(nc, BigFloat(x*x)))
    end

    # print for C#
    if output == true
        s = [1.0]
        append!(s,nc)
        print_csharp(s)
    end

    err(x) = abs(sin(x)-mm(x))
    return (mm,err)
end
plot([sin,sin_mm(5,pi/2, true)[1]],0,2pi)


# compare les DL
begin
    N = 5
    func = [sin]
    for i=0:5-1 push!(func,sin_taylor(2*i+1)[1]) end
    func
    plot(func, 0, pi)
end

# compare les err des DL
begin
    N = 5
    func = [x->0]
    for i=0:5-1 push!(func,x->log(10,sin_taylor(2*i+1)[2](x))) end
    func
    plot(func, 0, pi)
end


plot([sin,sin_taylor(7, true)[1]],0,2pi)
plot([sin,sin_mm_base(7,pi/2, true)[1]],0,2pi)


# donne un tableau de l'erreur absolue en ° pour différents approximations
# de la fonction sinus, et sur différents intervalles
# exprimés sous la forme [0,C], ou C est la borne indiquée en tête de colonne)
begin
    func = [sin_taylor(1), sin_taylor(3), sin_taylor(5), sin_taylor(7)]
    push!(func,sin_mm_base(3,pi),sin_mm(3,pi), sin_mm_base(5,pi),sin_mm(5,pi))
    func_name = ["sinT1", "sinT3", "sinT5", "sinT7"]
    push!(func_name,"sinMMB3", "sinMM3", "sinMMB5", "sinMM5")

    err = []
    for i=1:length(func)
        push!(err,(x->sin(x)-func[i](x)))
    end

    err_range = [0.01,0.1,1,2,5,10,22.5,45,60,90]

    nc = length(err_range) + 1
    nr = length(func)

    df = DataFrame()
    df[:Function] = func_name
    for i=1:nc-1
        df[symbol(string(err_range[i],"°"))] = Array{Float64}(nr)
    end

    fspec = FormatSpec(".2e")
    for r=1:nr
        for c=2:nc
            b = err_range[c-1] * (pi/180)
            err = err_eval(sin,func[r][1],(0,b))
            #df[r,c] = fmt(fspec, asin(err)*180/pi)
            df[r,c] = round(asin(err)*180/pi,4)

        end
    end
    println(df)
end

# compare visuellement le minmax de remez pour ordre n fixé et des
# intervalles de minimisation différents.
begin
    n = 3
    f4 = sin_mm(n,pi/4)[2]
    f3 = sin_mm(n,pi/3)[2]
    f2 = sin_mm(n,pi/2)[2]
    f1 = sin_mm(n,pi)[2]
    plot(
        [
            x->abs(f1(x))*180/pi,
            x->abs(f2(x))*180/pi,
            x->abs(f3(x))*180/pi,
            x->abs(f4(x))*180/pi
        ],
        -pi, pi,
        Guide.title("Compare various range-reduction for cos(x) over [-π/4,π/4]"),
        color=["f1","f2","f3","f4"]
        )
end

# comparer visuellement le remez base et l'autre (p0=1)
# pour un degré polynomial fixé (n)
begin
    n = 7
    fbase   = sin_mm_base(n,pi)[2]
    f       = sin_mm(n,pi/2)[2]
    plot(
        [
            x->abs(fbase(x)*180/pi),
            x->abs(f(x)*180/pi),
        ],
        0, pi/2,
        Guide.title("Compare various range-reduction for cos(x) over [-π/4,π/4]"),
        color=["fbase","f"]
        )
end

sin_mm(5,pi/2, true)[2]
