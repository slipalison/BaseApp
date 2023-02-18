using Domain.AccountPlan;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Queries;

namespace Domain.Services;

public class AccountPlanService : IAccountPlanService
{
    private readonly IAccountPlanRepository _accountPlanRepository;

    public AccountPlanService(IAccountPlanRepository accountPlanRepository)
    {
        _accountPlanRepository = accountPlanRepository;
    }

    public async Task<List<AccountPlanEntity>> GetAll()
    {
        var list = await _accountPlanRepository.GetAll();
        list.Sort((p1, p2) => OrganizeAccountPlanByCode.Compare(p1.Code, p2.Code));
        return list;
    }

    public async Task<List<AccountPlanResponse>> GetCategoryAndSub()
    {
        var list = await _accountPlanRepository.GetAll();
        list = list.Where(x => x.Code.Split(".").Length <= 2).ToList();

        var codes = list.Select(x => x.Code).ToList();
        var result = list.Select(x => new AccountPlanResponse
        {
            Code = x.Code,
            AccountName = x.AccountName,
            NextSequencie = AccountPlanEntity.GetNextSequence(codes, x.Code)
        }).ToList();

        return result;
    }
}