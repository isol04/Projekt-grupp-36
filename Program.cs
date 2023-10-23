using System.Linq.Expressions;

namespace Spelprojekt_grupp36
{
    internal class Program
    {

        static bool spelaresTur = true;
        static int a = 5;
        static int b = 5;
        static int c = 5;
        static bool inGame = true;
        static void Main(string[] args)
        {



            do
            {
                
                if (a == 0 && b == 0 && c == 0)
                {
                    Vinnare(!spelaresTur);
                }

                Uppdatera(a, b, c);
                Drag(spelaresTur, a, b, c);



            }
            while (inGame);


        }

        static void Vinnare(bool spelare)
        {
            if (spelare) { Console.WriteLine("spelare 1 vinner!"); }
            else { Console.WriteLine("spelare 2 vinner! \r\n"); }

            a = 5;
            b = 5;
            c = 5;
            
        }
        static void Drag(bool spelare, int hög1, int hög2, int hög3)
        {
            if (spelare == true)
            {
                Console.WriteLine("Det är spelare 1s tur");
            }
            else Console.WriteLine("Det är spelare 2s tur");

            try
            {
                Console.WriteLine("Ange vilken hög du vill ta från");
                int drag = int.Parse(Console.ReadLine());
                switch (drag)
                {
                    case 1:
                        finnsHögKvar(hög1, 1);
                        return;

                    case 2:
                        finnsHögKvar(hög2, 2);
                        return;

                    case 3:
                        finnsHögKvar(hög3, 3);
                        return;
                    default:
                        Console.WriteLine("Högen var utanför index, pröva igen\r\n");
                        Drag(spelaresTur, a, b, c);
                        return;
                }
            }
            catch
            {
                Console.WriteLine("något gick fel, pröva igen\r\n");

                Drag(spelaresTur, a, b, c);

            }


        }

        static void finnsPinnarKvar(int antalIhög, int högNr)
        {
            try
            {
                Console.WriteLine("Ange hur många pinnar du vill ta från högen");
                int antalTagna = int.Parse(Console.ReadLine());


                if (antalIhög < antalTagna)
                {
                    Console.WriteLine("Du tar för många pinnar! försök igen\r\n");
                    finnsPinnarKvar(antalIhög, högNr);

                }
                else
                {
                    switch (högNr)
                    {
                        case 1:
                            a -= antalTagna;
                            spelaresTur = !spelaresTur;
                            return;
                        case 2:
                            b -= antalTagna;
                            spelaresTur = !spelaresTur;
                            return;
                        case 3:
                            c -= antalTagna;
                            spelaresTur = !spelaresTur;
                            return;
                    }

                }




            }
            catch
            {
                Console.WriteLine("Något gick fel, försök igen\r\n");
                {
                    finnsPinnarKvar(antalIhög, högNr);
                }
            }


        }
    


        static void finnsHögKvar(int antalIhög, int högNr)
        {
            if (antalIhög != 0)
            { 
                finnsPinnarKvar(antalIhög, högNr);
            
            }

            else
            {
                Console.WriteLine("Högen var tom! försök igen\r\n");

                Drag(spelaresTur, a, b, c);
            }

        }
        static void Pausa()
        {
            inGame = false;
        }
        static void Uppdatera(int hög1, int hög2, int hög3) //ritar upp pinnar
        {
            for (int i = 0; i < hög1;  i++)
            {
                Console.Write("| ");
            }
            Console.WriteLine();
            for (int i = 0; i < hög2; i++)
            {
                Console.Write("| ");
            }
            Console.WriteLine();
            for (int i = 0; i < hög3; i++)
            {
                Console.Write("| ");
            }
            Console.WriteLine();
        }
    }
}