namespace CashFlow.Communication.Responses;

public class ResponseRegisteredExpenseJson
{
    public bool SyncStatus { get; set; }
    public string Title { get; set; } = string.Empty;
}
