using Domain.AccountPlan;

namespace Domain.Commands;

public class CreateAccountPlanCommand
{
    public string ParentCode { get; set; } = null!;
    public string SequenceCode { get; set; } = null!;

    public string AccountName { get; set; } = null!;
    public AccountType AccountType { get; set; }
    public bool AcceptLaunches { get; set; }
}