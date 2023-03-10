namespace Domain.Queries;

public class AccountPlanResponse
{
    public string Code { get; set; }
    public string AccountName { get; set; }
    public string? NextSequencie { get; set; }
}

public class AccountPlanCreatedResponse
{
    public string Message { get; set; }
}