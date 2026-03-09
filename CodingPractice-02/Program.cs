using System;

// README.md를 읽고 아래에 코드를 작성하세요.
Console.WriteLine("'''");
{
    Celsius c = new Celsius();
    Fahrenheit f = (Fahrenheit)c;

    Console.WriteLine(c);
    Console.WriteLine(f);
}
Console.WriteLine("'''\n");

Console.WriteLine("'''");
{

}
Console.WriteLine("'''\n");

public struct Fahrenheit
{
    public double Degrees;

    public Fahrenheit(double degrees)
    {
        Degrees = degrees;
    }

    public override string ToString()
    {
        return $"{Degrees}°F";
    }
}
struct Celsius
{
    public double Degrees;
    public Celsius(double degrees)
    {
        Degrees = degrees;
    }
    public static explicit operator Fahrenheit(Celsius c)
    {
        return new Fahrenheit(c.Degrees * 9 / 5 + 32);
    }

    public static explicit operator Celsius(Fahrenheit f)
    {
        return new Celsius((f.Degrees - 32) * 5 / 9);
    }

    public override string ToString()
    {
        return $"{Degrees}°C";
    }
}
struct Vector3
{
    public double X;
    public double Y;
    public double Z;

    public Vector3(double x, double y, double z)
    {
        X = x;
        Y = y; 
        Z = z;
    }

    public static Vector3 operator +(Vector3 v1, Vector3 v2)
    {
        return new Vector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
    }
    public static Vector3 operator -(Vector3 v1, Vector3 v2)
    {
        return new Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
    }
    public static Vector3 operator *(Vector3 v1, double num)
    {
        return new Vector3(v1.X * num, v1.Y * num, v1.Z * num);
    }
    public static Vector3 operator *(double num, Vector3 v1)
    {
        return new Vector3(v1.X * num, v1.Y * num, v1.Z * num);
    }
    public static Vector3 operator -(Vector3 v1, double num)
    {
        return new Vector3(v1.X * num, v1.Y * num, v1.Z * num);
    }
    public static Vector3 operator -(Vector3 v1)
    {
        return new Vector3(-v1.X, -v1.Y,- v1.Z );
    }
    public static bool operator ==(Vector3 v1, Vector3 v2)
    {
        return v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;
    }
    public static Vector3 operator !=(Vector3 v1, double num)
    {
        return new Vector3(v1.X * num, v1.Y * num, v1.Z * num);
    }
}