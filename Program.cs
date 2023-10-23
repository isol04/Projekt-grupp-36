namespace Spelprojekt_grupp36
{
    internal class Program
    {


      static  int a = 5;
      static  int b = 5;
      static  int c = 5;
      static  bool inGame = true;
        static void Main(string[] args)
        {



            do
            {
                if (Console.ReadLine() == "pause")
                {
                    Pausa();
                }



            }
            while (inGame);


            Uppdatera(a, b, c);
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
        }
    }
}