using DotNetCore.Validation;
using FluentValidation;

namespace DotNetCoreArchitecture.Model
{
    public class ItemListValidator<T> : Validator<T> where T : ItemListModel
    {
        public ItemListValidator()
        {
            RuleFor(x => x.CreateDate).NotEmpty();
        }
    }
}

