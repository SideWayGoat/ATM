using System;

namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int LogInAttempts = 0;
            bool IsBanking = false;
            string[,] UserAndPassword = new string[5, 2] { { "Patrik", "1234" }, { "Anas", "2345" },{ "Theo", "3456" },{ "Leo", "4567" },{ "Lucas", "5678" } };
            double[][] Cash = new double[5][];
            do
            {
                Console.Clear();
                Console.Write("Användarnamn: ");
                string UserName = Console.ReadLine();
                Console.Write("pinkod: ");
                string UserPassword = Console.ReadLine();
                for (int i = 0; i < UserAndPassword.Length / 2; i++)
                {
                    if(UserAndPassword[i,0] == UserName && UserAndPassword[i,1] == UserPassword)
                    {
                        IsBanking = true;
                        LogInAttempts = 0;
                    }
                }
                //if (UserName == UserAndPassword[0, 0] && UserPassword == UserAndPassword[0, 1])
                //{
                //    Console.WriteLine("Välkommen {0} ", UserAndPassword[0, 0]);
                //    Banking = true;
                //}                
                //else if (UserName == UserAndPassword[1, 0] && UserPassword == UserAndPassword[1, 1])
                //{
                //    Console.WriteLine("Välkommen {0} ", UserAndPassword[1, 1]);
                //    Banking = true;
                //}                
                //else if (UserName == UserAndPassword[2, 0] && UserPassword == UserAndPassword[2, 1])
                //{
                //    Console.WriteLine("Välkommen {0} ", UserAndPassword[2, 0]);
                //    Banking = true;
                //}                
                //else if (UserName == UserAndPassword[3, 0] && UserPassword == UserAndPassword[3, 1])
                //{
                //    Console.WriteLine("Välkommen {0} ", UserAndPassword[3, 0]);
                //    Banking = true;
                //}                
                //else if (UserName == UserAndPassword[4, 0] && UserPassword == UserAndPassword[4, 1])
                //{
                //    Console.WriteLine("Välkommen {0} ", UserAndPassword[4, 0]);
                //    Banking = true;
                //}
                LogInAttempts++;
            } while (LogInAttempts < 3 ^ IsBanking == true);

            while (IsBanking)
            {
                PrintMenu();
                if (Int32.TryParse(Console.ReadLine(), out int MenuChoice))
                {
                    switch (MenuChoice)
                    {
                        case 1:
                            // Se konton och saldo
                            break;
                        case 2:
                            //Överföring mellan konton
                            break;
                        case 3:
                            // Ta ut pengar 
                            break;
                        case 4:
                            // Logga ut
                            IsBanking = false;
                            break;
                        default:
                            Console.WriteLine("Menu val är giltigt mellan 1-4");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt val i menu");
                    Console.ReadKey();
                }
            }

        }

        private static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Se dina konton och saldo\n2. Överföring mellan konton\n3. Ta ut pengar\n4. Logga ut");
        }
    }
}
