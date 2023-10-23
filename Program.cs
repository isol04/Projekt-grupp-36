using System.Linq.Expressions;

namespace Spelprojekt_grupp36
{


    // Isac Olsson, Arvid Malmqvist, Usama Rabto -- 23/10-2023 -- Visual Studio 2022 
    internal class Program
    {
        static string senastDrag = "";

        static bool spelaresTur = true;
       
        static int spelare1vinnster = 0;
        static int spelare2vinnster = 0;

        static bool pausad = false;
        static bool namnAnget = false;

        static string spelare1 = "";
        static string spelare2 = "";
        static int[] pinnar = { 5, 5, 5 };
        static bool inGame = false;
        static bool ProgramAktivt = true;
        static void Main(string[] args)
        {
           
            do
            {

                Console.WriteLine(regler());
                Console.WriteLine(" \r\nskriv start för att starta spelet eller stop för att stänga av programmet!");
                string input = Console.ReadLine();
                if (input == "start")
                {
                    inGame = true;
                }
                if (input == "stop")
                {
                    ProgramAktivt = false;
                }
                while (inGame)
                {
                    while (!namnAnget)
                    {
                        angeNamn(); namnAnget = true;
                    }



                    if (pinnar[0] == 0 && pinnar[1] == 0 && pinnar[2] == 0)
                    {
                        VinnareOchPaus();
                    }
                    else
                    {
                        Uppdatera();
                        Draget();
                    }



                }
                
            }
            while (ProgramAktivt);
        }

        static void angeNamn()
        {
            Console.Clear();
            Console.WriteLine("spelare 1, ange ditt namn!");
            spelare1 = Console.ReadLine();
            Console.WriteLine("spelare 2, ange ditt namn!");
            spelare2 = Console.ReadLine();
        }

        static string aktivSpelareNamn()
        {
            if (spelaresTur) return spelare1;
            else return spelare2;
        }
        static void VinnareOchPaus()
        {
            spelaresTur = !spelaresTur;
            pinnar = new int[] { 5, 5, 5 };
            pausad = true;
            Console.Clear();

            if (spelaresTur) { Console.WriteLine(aktivSpelareNamn() + " vinner!\r\n"); spelare1vinnster++; }
            else
            {
                Console.WriteLine(aktivSpelareNamn() + " vinner! \r\n"); spelare2vinnster++;
            }


         
            while (pausad)
            {
                Console.WriteLine("Antal vinster " + spelare1 + ": " + spelare1vinnster + " | Antal vinster " + spelare2 + ": " + spelare2vinnster);
                Console.WriteLine("spela igen? (y/n)");
                if (Console.ReadLine() == "y")
                {
                    pausad = false;
                }
                else if (Console.ReadLine() == "n")
                {
                    inGame = false;
                    namnAnget = false;
                    spelare1vinnster = 0; spelare2vinnster = 0;

                }
                }
            }
            static string regler()
            {
                string regler = "Välkommen till spelet Nim! \n\n\n\n Nims regler lyder följande: \n 1. Spelet börjar med att 15 pinnar placeras i tre olika lika stora högar. \n 2. Därefter väljer startspelaren först en hög och sedan eliminerar spelaren x antal pinnar från den högen (minst en pinne). \n 3. Därefter gör nästa spelare sak. \n 4. Spelarna turas sedan om till att endast en pinne kvarstår. \n 5. Spelaren som väljer den sista pinnen vinner då spelet.";

                return regler;
            }
            static void Draget()

            {
              
                    Console.WriteLine("Det är " + aktivSpelareNamn() + "s tur");
            

                try
                {
                    Console.WriteLine("ange ditt drag");
                    string[] drag = Console.ReadLine().Trim().Split(' ');

                    if (möjligtDrag(int.Parse(drag[0]), int.Parse(drag[1])))
                    {
                        pinnar[int.Parse(drag[0]) - 1] -= int.Parse(drag[1]);
                       
                        Uppdatera();
                        senastDrag = (aktivSpelareNamn() + " tog " + drag[1] + " stickor från hög " + drag[0]);
                    spelaresTur = !spelaresTur;
                }
                    else
                    {
                        Uppdatera();
                        Console.WriteLine("Draget var icke möjligt, försök igen!");
                        Draget();
                    }


                }
                catch
                {
                    Uppdatera();
                    Console.WriteLine("Draget var icke möjligt, försök igen!");
                    Draget();
                }
            
            }

            static bool möjligtDrag(int a, int b)
            {
                try
                {
                    if (pinnar[a - 1] < b || b <= 0)
                    {
                        return false;
                    }

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        

            static void Uppdatera() //ritar upp pinnar
            {
                Console.Clear();
                Console.WriteLine(senastDrag);
                Console.Write("hög 1: ");
                for (int i = 0; i < pinnar[0]; i++)
                {
                    Console.Write("| ");
                }
                Console.WriteLine();
                Console.Write("hög 2: ");
                for (int i = 0; i < pinnar[1]; i++)
                {
                    Console.Write("| ");
                }
                Console.WriteLine();
                Console.Write("hög 3: ");
                for (int i = 0; i < pinnar[2]; i++)
                {
                    Console.Write("| ");
                }
                Console.WriteLine();
            }
        }
    }
