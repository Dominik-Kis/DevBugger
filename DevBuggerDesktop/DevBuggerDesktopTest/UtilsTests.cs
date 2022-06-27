using DevBuggerDesktop.DAL;
using DevBuggerDesktop.Models;
using DevBuggerDesktop.Util;
using DevBuggerDesktop.ViewModels;
using DevBuggerDesktop.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace DevBuggerDesktopTest
{


    [TestClass]
    public class UtilsTests
    {
        
        [TestInitialize()]
        public void Initialize()
        {
            //accountDetailWindow.GetDeleteButton().;
        }

        /*[TestMethod]
        public void TestAccountsViewModel()
        {
            List<Account> accounts = new List<Account> { new Account(1,1,"email", "user", "pass", "first", "last", DateTime.Now) };

            var accountRepository = new Mock<AccountRepository>();

            accountRepository.Setup(a => a.GetAccounts()).Returns(accounts);
            

            AccountsViewModel accountsViewModel = new AccountsViewModel();

            accountRepository.Setup(a => a.DeleteAccount(accountsViewModel.Accounts[0]));

            var response = accountsViewModel.Accounts.Remove(accountsViewModel.Accounts[0]);

            Assert.IsTrue(response);

        }*/

        [TestMethod]
        public void ShouldHashPassword()
        {
            string expected = "fDqXA4nx/Dx14pEHwwk8cLN+t21uOkz74N8ECTI47zw=";

            string result = PasswordHashUtils.HashPassword("password");

            Assert.IsNotNull(result);
            Assert.AreNotEqual(expected, result);
        }

        [TestMethod]
        public void ShouldValidateEmail()
        {
            Assert.IsTrue(ValidationUtils.isValidEmail("test@gmail.com"));
        }

        [TestMethod]
        public void ShouldFailValidateEmailNoAtSign()
        {
            Assert.IsFalse(ValidationUtils.isValidEmail("testgmail.com"));
        }

        [TestMethod]
        public void ShouldFailValidateEmailNoDot()
        {
            Assert.IsFalse(ValidationUtils.isValidEmail("test@gmailcom"));
        }

        [TestMethod]
        public void ShouldFailValidateEmailNoAtSignAndDoubleDot()
        {
            Assert.IsFalse(ValidationUtils.isValidEmail("test.gmail.com"));
        }

        [TestMethod]
        public void ShouldFailValidateEmailNoAtSignNoDot()
        {
            Assert.IsFalse(ValidationUtils.isValidEmail("testgmailcom"));
        }

        [TestMethod]
        public void ShouldFailValidateEmailNoFirstText()
        {
            Assert.IsFalse(ValidationUtils.isValidEmail("@gmail.com"));
        }

        [TestMethod]
        public void ShouldFailValidateEmailNoMiddleText()
        {
            Assert.IsFalse(ValidationUtils.isValidEmail("gmail@.com"));
        }

        [TestMethod]
        public void ShouldFailValidateEmailNoEndText()
        {
            Assert.IsFalse(ValidationUtils.isValidEmail("gmail@test."));
        }
    }
}
