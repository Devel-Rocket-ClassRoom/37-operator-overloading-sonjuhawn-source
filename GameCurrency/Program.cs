using System;
using System.Diagnostics.CodeAnalysis;

// README.md를 읽고 코드를 작성하세요.
Console.WriteLine("코드를 작성하세요.");

GameCurrency wallet1 = new GameCurrency(3, 50);
GameCurrency wallet2 = new GameCurrency(1, 80);

Console.WriteLine($"지갑1: {wallet1}");
Console.WriteLine($"지갑2: {wallet2}");

GameCurrency sum = wallet1 + wallet2;
Console.WriteLine($"합계: {sum}");

GameCurrency diff = wallet2 - wallet1;
Console.WriteLine($"차액: {diff}");

Console.WriteLine($"지갑1 == 지갑2: {wallet1 == wallet2}");
Console.WriteLine($"지갑1 != 지갑2: {wallet1 != wallet2}");
Console.WriteLine($"지갑1 > 지갑2: {wallet1 > wallet2}");
Console.WriteLine($"지갑1 < 지갑2: {wallet1 < wallet2}");

GameCurrency wallet3 = new GameCurrency(0, 250);
Console.WriteLine($"250S 정규화: {wallet3}");
Console.WriteLine($"지갑1 총 Silver: {wallet1.GetTotalSilver()}");

struct GameCurrency
{
    public int Gold;
    public int Silver;
    public GameCurrency(int Gold, int Silver)
    {
        if(Gold == 0 && Silver >= 100)
        {
            this.Gold = Silver / 100;
            this.Silver = Silver % 100;
        }
        else
        {
            this.Gold = Gold;
            this.Silver = Silver;
        }
    }

    public static GameCurrency operator +(GameCurrency a, GameCurrency b)
    {
        if(a.Silver + b.Silver >= 100)
        {
            return new GameCurrency(a.Gold + b.Gold + 1, a.Silver + b.Silver - 100);
        }
        else
        {
            return new GameCurrency(a.Gold + b.Gold, a.Silver + b.Silver);
        }
    }
    public static GameCurrency operator -(GameCurrency a, GameCurrency b)
    {
        if(a.Gold-b.Gold < 0)
        {
            return new GameCurrency(0, 0);
        }
        else
        {
            return new GameCurrency(a.Gold - b.Gold, a.Silver - b.Silver);
        }
    }
    public static bool operator ==(GameCurrency a, GameCurrency b)
    {
        return a.Gold == b.Gold && a.Silver == b.Silver;
    }
    public static bool operator !=(GameCurrency a, GameCurrency b)
    {
        return !(a == b); 
    }
    public static bool operator <(GameCurrency a, GameCurrency b)
    {
        if(a.Gold < b.Gold)
        {
            return true;
        }
        else if(a.Gold == b.Gold)
        {
            if(a.Silver < b.Silver)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public static bool operator >(GameCurrency a, GameCurrency b)
    {
        if (a.Gold > b.Gold)
        {
            return true;
        }
        else if (a.Gold == b.Gold)
        {
            if (a.Silver > b.Silver)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public override string ToString()
    {
        return $"{Gold}G {Silver}S";
    }

    public int GetTotalSilver()
    {
        return Gold *100 + Silver;
    }
    public override bool Equals(object obj)
    {
        if(obj is GameCurrency game)
        {
            return this == game;
        }
        else
        {
            return false;
        }
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Gold, Silver);
    }

}