using FluentValidation;
using WebApplication1.Model;

namespace WebApplication1.Valdiator
{
    public class StudentValidator : AbstractValidator<Student>
    {
		public StudentValidator()
		{
			RuleFor(x => x.LastName).NotEmpty();
			RuleFor(x => x.FirstMidName).NotEmpty();
			RuleFor(x => x.FirstMidName).Length(0, 10);
		}
	}
}
