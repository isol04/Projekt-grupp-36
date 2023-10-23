using System.Linq.Expressions;

// Isac Olsson, Arvid Malmqvist, Usama Rabto -- 23/10-2023 -- Visual Studio 2022 
namespace Spelprojekt_grupp36
{


    internal class Program
    {
        static string senastDrag = "";

        static bool datornPå = false;

        static bool spelaresTur = true;
       
        static int spelare1vinnster = 0;
        static int spelare2vinnster = 0;

        static bool pausad = false;
        static bool namnAnget = false;

        static string spelare1 = "";
        static string spelare2 = "";
        static int[] pinnar = new int[3]; 
        static bool inGame = false;
        static bool ProgramAktivt = true;
     
        static void Main(string[] args)


        {
           
            /// <summary>
            /// denna do-while loop är hela programmet, när den lämnas så stängs programmet ner 
            /// </summary>
            do
            {

                Console.WriteLine(regler());
                Console.WriteLine(" \r\nSkriv 'start' för att starta spelet eller 'dator' för att spela mot datorn eller 'stop' för att stänga av programmet!");
                string input = Console.ReadLine();
                if (input == "start")
                {
                    blandaPinnar();
                    inGame = true;
                }
                if (input == "dator")
                {
                    blandaPinnar();
                    datornPå = true;
                    inGame = true;
                }

                if (input == "stop")
                {
                    ProgramAktivt = false;
                }

                /// <summary>
                ///  while loop för själva matchen: plockar namn, avgör ifall spelet är slut och upprepar metoderna som bygger upp spelet
                /// </summary>
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

        /// <summary>
        ///  metod som blandar pinnar
        /// </summary>
        static void blandaPinnar() 
        {
            Random r = new Random();
            pinnar[0] = r.Next(1, 7);
            pinnar[1] = r.Next(1, 7);
            pinnar[2] = 15 - pinnar[0] - pinnar[1];
        }
        /// <summary>
        /// metod för att ange namn vid spelstart, om datorn spelar behövs bara ett namn
        /// </summary>
        static void angeNamn()
        {
            Console.Clear();
            Console.WriteLine("spelare 1, ange ditt namn!");
            spelare1 = Console.ReadLine();

            if (!datornPå)
            {
                Console.WriteLine("spelare 2, ange ditt namn!");
                spelare2 = Console.ReadLine();
            }
            else spelare2 = "datorn";
        }

        /// <summary>
        /// metod för att hämta namnet på den aktiva spelaren
        /// </summary>
        /// <returns>
        /// namn i string
        /// </returns>
        static string aktivSpelareNamn()
        {
            if (spelaresTur) return spelare1;
            else return spelare2;
        }

        /// <summary>
        /// metod som deklarerar vinnaren och pausar spelet; här kan man välja ifall man vill fortsätta eller återgå till menyn 
        /// </summary>
        static void VinnareOchPaus()
        {
            senastDrag = "";
            spelaresTur = !spelaresTur;
          blandaPinnar();




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
                string input = Console.ReadLine();
                if (input == "y")
                {
                    //spelaresTur = true;
                    pausad = false;
                }
                else if (input == "n")
                {
                    datornPå = false;
                    pausad = false;
                    inGame = false;
                    namnAnget = false;
                    spelare1vinnster = 0; spelare2vinnster = 0;

                }
                }
            }
        /// <summary>
        /// metod som hämtar spel regler + välkomning
        /// </summary>
        /// <returns>
        /// returnerar string med regler
        /// </returns>
            static string regler()
            {
            Console.Clear();
            string regler = "Välkommen till spelet Nim! \n\n\n\n Nims regler lyder följande: \n 1. Spelet börjar med att 15 pinnar placeras i tre olika lika stora högar. \n 2. Därefter väljer startspelaren först en hög och sedan eliminerar spelaren x antal pinnar från den högen (minst en pinne). \n 3. Därefter gör nästa spelare sak. \n 4. Spelarna turas sedan om till att endast en pinne kvarstår. \n 5. Spelaren som väljer den sista pinnen vinner då spelet. \n 6. Dragen ska skrivas i formatet: <hög> <antal>";

                return regler;
            }


        /// <summary>
        /// metod som slumpar datorns drag, ifall det enbart finns en pinnhög kvar gör datorn alltid det vinnande draget
        /// </summary>
        /// <returns>
        /// returnernar en array i samma format som spelarens inmatning efter 'split'
        /// </returns>
        static string[] DatornsDrag()
        {
            System.Threading.Thread.Sleep(3000);

            Random r = new Random();
            string[] datorns = new string[] {"0", "0"};


            while (datorns[0] == "0") //ser till så att datorn aldrig går igenom 'olagliga' drag; får spelet att prestera bättre
            {
                datorns[0] = r.Next(1, 4).ToString();
                if (pinnar[int.Parse(datorns[0])-1] <= 0)
                         {
                    datorns[0] = "0";
                }

            }

            switch (datorns[0])
            {
                case "1":
                    if (pinnar[1] == 0 && pinnar[2] == 0)
                        return new string[] { datorns[0], (pinnar[int.Parse(datorns[0]) - 1]).ToString() };
                    
                    break;
                case "2":
                    if (pinnar[0] == 0 && pinnar[2] == 0)
                        return new string[] { datorns[0], (pinnar[int.Parse(datorns[0]) - 1]).ToString() };
               
                    break;
                case "3":
                    if (pinnar[0] == 0 && pinnar[1] == 0)
                        return new string[] { datorns[0], (pinnar[int.Parse(datorns[0]) - 1]).ToString() };
             
                    break;

            }

            return new string[] { datorns[0], r.Next(1, pinnar[int.Parse(datorns[0]) - 1]).ToString() };
        }

        /// <summary>
        /// metod som hanterar drag. ifall något går fel med inmatningen upprepas metoden så att spelet kan fortsätta utan problem
        /// </summary>
        static void Draget()

            {
                    Console.WriteLine("Det är " + aktivSpelareNamn() + "s tur...");
        
                try
                {
           
                string[] drag = new string[2];
                if (datornPå && !spelaresTur)
                {
                    drag = DatornsDrag();
                }
                else
                {
                    Console.WriteLine("ange ditt drag i formatet: <hög> <antal>");
                  drag = Console.ReadLine().Trim().Split(' ');
                }

              

                    if (möjligtDrag(int.Parse(drag[0]), int.Parse(drag[1])))
                    {
                        pinnar[int.Parse(drag[0]) - 1] -= int.Parse(drag[1]);
                       
                        Uppdatera();
                        senastDrag = (aktivSpelareNamn() + " tog " + drag[1] + " pinnar från hög " + drag[0]);
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

        /// <summary>
        /// beräknar om draget följer nim-reglerna
        /// </summary>
        /// <param name="a">
        /// vilken hög man tar ifrån
        /// </param>
        /// <param name="b">
        /// hur många pinnar man tar från högen
        /// </param>
        /// <returns>
        /// returnerar en bool ifall det är lagligt eller ej
        /// </returns>
            static bool möjligtDrag(int hög, int antal)
            {
                try
                {
                    if (pinnar[hög - 1] < antal || antal <= 0)
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
        
        /// <summary>
        /// rensar skärmen och ritar upp spelbrädet samt skriver ut det senaste draget som utförts
        /// </summary>
            static void Uppdatera() 
            {
                Console.Clear();
                Console.WriteLine(senastDrag);

            for (int i = 0; i  < pinnar.Length; i++)
            {
                Console.Write("hög " + (i + 1) + ": ");
                for (int j = 0; j < pinnar[i]; j++)
                {
                    Console.Write("| ");
                }
                Console.WriteLine();
            }

            }
        }
    }
