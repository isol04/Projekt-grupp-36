using System.Linq.Expressions;

namespace Spelprojekt_grupp36
{
    internal class Program
    {
        
        static bool spelaresTur = true;
        static int a = 5;
        static int b = 5;
        static int c = 5;
        static bool inGame = false;
        static bool ProgramAktivt = true;
        static void Main(string[] args)
        {

            do
            {

                Console.WriteLine(regler());
                Console.WriteLine(" \r\nskriv start för att starta spelet eller stop för att stänga av programmet!");
                string input = Console.ReadLine();
                if  (input == "start")
                {
                    inGame = true;
                }
                if (input == "stop")
                {
                    ProgramAktivt = false;
                }
                while (inGame) 
                {


                    if (a == 0 && b == 0 && c == 0)
                    {
                        Vinnare(!spelaresTur);

                    }
                    else
                    {
                        Uppdatera(a, b, c);
                        Drag(spelaresTur, a, b, c);
                    }


                }
               

            }
            while (ProgramAktivt);
        }

        static void Vinnare(bool spelare)
        {
            if (spelare) { Console.WriteLine("spelare 1 vinner!"); }
            else { Console.WriteLine("spelare 2 vinner! \r\n"); }

            a = 5;
            b = 5;
            c = 5;

            //nollställer spelet
            
        }

        static string regler()
        {

            string regler = "Välkommen till spelet Nim! \n\n\n\n Nims regler lyder följande: \n 1. Spelet börjar med att 15 pinnar placeras i tre olika lika stora högar. \n 2. Därefter väljer startspelaren först en hög och sedan eliminerar spelaren x antal pinnar från den högen (minst en pinne). \n 3. Därefter gör nästa spelare sak. \n 4. Spelarna turas sedan om till att endast en pinne kvarstår. \n 5. Spelaren som väljer den sista pinnen vinner då spelet.";

            return regler;


        }





        static void Drag(bool spelare, int hög1, int hög2, int hög3)
        {
            if (spelare == true) //avgör vems tur det är
            {
                Console.WriteLine("Det är spelare 1s tur");
            }
            else Console.WriteLine("Det är spelare 2s tur");

            try //denna try-catch kollar ifall högen man tar ifrån finns och 
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