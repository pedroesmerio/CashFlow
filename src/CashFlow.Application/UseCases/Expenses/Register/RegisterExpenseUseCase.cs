using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception;

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
        var result = new RegisterExpenseValidator().Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(err => err.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
