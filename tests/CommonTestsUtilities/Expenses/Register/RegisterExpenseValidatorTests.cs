using CashFlow.Application.UseCases.Expenses.Register;

namespace Validator.Tests.Expenses.Register;
public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        //Arrange
        var request = RequestRegisterExpenseJsonBuilder.;
        //Act
        var validator = new RegisterExpenseValidator();
        var result = validator.Validate(request);

        //Assert
        Assert.True(result.IsValid);
    }
}
