using System.Linq.Expressions;

namespace Spelprojekt_grupp36
{
    internal class Program
    {

        static int spelaresTur = 0;
        static int a = 5;
        static int b = 5;
        static int c = 5;
        static bool inGame = true;
        static void Main(string[] args)
        {



            do
            {
                //if (Console.ReadLine() == "pause")
                //{
                //    Pausa();
                //}

                Uppdatera(a, b, c);
                Drag(spelaresTur, a, b, c);



            }
            while (inGame);


        }

        static void Drag(int spelare, int hög1, int hög2, int hög3)
        {
            if (spelare == 0)
            {
                Console.WriteLine("Det är spelare 1s tur");
            }
            else Console.WriteLine("Det är spelare 2s tur");

            try
            {
                Console.WriteLine("ange vilken hög");
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
                        Console.WriteLine("högen var utanför index, pröva igen");
                        Drag(spelaresTur, a, b, c);
                        return;
                }
            }
            catch
            {
                Console.WriteLine("något gick fel, pröva igen");

                Drag(spelaresTur, a, b, c);

            }


        }

        static void finnsPinnarKvar(int antalIhög, int högNr)
        {
            try
            {
                Console.WriteLine("ange hur många pinnar du vill ta");
                int antalTagna = int.Parse(Console.ReadLine());


                if (antalIhög < antalTagna)
                {
                    Console.WriteLine("du tar för många pinnar! försök igen");
                    finnsPinnarKvar(antalIhög, högNr);

                }
                else
                {
                    switch (högNr)
                    {
                        case 1:
                            a -= antalTagna;
                            return;
                        case 2:
                            b -= antalTagna;
                            return;
                        case 3:
                            c -= antalTagna;
                            return;



                    }


                }




            }
            catch
            {
                Console.WriteLine("något gick fel, försök igen");
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
                Console.WriteLine("högen var tom! försök igen");

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