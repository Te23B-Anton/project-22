
class doungonEscape
{

    // hur många gånger du kan dö
    static int liv = 3;
    // hur många rundor
    static int rundor = 10;

    static void Main()
    {
        Console.WriteLine("Välkommen till Dungeon Escape!");
        // kör koden för hur många rundor
        for (int runda = 1; runda <= rundor; runda++)
        {
            // om liv blir 0
            if (liv <= 0)
            {
                Console.WriteLine("Du dog!");
            }

            Console.WriteLine($"Runda {runda} av {rundor}.");
            Console.WriteLine($"Du har {liv} liv kvar");
            Console.WriteLine("Du står framför 3 stycken dörrar, välj 1,2 eller 3");

        // vilken man väljer är det för input till
            string input = Console.ReadLine();
        //convertar det man sätter in 
            bool säker = int.TryParse(input, out int val);
            // den säger om du skrev 1, 2 eller 3
            if (säker == true)
            {
                // chekar så du kan bara välja dörr 1 2 eller 3
                if (val < 1 && val > 3)
                {
                    Console.Clear();
                    Console.WriteLine("inte någon av dörrarna välj ingen.");
                    runda--;
                    continue;

                }
                // om man väljer fel dörr så förlorar man ett liv
                int Dödligdör = Random.Shared.Next(1, 4);
                if (val == Dödligdör)
                {
                    Console.Clear();
                    liv--;
                    Console.WriteLine("Du valde fel dörr!");

                }
                 else 
                //  om man väljer rätt dörr
                {
                    Console.Clear();
                    Console.WriteLine("Du valde rätt dörr!");

                    // om man väljer rätt dörr så finns en chans att man får ett extra liv
                    if (Random.Shared.Next(5) == 0)
                    {
                        Console.WriteLine("Du hittade en special rum, du får en mera liv");
                        liv++;
                    }
                }
            }
            // checkar om du skrev 1, 2, 3
            else if (säker != true)
            {
                Console.Clear();
                Console.WriteLine("det är inte ett numer på en dörr");
                runda--;
            }
        }
        // checkar när du har gjort så många rundor som behövs
        if (rundor == 10)
        {
            Console.Clear();
            Console.WriteLine("Du escapade doungonen!");
        }

        Console.ReadLine();
    }
}

