using Dataaccess.models;
using FluentValidation;

namespace Dataaccess.Validations
{
    public class EmployeeModelValidator : AbstractValidator<EmployeeModel>
    {
        public EmployeeModelValidator()
        {
            RuleFor(x => x.empcode).NotEmpty().WithMessage("Employee code is required");
            RuleFor(x => x.empname).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.dep).NotEmpty().WithMessage("Department is required");
            RuleFor(x => x.designation).NotEmpty().WithMessage("Designation is required");
        }
    }
}
