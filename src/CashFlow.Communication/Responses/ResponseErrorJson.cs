namespace CashFlow.Communication.Responses;

public class ResponseErrorJson
{
    public List<string> Errors { get; set; } = [];

    public ResponseErrorJson(string errors)
    {
        Errors = new List<string>([errors]);
    }
}
