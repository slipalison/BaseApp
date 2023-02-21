using Domain.AccountPlan;

namespace Domain.Contracts.Repositories;

public interface IAccountPlanRepository
{
    Task<List<AccountPlanEntity>> GetAll();

    Task<AccountPlanEntity> Create(AccountPlanEntity accountPlanEntity);
    Task<bool> ExistsCode(string sequenceCode);
    Task<bool> ParentCodeNotAcceptLaunches(string parentCode, AccountType accountType);

    Task<bool> ParentCodeNotAcceptLaunches(string parentCode);
}