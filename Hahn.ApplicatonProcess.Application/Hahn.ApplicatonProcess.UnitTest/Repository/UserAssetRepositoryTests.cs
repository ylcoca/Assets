using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hahn.ApplicatonProcess.July2021.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Hahn.ApplicatonProcess.July2021.Core.Model;
using Hahn.ApplicatonProcess.UnitTest.Mocks;
using Microsoft.AspNetCore.Mvc;

namespace Hahn.ApplicatonProcess.July2021.Data.Repository.Tests
{
    [TestClass()]
    public class UserAssetRepositoryTests
    {
        private IUserAssetRepository _repository;
        private Mock<DBContext> _context;

        [TestInitialize()]
        public void InitializeTest()
        {
            _context = new Mock<DBContext>();
            _context.Setup(m => m.UserAsset.Add(It.IsAny<UserAsset>()));
            //_context.Setup(m => m.UserAsset.GetUserAsset(It.IsAny<int>())).Returns(UserAsset());

            _repository = new UserAssetRepository(_context.Object);
        }
        [TestMethod()]
        public void InsertUserAssetTest()
        {
            Task<ActionResult<int>> rowsAffected =  _repository.InsertUserAsset(UserAssetMock.UserAsset());
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteUserAssetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetUserAssetTest()
        {
            Assert.Fail();
        }        

        [TestMethod()]
        public void UpdateUserAssetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UserAssetExistsTest()
        {
            Assert.Fail();
        }
    }
}