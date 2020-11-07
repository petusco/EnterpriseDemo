using Enterprise.API.Dtos;
using FluentValidation;

namespace Enterprise.API.Validators
{
	public class CustomerForCreationDtoValidator : AbstractValidator<CustomerForCreationDto>
	{
		public CustomerForCreationDtoValidator()
		{
			RuleFor(dto => dto.FirstName).NotEmpty();
			RuleFor(dto => dto.LastName).NotEmpty();
		}
	}
}
