using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hahn.ApplicatonProcess.July2021.Domain.BussinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.July2021.Data.Repository;
using Moq;
using Hahn.ApplicatonProcess.July2021.Core.Model;
using Hahn.ApplicatonProcess.July2021.Data;
using Hahn.ApplicatonProcess.UnitTest.Mocks;

namespace Hahn.ApplicatonProcess.July2021.Domain.BussinessLogic.Tests
{
    [TestClass()]
    public class ServiceUnitTest
    {
        private IService service;
        private Mock<IUnitOfWork> _unitOfWork;

        [TestInitialize()]
        public void InitializeTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(m => m.UserAssetRepository.InsertUserAsset(It.IsAny<UserAsset>()));
            _unitOfWork.Setup(m => m.UserAssetRepository.GetUserAsset(It.IsAny<int>())).Returns(UserAssetMock.UserAsset());

            service = new Service(_unitOfWork.Object);
        }


        [TestMethod()]
        public void AddUserAsset_On_Succes_Return_Null_Test()
        {
            var userAsset = service.AddUserAsset(UserAssetMock.UserAsset());
            Assert.IsNull(userAsset);
        }

        [TestMethod()]
        public void AddUserAsset_On_Fail_To_Validate_Return_Null_Test()
        {
            var userAsset = service.AddUserAsset(UserAssetMock.UserAssetWithEmailProblem());
            Assert.IsNotNull(userAsset);
        }

        [TestMethod()]
        public void GetUserAssetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PutUserAssetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteUserAssetTest()
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