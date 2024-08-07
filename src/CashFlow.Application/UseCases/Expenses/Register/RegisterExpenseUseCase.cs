using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Expense;
using CashFlow.Exception.ExceptionBase;
using CashFlow.Infrastructure.DataAccess;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);

        var dbContext = new CashFlowDbContext();
        var entity = new Expense
        {
            Amount = request.Amount,
            Date = request.Date,
            Description = request.Description,
            Title = request.Title,
            PaymentType = (Domain.Enums.PaymentType)request.PaymenteType,
        };

        dbContext.Expenses.Add(entity);
        dbContext.SaveChanges();

        return new ResponseRegisteredExpenseJson { SyncStatus = true, Title = request.Title};
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
