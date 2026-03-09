using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.ConstrainedExecution;

// README.md를 읽고 아래에 코드를 작성하세요.
Console.WriteLine("'''");
{
    Celsius c = new Celsius(100);
    Console.WriteLine(c);
    Console.WriteLine((Fahrenheit)c);
    
}
Console.WriteLine("'''\n");

Console.WriteLine("'''");
{

}
Console.WriteLine("'''\n");

struct Celsius
{
    public double cel;
    public Celsius(double cel)
    {
        this.cel = cel;
    }
    public override string ToString()
    {
        return $"{cel}°C";
    }
}
struct Fahrenheit
{
    public double fa;
    public Fahrenheit(double fa)
    {
        this.fa = fa;
    }
    public static explicit operator Celsius(Fahrenheit f)
    {
        return new Celsius((f.fa - 32) * 5 / 9);
    }
    public static explicit operator Fahrenheit(Celsius c)
    {
        return new Fahrenheit((c.cel * 9 / 5 + 32));
    }
    public override string ToString()
    {
        return $"{fa}°F";
    }
}

struct Vector3
{
    public double x;
    public double y;
    public double z;

    public Vector3(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public static Vector3 operator +(Vector3 v1, Vector3 v2)
    {
        return new Vector3(v1.x + v1.y, v1.y + v1.y, v1.z + v1.z);
    }
    public static Vector3 operator -(Vector3 v1, Vector3 v2)
    {
        return new Vector3(v1.x - v1.y, v1.y - v1.y, v1.z - v1.z);
    }
    public static Vector3 operator *(Vector3 v1, float num)
    {
        return new Vector3(v1.x * num, v1.y * num, v1.z * num);
    }
    public static Vector3 operator *(float num, Vector3 v1)
    {
        return v1 * num;
    }
    public static Vector3 operator -(Vector3 v1)
    {
        return new Vector3(-v1.x, -v1.y, -v1.z);
    }
    public static bool operator ==(Vector3 v1, Vector3 v2)
    {
        return (v1.x == v2.x) && (v1.y == v2.y) && (v1.z == v2.z);
    }
    public static bool operator !=(Vector3 v1, Vector3 v2)
    {
        return (v1.x != v2.x) || (v1.y != v2.y) || (v1.z != v2.z);
    }
    public override bool Equals(object obj)
    {
        if(obj is Vector3 v1)
        {
            return this == v1;
        }
        else
        {
            return false;
        }
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(x, y, z);
    }
    public override string ToString()
    {
        return $"({x}, {y}, {z})";
    }
}
