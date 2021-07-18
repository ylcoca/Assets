using FluentValidation;
using Hahn.ApplicatonProcess.July2021.Core.Model;

namespace Hahn.ApplicatonProcess.July2021.Domain.Validators
{
    public class UserValidator:AbstractValidator<UserAsset>
    {
        public UserValidator()
        {
            
             RuleFor(u => u.Asset.Name).NotNull().NotEmpty().WithMessage("Must be an existing asset");
            RuleFor(u => u.Asset.User.Age > 18).NotEmpty().WithMessage("Age must be over 18");
            RuleFor(u => u.Asset.User.FirstName).MinimumLength(3).WithMessage("First Name must have alt least 3 characters"); 
            RuleFor(u => u.Asset.User.LastName).MinimumLength(3).WithMessage("Last Name must have alt least 3 characters");
             RuleFor(u => u.Asset.User.Address ).NotNull().Must(IsValidAddress).WithMessage("Address its not valid");
            RuleFor(u => u.Asset.User.Email).EmailAddress().NotEmpty().WithMessage("Email must be correct"); 
        }

        private bool IsValidAddress(string address)
        {
            return true; //validate address
        }
    }
}
