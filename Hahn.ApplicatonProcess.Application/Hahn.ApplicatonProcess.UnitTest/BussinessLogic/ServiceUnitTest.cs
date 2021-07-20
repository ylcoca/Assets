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

            Task<int> taskIntReturn = Task<int>.Factory.StartNew(() =>
            {
                return 1;
            });
            
            _unitOfWork.Setup(m => m.UserAssetRepository.DeleteUserAsset(It.IsAny<UserAsset>())).Returns(taskIntReturn);


            _unitOfWork.Setup(m => m.UserAssetRepository.UpdateUserAsset(It.IsAny<UserAsset>())).Returns(1);

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
        public void GetUserAsset_On_Successs_Test()
        {
            var userAsset = service.GetUserAsset(1);
            Assert.AreEqual(userAsset.Value.Asset.Name, UserAssetMock.UserAsset().Asset.Name);
        }

        [TestMethod()]
        public void PutUserAssetTest()
        {
            var modified = service.PutUserAsset(UserAssetMock.UserAsset());
            Assert.AreEqual(1, modified);
        }

        [TestMethod()]
        public void DeleteUserAssetTest()
        {
            var deleted = service.DeleteUserAsset(UserAssetMock.UserAsset());
            Assert.AreEqual(1, deleted.Result);
        }

    }
}