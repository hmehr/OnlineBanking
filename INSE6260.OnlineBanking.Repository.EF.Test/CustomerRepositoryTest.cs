﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using INSE6260.OnlineBanking.Infrastructure;
using INSE6260.OnlineBanking.Infrastructure.Specifications;
using INSE6260.OnlineBanking.Model;
using INSE6260.OnlineBanking.Model.Accounts;
using INSE6260.OnlineBanking.Repository.EF.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace INSE6260.OnlineBanking.Repository.EF.Test
{
    
    [TestClass]
    public class ClientRepositoryTest
    {
        private static IUnitOfWork _unitOfWork;

        #region Additional test attributes

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            DbContextFactory.SetupDbConnection("OnlineBanking");
            _unitOfWork = new EFUnitOfWork();
        }

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void LazyLoadTest()
        {
            var ClientRepository = new ClientRepository(_unitOfWork);
            Client customer = ClientRepository.FindByID(14);
            Assert.AreEqual(2, customer.Accounts.Count);
        }

        [TestMethod]
        public void SpecificationTest()
        {
            var ClientRepository = new ClientRepository(_unitOfWork);
            IQueryable<Client> customers =
                ClientRepository.Query(new AdHocSpecification<Client>(c => c.ClientID > 5));
            Assert.AreNotEqual(0, customers.Count());
        }

        [TestMethod]
        public void CollectionInsertTest()
        {
            var customer = new Client {Name = "Customer-LazyLoad", Family = "CustomerA1"};
            var ClientRepository = new ClientRepository(_unitOfWork);
            ClientRepository.Add(customer);
            var account1 = new Account {Client = customer, Balance = 10, OpendedDate = DateTime.Now};
            var account2 = new Account {Client = customer, Balance = 100, OpendedDate = DateTime.Now};
            customer.Accounts = new Collection<Account> {account1, account2};
            _unitOfWork.Commit();
            customer = ClientRepository.FindByID(customer.ClientID);
            Assert.AreEqual(2, customer.Accounts.Count);
        }

        [TestMethod]
        public void UnitOfWorkTest()
        {
            var customer = new Client {Name = "CustomerA1", Family = "CustomerA1"};
            var ClientRepository = new ClientRepository(_unitOfWork);
            ClientRepository.Add(customer);
            var account1 = new Account {Client = customer, Balance = 0, OpendedDate = DateTime.Now};
            var account2 = new Account {Client = customer, Balance = 100, OpendedDate = DateTime.Now};
            var accountRepository = new AccountRepository(_unitOfWork);
            accountRepository.Add(account1);
            accountRepository.Add(account2);
            _unitOfWork.Commit();
            var accountList = accountRepository.GetCustomerAccounts(customer.ClientID);
            Assert.AreEqual(2, accountList.Count);
        }

        [TestMethod]
        public void InsertDeleteAndUpdateTest()
        {
            var ClientRepository = new ClientRepository(_unitOfWork);
            Client customer = ClientRepository.FindByID(10);
            customer.Name = "Updated";
            ClientRepository.Update(customer);
            var accountRepository = new AccountRepository(_unitOfWork);
            var accountList = accountRepository.GetCustomerAccounts(customer.ClientID);
            foreach (var account in accountList)
            {
                accountRepository.Remove(account);
            }

            _unitOfWork.Commit();
            var deletedAccountList = accountRepository.GetCustomerAccounts(customer.ClientID);
            Assert.AreEqual(0, deletedAccountList.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            var customer = new Client {Name = "abc", Family = "abc"};
            var ClientRepository = new ClientRepository(_unitOfWork);
            const string start = "a";
            ClientRepository.Add(customer);
            _unitOfWork.Commit();
            var insertedCustomer = ClientRepository.GetFirstCustomerStartWith(start);
            Assert.AreNotEqual(null, insertedCustomer);
        }

        [TestMethod]
        public void GetFirstCustomerStartWithTest()
        {
            var target = new ClientRepository(_unitOfWork);
            const string start = "a";
            var actual = target.GetFirstCustomerStartWith(start);
            Assert.AreNotEqual(null, actual);
        }
    }
}