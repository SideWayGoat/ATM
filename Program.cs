using System;

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
            decimal[,] Money = new decimal[5, 2] { { 2345.23M , 45562M }, { 2312, 23214M }, { 5313.4M, 43144M }, { 4341.23M, 45366M }, { 2344.12M, 55324M } };
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to the SUT22 bank");
                Console.Write("Username: ");
                string UserName = Console.ReadLine();
                Console.Write("Pin Number: ");
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
            Console.WriteLine("1. Account Oversight\n2. Internal Transfer\n3. Money Withdrawal\n4. Log out");
        }
        public static void IsBanking(bool Banking, bool LogInSuccess, decimal[,] Cash, string[,] UserAndPassword, int AccountNumber)
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
                            Console.WriteLine("Account Oversight:");
                            ShowAccountDetails(Cash, AccountNumber);
                            EnterForMainMenu();
                            break;
                        case 2:
                            // Transfer money between accounts
                            int AccountChoice;
                            InternalMoneyTransfer(Cash, AccountNumber);
                            EnterForMainMenu();
                            break;
                        case 3:
                            // Money withdrawal
                            AccountChoice = WithdrawalOfMoney(Cash, UserAndPassword, AccountNumber);
                            EnterForMainMenu();

                            break;
                        case 4:
                            // Log out 
                                int LogInAttempts = 0;
                                    LogInSuccess = false;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Welcome to the SUT22 bank");
                                Console.Write("Username: ");
                                string UserName = Console.ReadLine();
                                Console.Write("Pin Number: ");
                                string UserPassword = Console.ReadLine();
                                for (int i = 0; i < UserAndPassword.Length / 2; i++)
                                {
                                    if (UserAndPassword[i, 0] == UserName && UserAndPassword[i, 1] == UserPassword)
                                    {
                                        LogInSuccess = true;
                                        AccountNumber = i;
                                        LogInAttempts = 0;
                                    }
                                }
                                LogInAttempts++;
                            } while (LogInAttempts < 3 ^ LogInSuccess);
                            break;
                        default:
                            Console.WriteLine("Menu choices include 1-4");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice ");
                    Console.ReadKey();
                }
            }
        }
        private static void InternalMoneyTransfer(decimal[,] Cash, int AccountNumber)
        {
            decimal MovingMoney = 0;
            Console.WriteLine("Transfer between accounts:");
            ShowAccountDetails(Cash, AccountNumber);
            Console.Write("Transfer money from account: ");
            if (Int32.TryParse(Console.ReadLine(), out int AccountChoice) && AccountChoice <= 2)
            {
                if (AccountChoice == 1)
                {
                    Console.Write("Amount to transfer: ");
                    if(decimal.TryParse(Console.ReadLine(), out MovingMoney))
                    {
                        if (MovingMoney <= Cash[AccountNumber, 0])
                        {
                            Cash[AccountNumber, 0] -= Math.Round(MovingMoney, 2, MidpointRounding.ToEven);
                            Cash[AccountNumber, 1] += Math.Round(MovingMoney, 2, MidpointRounding.ToEven);
                            Console.WriteLine("Successfully transfered {0} kr", MovingMoney);
                        }
                        else
                        {
                            Console.WriteLine("You can't transfer more money than avaliable on the account");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong, please try again");
                    }

                }
                else if (AccountChoice == 2)
                {
                    Console.Write("Amount to transfer: ");
                    if(decimal.TryParse(Console.ReadLine(), out MovingMoney))
                    {
                        if (MovingMoney <= Cash[AccountNumber, 1])
                        {
                            Cash[AccountNumber, 1] -= Math.Round(MovingMoney, 2, MidpointRounding.ToEven);
                            Cash[AccountNumber, 0] += Math.Round(MovingMoney, 2, MidpointRounding.ToEven);
                            Console.WriteLine("Successfully transfered {0} kr", MovingMoney);
                        }
                        else
                        {
                            Console.WriteLine("You can't transfer more money than avaliable on the account");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong, please try again");
                    }

                }
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }
        }
        private static int WithdrawalOfMoney(decimal[,] Cash, string[,] UserAndPassword, int AccountNumber)
        {
            int AccountChoice;
            Console.WriteLine("Withdrawal Money: ");
            ShowAccountDetails(Cash, AccountNumber);
            decimal MoneyWithdrawal = 0;
            Console.Write("choose Account: ");
            if (Int32.TryParse(Console.ReadLine(), out AccountChoice) && AccountChoice <= 2)
            {
                if (AccountChoice == 1)
                {
                    Console.Write("Amount to withdrawal : ");
                    if(decimal.TryParse(Console.ReadLine(), out MoneyWithdrawal))
                    {
                        Console.Write("Pin Number: ");
                        string Code = Console.ReadLine();
                        if (MoneyWithdrawal <= Cash[AccountNumber, 0] && Code == UserAndPassword[AccountNumber, 1])
                        {
                            Cash[AccountNumber, 0] -= Math.Round(MoneyWithdrawal, 0);
                            Console.WriteLine("Withdrawal successful ");
                        }
                        else if (MoneyWithdrawal > Cash[AccountNumber, 0])
                        {
                            Console.WriteLine("You can't withdrawal more money than avaliable on the account ");
                        }
                        else
                        {
                            Console.WriteLine("Wrong Pin Number");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please try again");
                    }

                }
                if (AccountChoice == 2)
                {
                    Console.Write("Amount to withdrawal : ");
                    if (decimal.TryParse(Console.ReadLine(), out MoneyWithdrawal))
                    {
                        Console.Write("Pin Number: ");
                        string PinNumber = Console.ReadLine();
                        if (MoneyWithdrawal <= Cash[AccountNumber, 1] && PinNumber == UserAndPassword[AccountNumber, 1])
                        {
                            Cash[AccountNumber, 1] -= Math.Round(MoneyWithdrawal, 0);
                            Console.WriteLine("Withdrawal successful");
                        }
                        else if (MoneyWithdrawal > Cash[AccountNumber, 1])
                        {
                            Console.WriteLine("You can't withdrawal more money than avaliable on the account");
                        }
                        else
                        {
                            Console.WriteLine("Wrong Pin Number");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please try again");
                    }
                }
            }
            else
            {
                Console.WriteLine("The choice you made is invalid");
            }

            return AccountChoice;
        }
        private static void ShowAccountDetails(decimal[,] Cash, int AccountNumber)
        {
            Console.WriteLine("1: Private Account:  {0} kr", Cash[AccountNumber, 0]);
            Console.WriteLine("2: Salary Account:   {0} kr", Cash[AccountNumber, 1]);
        }
        private static void EnterForMainMenu()
        {
            Console.WriteLine("Press ENTER to retun to main menu");
            Console.ReadKey();
        }
    }
}
