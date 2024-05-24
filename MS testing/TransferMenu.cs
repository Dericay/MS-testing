using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax_Squad
{
    //Noah SUT23
    public class TransferMenu : UserMenu
    {
        Transfer transfer = new Transfer();
        public override void ShowMenu(User user)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            ACIIART Art = new ACIIART();

            bool validChoice = true;
            do
            {
                Console.Clear();
                Art.PrintArt();
                Console.WriteLine("\t---|| Transfer Menu ||---");
                Console.WriteLine("\t1: Transfer between own accounts  \n\t2: Transfer to another user \n\t3: Transaction history \n\t4: Return to menu");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        transfer.TransferBetweenOwnAccounts(user, 1001, 1002, 200.0);
                        break;
                    case "2":
                        int fromAccountNumber = 1001; 
                        int toAccountNumber = 3006;   
                        double amount = 150.0;        
                        string password = "kaffe123";
                        break;
                    case "3":
                        Transfer.PrintTransactionHistoryUser(user);
                        break;
                    case "4":
                        validChoice = false;
                        break;
                    default:
                        break;
                }



            } while (validChoice);
        }
    }
}
