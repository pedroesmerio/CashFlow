using CashFlow.Communication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
{
    public RegisterExpenseValidator()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage(ResourceErrorMessages.TITLE_IS_REQUIRED);
        RuleFor(expense => expense.Date).NotEmpty().LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.EXPENSES_IN_FUTURE);
        RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage(ResourceErrorMessages.AMOUNT_GREATER_THAN_ZERO);
        RuleFor(expense => expense.PaymenteType).NotEmpty().IsInEnum().WithMessage(ex =>(string.Format(ResourceErrorMessages.PAYMENT_TYPE_INVALID, ex.PaymenteType)));
    }
}
