include("remez.jl")
using Gadfly

#interval = [0,sup]
sup = 50

# naive range reduction in [-π,π]
begin

    function rr_naive_1(r::Number)
        twoPI = 6.283185307179586
        k = floor(r/twoPI)
        rp = r - k * twoPI;
        return cos(rp)
    end

    function rr_naive_2(r::Number)
        twoPI   = 6.283185307179586
        _twoPI  = 0.15915494309189535 # 1/(2π)
        k = round(Int,r * _twoPI)
        rp = r - k * twoPI;
        return cos(rp)
    end

    function rr_cody(r::Number)
        c1 = Float64((2*3217-1)/1024)
        c2 = Float64(2*pi-c1)
        _twoPI  = 0.15915494309189535 # 1/(2π)
        k = round(Int,r * _twoPI)
        rp = (r - k * c1) - k * c2
        return cos(rp)
    end

    plot(
        [
            x->cos(x)-rr_naive_1(x),
            x->cos(x)-rr_naive_2(x),
            x->cos(x)-rr_cody(x)
        ],
        0, sup,
        Guide.title("Compare various range-reduction for cos(x) over [-π,π]"),
        color=["naive_1","naive_2","cody and wait"]
        )
end

# naive range reduction in [-π/4,π/4]
begin
    function rr_naive_1(r::Number)
        PI_2 = 1.5707963267948966
        k = floor(r/PI_2)
        rp = r - k * PI_2;

        rem = k%4
        if rem == 0 return cos(rp) end
        if rem == 1 return -sin(rp) end
        if rem == 2 return -cos(rp) end
        if rem == 3 return sin(rp) end
    end

    function rr_naive_2(r::Number)
        PI_2 = 1.5707963267948966 # π/2
        _PI_2  = 0.6366197723675814 # 2/π
        k = round(Int,r * _PI_2)
        rp = r - k * PI_2;

        rem = k%4
        if rem == 0 return cos(rp) end
        if rem == 1 return -sin(rp) end
        if rem == 2 return -cos(rp) end
        if rem == 3 return sin(rp) end
    end

    function rr_cody(r::Number)
        c1 = Float64(1608/1024)
        c2 = Float64(pi/2-c1)
        _PI_2  = 0.6366197723675814 # 2/π
        k = round(Int,r * _PI_2)
        rp = (r - k * c1) - k * c2

        rem = k%4
        if rem == 0 return cos(rp) end
        if rem == 1 return -sin(rp) end
        if rem == 2 return -cos(rp) end
        if rem == 3 return sin(rp) end
    end

    plot(
        [
            x->cos(x)-rr_naive_1(x),
            x->cos(x)-rr_naive_2(x),
            x->cos(x)-rr_cody(x)
        ],
        0, sup,
        Guide.title("Compare various range-reduction for cos(x) over [-π/4,π/4]"),
        color=["naive_1","naive_2","cody and wait"]
        )
end

begin
    function rr(r::Number)
        twoPI   = 6.283185307179586
        _twoPI  = 0.15915494309189535 # 1/(2π)
        k = round(Int,r * _twoPI)
        rp = r - k * twoPI;
        return rp
    end

    plot(rr,-2pi,2pi)

end
