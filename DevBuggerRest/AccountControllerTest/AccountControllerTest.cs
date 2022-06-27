using DevBuggerRest.Controllers;
using DevBuggerRest.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;

namespace AccountControllerTest
{
    [TestClass]
    public class AccountControllerTest
    {

        // these are needed on every test
        AccountController accountController;

        [TestInitialize]
        public void TestInitialize()
        {
            accountController = new AccountController();
        }

        [TestMethod]
        public void ShouldGetAccount()
        {
            Account account = account = new Account(1, 1, "deleteted-account@mail.com", "[Deleted_account]", "go342mjkojsdpkijgmkiWEENMGKwnghare", "Deleted", "Account", DateTime.Now);

            var response = accountController.GetAccount(1);

            Assert.IsNotNull(response);
            Assert.AreEqual(account, response);
        }

        [TestMethod]
        public void ShouldFailToGetAccount()
        {
            Account account = null;

            accountController.GetAccount(184684864);

            Assert.IsNull(account, null);
        }

        [TestMethod]
        public void ShouldGetAccounts()
        {
            var response = accountController.GetAccounts();

            Assert.IsNotNull(response);
            Assert.IsTrue(response is List<Account>);
        }

        [TestMethod]
        public void ShouldUpdateAccount()
        {
            Account account = new Account(2, 1, "testtest@mail.com", "test", "Ml6YBKF5pYsjltNcFC9oSNTrPdjPqrfHVu6TKu8rm+0=", "te", "st", DateTime.Now);

            var response = accountController.UpdateAccount(account);

            Assert.IsTrue(response);
        }

        [TestMethod]
        public void ShouldFailTotUpdateAccount()
        {
            Assert.IsFalse(accountController.UpdateAccount(null));
        }

        [TestMethod]
        public void ShouldLoginAccount()
        {
            Account account = account = new Account(1, 1, "deleteted-account@mail.com", "[Deleted_account]", "go342mjkojsdpkijgmkiWEENMGKwnghare", "Deleted", "Account", DateTime.Now);

            var response = accountController.LoginAccount(account);

            Assert.IsNotNull(response);
            Assert.AreEqual(account, response);
        }

        [TestMethod]
        public void ShouldFailTotLoginAccount()
        {
            Assert.IsFalse(accountController.UpdateAccount(null));
        }
    }
}
