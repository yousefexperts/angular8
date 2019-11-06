using DotNetCore.Validation;
using FluentValidation;

namespace DotNetCoreArchitecture.Model
{
    public class ValidatorItemBaseList<T> : ItemListValidator<ItemListModel>
    {
        public ValidatorItemBaseList()
        {
            RuleFor(x => x.CreateDate).NotEmpty();
        }
    }
}
