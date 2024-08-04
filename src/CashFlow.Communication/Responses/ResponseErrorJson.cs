namespace CashFlow.Communication.Responses;

public class ResponseErrorJson
{
    public List<string> ErrorMessages { get; set; } = [];

    public ResponseErrorJson(string error)
    {
        ErrorMessages = [error];
    }

    public ResponseErrorJson(List<string> errors)
    {
        ErrorMessages = errors;
    }
}
