using Domain.AccountPlan;
using Domain.Commands;
using Domain.Queries;
using Responses;

namespace Domain.Contracts.Services;

public interface IAccountPlanService
{
    Task<List<AccountPlanEntity>> GetAll();
    Task<List<AccountPlanResponse>> GetCategoryAndSub();
    Task<Result<AccountPlanCreatedResponse>> Create(CreateAccountPlanCommand createAccountPlanCommand);
}