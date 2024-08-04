using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);
        return new ResponseRegisteredExpenseJson { Title = request.Title};
    }

    public void Validate(RequestRegisterExpenseJson request)
    {
        var titleIsNoEmpty = string.IsNullOrWhiteSpace(request.Title);
        if (titleIsNoEmpty)
        {
            throw new ArgumentException("The title is required.");
        }

        var dateIsValid = DateTime.Compare(request.Date, DateTime.UtcNow);
        if (dateIsValid > 0)
        {
            throw new ArgumentException("Expenses cannot be for the future.");
        }

        if (request.Amount <= 0)
        {
            throw new ArgumentException("The amount must be greater than zero.");
        }

        var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.PaymenteType);
        if (!paymentTypeIsValid)
        {
            throw new ArgumentException(string.Format("Payment type {0} is not valid", request.PaymenteType));
        }

    }
}
