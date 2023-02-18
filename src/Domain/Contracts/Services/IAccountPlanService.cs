using Domain.AccountPlan;
using Domain.Queries;

namespace Domain.Contracts.Services;

public interface IAccountPlanService
{
    Task<List<AccountPlanEntity>> GetAll();
    Task<List<AccountPlanResponse>> GetCategoryAndSub();
}