using Syntax_Squad;
using System.Reflection;
using Moq;
using System.IO;
using System.Collections.Generic;
using Castle.Components.DictionaryAdapter.Xml;

namespace MSTest
{
    [TestClass]
    public class SytanxSquadTester
    {
        [TestMethod]
        [Description("This is a test to see if the system matches username with password")]
        public void Matching_username_with_password()
        {
            //Arrange
            var mockUser = new User
            {
                Name = "Börje",
                Password = "kaffe123",
                IsAdmin = false,
                IsLoggedIn = false
            };

            var allTheUsers = new List<User> { mockUser };
            var logInServices = new LogInServices(allTheUsers);


            string result = logInServices.LogIn("Börje", "kaffe123");

            //Act

            var expectedOutPut = "\tLogin successful! press enter to continue to menu.";
            Assert.AreEqual(expectedOutPut, result);

        }

        [TestMethod]
        [Description("Test transfer between two accounts owned by the same user")]
        public void TransferBetweenSameUserAccounts_Test()
        {
            // Arrange
            BankAccount.ExistingBankAccounts();
            User.ExistingUsers();

            var user = User.AllTheUsers.First(u => u.Name == "Börje");
            var account1 = BankAccount.GetList().First(a => a.AccountName == "Kontantkort");
            var account2 = BankAccount.GetList().First(a => a.AccountName == "Sparkonto");
            double initialBalance1 = account1.Balance;
            double initialBalance2 = account2.Balance;

            Transfer transferService = new Transfer();

            // Act
            transferService.TransferBetweenOwnAccounts(user, account1.AccountNumber, account2.AccountNumber, 2000.0);

            // Assert
            Assert.AreEqual(initialBalance1 - 2000, account1.Balance);
            Assert.AreEqual(initialBalance2 + 2000, account2.Balance);

        }

        [TestMethod]
        [Description("Test transfer between accounts owned by different users")]
        public void TransferBetweenDifferentUserAccounts_Test()
        {
            // Arrange
            BankAccount.ExistingBankAccounts();
            User.ExistingUsers();

            var user1 = User.AllTheUsers.First(u => u.Name == "Börje");
            var user2 = User.AllTheUsers.First(u => u.Name == "Åke");
            var account1 = BankAccount.GetList().First(a => a.AccountName == "Kontantkort");
            var account2 = BankAccount.GetList().First(a => a.AccountName == "Fun card");
            double initialBalance1 = account1.Balance;
            double initialBalance2 = account2.Balance;
            string password = user1.Password;

            Transfer transferService = new Transfer();

            // Act
            transferService.TransferBetweenOtherAccounts(user1, account1.AccountNumber, account2.AccountNumber, 200.0, password);

            // Assert
            Assert.AreEqual(initialBalance1 - 200, account1.Balance);
            Assert.AreEqual(initialBalance2 + 200, account2.Balance);
        }
    }
}