using FluentValidation;

namespace DotNetCoreArchitecture.Model
{
    public sealed class ItemAddValidator : ItemValidator<ItemModel>
    {
        public ItemAddValidator()
        {
            RuleFor(x => x.ItemName).NotEmpty();
            RuleFor(x => x.MaxNum).NotEmpty();
            RuleFor(x => x.MinNum).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}

