using Hahn.ApplicatonProcess.July2021.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.UnitTest.Mocks
{
    public static class UserAssetMock
    {
        public static UserAsset UserAsset()
        {
            UserAsset userAsset = new UserAsset
            {
                ID = 1,
                Asset = new Asset
                {
                    Id = 1,
                    Rank = 1,
                    Name = "Bitcoin",
                    Supply = 18743737.0000000000000000,
                    MaxSupply = 21000000.0000000000000000,
                    MarketCapUsd = 592470411799.9659357299679304,
                    VolumeUsd24Hr = 8921801291.5592294582419098,
                    PriceUsd = 31608.9802049594451592,
                    User = User()
                }
            };
            return userAsset;
        }

        public static UserAsset UserAssetWithEmailProblem()
        {
            UserAsset userAsset = new UserAsset
            {
                ID = 1,
                Asset = new Asset
                {
                    Id = 1,
                    Rank = 1,
                    Name = "Bitcoin",
                    Supply = 18743737.0000000000000000,
                    MaxSupply = 21000000.0000000000000000,
                    MarketCapUsd = 592470411799.9659357299679304,
                    VolumeUsd24Hr = 8921801291.5592294582419098,
                    PriceUsd = 31608.9802049594451592,
                    User = UserWithoutMail()
                }
            };
            return userAsset;
        }

        public static User User()
        {
            return new User
            {
                Id = 1,
                Age = 35,
                FirstName = "John",
                LastName = "Doe",
                Email = "mail@gmail.com",
                Address = "Address"
            };
        }

        public static User UserWithoutMail()
        {
            return new User
            {
                Id = 1,
                Age = 35,
                FirstName = "John",
                LastName = "Doe",
                Email = "mail",
                Address = "Address"
            };
        }
    }
}
