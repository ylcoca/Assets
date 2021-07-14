using FluentValidation;
using Hahn.ApplicatonProcess.July2021.Domain.Model;

namespace Hahn.ApplicatonProcess.July2021.Domain.Validators
{
    class UserAssetValidator:AbstractValidator<User>
    {
        public UserAssetValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();//.Must(IsValidName).WithMessage("Tiene que ser un nombre valido.");
           /* RuleFor(u => u.Asset.User.Age > 18).NotEmpty();
            RuleFor(u => u.Asset.User.FirstName.Length >= 3);
            RuleFor(u => u.Asset.User.LastName.Length >= 3);
            // RuleFor(u => u.Asset.User.Address ).WithMessage("Tiene que ser mayor de edad para poder registrarse.");
            RuleFor(u => u.Asset.User.Email).EmailAddress();*/
        }

        private bool IsValidName(string name)
        {
            return false; //validate name
        }
    }
}
