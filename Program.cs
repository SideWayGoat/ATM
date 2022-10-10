using System;

namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int AccountNumber;
            int LogInAttempts = 0;
            bool Banking = false;
            string[,] UserAndPassword = new string[5, 2] { { "Patrik", "1234" }, { "Anas", "2345" }, { "Theo", "3456" }, { "Leo", "4567" }, { "Lucas", "5678" } };
            double[,] Money = new double[5, 2] { { 2345.23 , 45562 }, { 2312, 23214 }, { 5313.4, 43144 }, { 4341.23, 45366 }, { 2344.12, 55324 } };
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
                        Banking = true;
                        AccountNumber = i;
                        LogInAttempts = 0;
                        IsBanking(Banking,Money,UserAndPassword,AccountNumber);
                    }
                }
                LogInAttempts++;
            } while (LogInAttempts < 3 ^ Banking == true);

        }

        private static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Se dina konton och saldo\n2. Överföring mellan konton\n3. Ta ut pengar\n4. Logga ut");
        }
        public static void IsBanking(bool Banking, double[,] Cash, string[,] UserAndPassword, int AccountNumber)
        {
            while (Banking)
            {
                PrintMenu();
                if (Int32.TryParse(Console.ReadLine(), out int MenuChoice))
                {
                    switch (MenuChoice)
                    {
                        case 1:
                            // Se konton och saldo
                            Console.WriteLine("Översikt av konton:");
                            ShowAccountDetails(Cash, AccountNumber);
                            Console.ReadKey();
                            break;
                        case 2:
                            //Överföring mellan konton
                            Console.WriteLine("Överföring mellan konto:");
                            ShowAccountDetails(Cash, AccountNumber);
                            Console.ReadKey();
                            break;
                        case 3:
                            // Ta ut pengar 
                            ShowAccountDetails(Cash, AccountNumber);
                            Console.ReadKey();
                            break;
                        case 4:
                            // Logga ut
                            Banking = false;
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

        private static void ShowAccountDetails(double[,] Cash, int AccountNumber)
        {
            Console.WriteLine("Privatkonto:  {0} kr", Cash[AccountNumber, 0]);
            Console.WriteLine("Lönekonto:    {0} kr", Cash[AccountNumber, 1]);
        }
    }
}
