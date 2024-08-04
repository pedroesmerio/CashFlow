using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
{
    public RegisterExpenseValidator()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage("The title is required.");
        RuleFor(expense => expense.Date).NotEmpty().LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Expenses cannot be for the future.");
        RuleFor(expense => expense.Amount).NotEmpty().GreaterThan(0).WithMessage("The amount must be greater than zero.");
        RuleFor(expense => expense.PaymenteType).NotEmpty().IsInEnum().WithMessage(ex =>(string.Format("Payment type {0} is not valid", ex.PaymenteType)));
    }
}
