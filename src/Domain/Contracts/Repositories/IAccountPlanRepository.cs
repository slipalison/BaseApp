using Domain.AccountPlan;

namespace Domain.Contracts.Repositories;

public interface IAccountPlanRepository
{
    Task<List<AccountPlanEntity>> GetAll();

}