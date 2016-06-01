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

# output for C# code
function print_csharp(s)
    ns = length(s)
    println("")
    for i=1:ns
        println("double s",2(i-1)," = ",Float64(s[i]),";")
    end

    if ns < 2
        str = "return s1 * x"
    else
        str = "return s0 + x2"
        println("double x2 = x*x")

        for i=0:ns-3
            str = string(str," * (s",2(i+1)," + x2")
        end
        str = string(str," * (s",2(ns-2)," + x2 * s",2(ns-1), repeat(")",ns-1),";")
    end

    println(str)
end



# retourne le minmax de sqrt(1-x*x) à l'ordre n sur [-C,C]
function sqrt_mm_base(n, c, output=false)
    println(string("MinMax approximation of sin(x) over ","[-C,C]"))

    target(x) = sqrt(1-x*x)

    a = BigFloat(1e-30)
    b = BigFloat(c)

    f(x) = sqrt(1-x)
    w(x,y) = 1
    n = div(n,2)
    d = 0

    (nc, dc, e, x) = ratfn_minimax(f,(a,b*b),n,d,w)

    println("error = ",e)
    #println("  ",ratfn_to_string(nc, dc))
    for i in 1:length(nc)
        println("C",i-1, " : ", nc[i])
    end

    # print for C#
    if output == true
        print_csharp(nc)
    end

    mm(x) = poly_eval(nc, BigFloat(x*x))
    err(x) = abs(target(x)-mm(x))
    return (mm,err)
end

# retourne le minmax de sqrt(1-x*x) à l'ordre n sur [-C,C]
function sqrt_mm(n, c, output=false)
    println(string("MinMax approximation of sin(x) over ","[-C,C]"))

    # max |sin(x) - P(x)| = E , over I = [-C,C]
    target(x) = sqrt(1-x*x)

    a = BigFloat(1e-30)
    b = BigFloat(c)

    f(x) = (sqrt(1-x)-1)/x
    w(x,y) = x
    n = div(n,2)-1
    d = 0

    (nc, dc, e, x) = ratfn_minimax(f,(a,b*b),n,d,w)

    println("error = ",e)
    #println("  ",ratfn_to_string(nc, dc))
    for i in 1:length(nc)
        println("C",i-1, " : ", nc[i])
    end

    # print for C#
    if output == true
        s = [1.0]
        append!(s,nc)
        print_csharp(s)
    end

    mm(x) = 1 + x*x*poly_eval(nc, BigFloat(x*x))
    err(x) = abs(target(x)-mm(x))
    return (mm,err)
end

sqrt_mm_base(6,sin(pi/64), true)
sqrt_mm(6,sin(pi/64), true)

begin
    plot([x->sqrt(1-x*x),sqrt_mm_base(4,0.5)[1], sqrt_mm(6,sin(pi/64))[1]],-pi/180,pi/180)
end

plot([sqrt_mm_base(6,sin(pi/64))[2], sqrt_mm(6,sin(pi/64))[2]],-pi/64,pi/64)
