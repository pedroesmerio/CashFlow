using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    #region [POST]
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredExpenseJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
    {
        try
        {
            // Business rules
            var response = new RegisterExpenseUseCase().Execute(request);
            return Created(string.Empty, response);
        }
        catch (ErrorOnValidationException ex)
        {
            var errorResponse = new ResponseErrorJson(ex.Errors);

            return BadRequest(errorResponse);
        }
        catch
        {
            var errorResponse = new ResponseErrorJson("Unknown Error");

            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        }

    }
    #endregion [POST]
}
