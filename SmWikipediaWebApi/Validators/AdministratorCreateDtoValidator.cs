using FluentValidation;
using SmWikipediaWebApi.Entities;
using SmWikipediaWebApi.Models;
using System.Linq;

namespace SmWikipediaWebApi.Validators
{
    public class AdministratorCreateDtoValidator : AbstractValidator<AdministratorCreateDto>
    {
        public AdministratorCreateDtoValidator(WikipediaDbContext dbContext)
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();

            RuleFor(x => x.Password).MinimumLength(6);

            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password);

            RuleFor(x => x.Email).Custom((value, context) =>
            {
                var emailInUse = dbContext.Administrators.Any(x => x.Email == value);

                if (emailInUse)
                {
                    context.AddFailure("Emial", "Adres email jest zajęty");
                }
            });
        }
    }
}
