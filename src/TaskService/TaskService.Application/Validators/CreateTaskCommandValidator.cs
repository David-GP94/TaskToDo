using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TaskService.Application.Commands;

namespace TaskService.Application.Validators
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(c => c.title).NotEmpty().MaximumLength(100);
            RuleFor(c => c.description).MaximumLength(500);
        }
    }
}
