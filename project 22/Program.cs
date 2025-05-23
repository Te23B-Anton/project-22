using System;

class DungeonEscape
{
    static int liv = 3;
    static int rundor = 10;

    static void Main()
    {
        StartMeddelande();
        SpelaRundor();
        AvslutaSpel();
    }

    static void StartMeddelande()
    {
        Console.WriteLine("Välkommen till Dungeon Escape!");
    }

    static void SpelaRundor()
    {
        for (int runda = 1; runda <= rundor; runda++)
        {
            if (liv <= 0)
            {
                Console.WriteLine("Du dog!");
                break;
            }

            SkrivInstruktioner(runda);

            int val = LäsVal();
            if (val == -1)
            {
                runda--;
                continue;
            }

            if (!ÄrGiltigtVal(val))
            {
                Console.Clear();
                Console.WriteLine("Inte någon av dörrarna, välj igen tack.");
                runda--;
                continue;
            }

            HanteraVal(val);
        }
    }

    static void SkrivInstruktioner(int runda)
    {
        Console.WriteLine($"Runda {runda} av {rundor}.");
        Console.WriteLine($"Du har {liv} liv kvar");
        Console.WriteLine("Du står framför 3 stycken dörrar, välj 1,2 eller 3");
    }

    static int LäsVal()
    {
        string input = Console.ReadLine();
        bool säker = int.TryParse(input, out int val);
        if (!säker)
        {
            Console.Clear();
            Console.WriteLine("Det är inte ett nummer på en dörr");
            return -1;
        }
        return val;
    }

    static bool ÄrGiltigtVal(int val)
    {
        return val >= 1 && val <= 3;
    }

    static void HanteraVal(int val)
    {
        int dödligDörr = Random.Shared.Next(1, 4);
        if (val == dödligDörr)
        {
            Console.Clear();
            liv--;
            Console.WriteLine("Du valde fel dörr!");
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Du valde rätt dörr!");
            if (Random.Shared.Next(5) == 0)
            {
                Console.WriteLine("Du hittade ett specialrum, du får ett extra liv!");
                liv++;
            }
        }
    }

    static void AvslutaSpel()
    {
        if (liv > 0)
        {
            Console.Clear();
            Console.WriteLine("Du escapade dungeonen!");
        }
        Console.ReadLine();
    }
}