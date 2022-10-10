using System;
using System.Linq;

namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int AccountNumber = 0;
            bool LogInSuccess = false;
            int LogInAttempts = 0;
            bool Banking = false;
            string[,] UserAndPassword = new string[5, 2] { { "Patrik", "1234" }, { "Anas", "2345" }, { "Theo", "3456" }, { "Leo", "4567" }, { "Lucas", "5678" } };
            double[,] Money = new double[5, 2] { { 2345.23 , 45562 }, { 2312, 23214 }, { 5313.4, 43144 }, { 4341.23, 45366 }, { 2344.12, 55324 } };
            do
            {
                Console.Clear();
                Console.WriteLine("Välkommen till banken");
                Console.Write("Användarnamn: ");
                string UserName = Console.ReadLine();
                Console.Write("pinkod: ");
                string UserPassword = Console.ReadLine();
                for (int i = 0; i < UserAndPassword.Length / 2; i++)
                {
                    if(UserAndPassword[i,0] == UserName && UserAndPassword[i,1] == UserPassword)
                    {
                        Banking = true;
                        LogInSuccess = true;
                        AccountNumber = i;
                        LogInAttempts = 0;
                        IsBanking(Banking,LogInSuccess,Money,UserAndPassword,AccountNumber);
                    }
                }
                LogInAttempts++;
            } while (LogInAttempts < 3 ^ LogInSuccess);

        }

        private static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Se dina konton och saldo\n2. Överföring mellan konton\n3. Ta ut pengar\n4. Logga ut");
        }
        public static void IsBanking(bool Banking, bool LogInSuccess, double[,] Cash, string[,] UserAndPassword, int AccountNumber)
        {
            while (Banking && LogInSuccess)
            {
                PrintMenu();
                if (Int32.TryParse(Console.ReadLine(), out int MenuChoice))
                {
                    switch (MenuChoice)
                    {
                        case 1:
                            // Account overview
                            Console.WriteLine("Översikt av konton:");
                            ShowAccountDetails(Cash, AccountNumber);
                            EnterForMainMenu();
                            break;
                        case 2:
                            // Transfer money between accounts
                            double MovingMoney = 0;
                            Console.WriteLine("Överföring mellan konto:");
                            ShowAccountDetails(Cash, AccountNumber);
                            Console.Write("För över pengar från konto: ");
                            if(Int32.TryParse(Console.ReadLine(), out int AccountChoice) && AccountChoice <=2)
                            {
                                if(AccountChoice == 1)
                                {
                                    Console.Write("Summa att föra över: ");
                                    MovingMoney = Convert.ToDouble(Console.ReadLine());
                                    if (MovingMoney <= Cash[AccountNumber, 0])
                                    {
                                        Cash[AccountNumber, 0] -= Math.Round(MovingMoney, 2);
                                        Cash[AccountNumber, 1] += Math.Round(MovingMoney, 2);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Du kan inte föra över mer pengar än vad som finns på kontot");
                                        EnterForMainMenu();
                                    }
                                }
                                else if(AccountChoice == 2)
                                {
                                    Console.Write("Summa att föra över: ");
                                    MovingMoney = Convert.ToDouble(Console.ReadLine());
                                    if(MovingMoney <= Cash[AccountNumber, 1])
                                    {
                                        Cash[AccountNumber, 1] -= Math.Round(MovingMoney, 2);
                                        Cash[AccountNumber, 0] += Math.Round(MovingMoney, 2);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Du kan inte föra över mer pengar än vad som finns på kontot");
                                        EnterForMainMenu();
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt val");
                                EnterForMainMenu();
                            }
                            break;
                        case 3:
                            // Money withdrawal
                            ShowAccountDetails(Cash, AccountNumber);
                            break;
                        case 4:
                            // Log out 
                            LogInSuccess = false;
                            Banking = false;
                            break;
                        default:
                            Console.WriteLine("Menu val är giltigt mellan 1-4");
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
            Console.WriteLine("1: Privatkonto:  {0} kr", Cash[AccountNumber, 0]);
            Console.WriteLine("2: Lönekonto:    {0} kr", Cash[AccountNumber, 1]);
        }
        private static void EnterForMainMenu()
        {
            Console.WriteLine("Tryck ENTER för att komma tillbaka till menu");
            Console.ReadKey();
        }
    }
}
