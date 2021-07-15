using FluentValidation;
using Hahn.ApplicatonProcess.July2021.Domain.Model;
using System.Linq;

namespace Hahn.ApplicatonProcess.July2021.Domain.Validators
{
    public class UserValidator:AbstractValidator<UserAsset>
    {
        readonly AssetsVm assets;
        public UserValidator(AssetsVm assets)
        {
            this.assets = assets;
             RuleFor(u => u.Asset.Name).NotNull().Must(IsValidName).WithMessage("Must be an existing asset");
            RuleFor(u => u.Asset.User.Age > 18).NotEmpty().WithMessage("Age must be over 18");
            RuleFor(u => u.Asset.User.FirstName).MinimumLength(3).WithMessage("First Name must have alt least 3 characters"); 
            RuleFor(u => u.Asset.User.LastName).MinimumLength(3).WithMessage("Last Name must have alt least 3 characters");
            // RuleFor(u => u.Asset.User.Address ).NotNull().Must(IsValidAddress).WithMessage("...");
            RuleFor(u => u.Asset.User.Email).EmailAddress().NotEmpty().WithMessage("Email must be correct"); 
        }

        private bool IsValidName(string name)
        {
            return assets.Data.Any(arr => arr.Name == name);
        }

        private bool IsValidAddress(string address)
        {
            return false; //validate address
        }
    }
}
