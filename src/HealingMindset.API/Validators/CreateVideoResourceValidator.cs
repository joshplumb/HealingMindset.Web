using FluentValidation;
using HealingMindset.Api.DTOs;

namespace HealingMindset.Api.Validators
{
    public class CreateVideoResourceValidator : AbstractValidator<VideoRequestDTO>
    {
        public CreateVideoResourceValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.YoutubeId).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
