using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hahn.ApplicatonProcess.July2021.Data.Repository;
using System;
using System.Threading.Tasks;
using Moq;
using Hahn.ApplicatonProcess.July2021.Core.Model;
using Hahn.ApplicatonProcess.UnitTest.Mocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.July2021.Data.Repository.Tests
{
    [TestClass()]
    public class UserAssetRepositoryTests
    {
        private IUserAssetRepository _repository;
        private Mock<DBContext> mockContext;
        private Mock<DbSet<UserAsset>> mockSet;


        [TestInitialize()]
        public void InitializeTest()
        {   
            mockSet = new Mock<DbSet<UserAsset>>();

            mockContext = new Mock<DBContext>();
            mockContext.Setup(m => m.UserAsset).Returns(mockSet.Object);

            _repository = new UserAssetRepository(mockContext.Object);
           
        }
        [TestMethod()]
        public void InsertUserAssetTest()
        {
            
            _repository.InsertUserAsset(UserAssetMock.UserAsset());
            mockSet.Verify(m => m.Add(It.IsAny<UserAsset>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod()]
        public void DeleteUserAssetTest()
        {
            _repository.InsertUserAsset(UserAssetMock.UserAsset());
            mockSet.Verify(m => m.Remove(It.IsAny<UserAsset>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod()]
        public void GetUserAssetTest()
        {
            _repository.GetUserAsset(It.IsAny<int>());
            mockSet.Verify(m => m.Include(It.IsAny<string>()), Times.AtLeastOnce());
        }        

        [TestMethod()]
        public void UpdateUserAssetTest()
        {
            _repository.UpdateUserAsset(UserAssetMock.UserAsset());
            mockSet.Verify(m => m.Update(It.IsAny<UserAsset>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}