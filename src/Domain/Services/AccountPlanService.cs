using Domain.AccountPlan;
using Domain.Commands;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Queries;
using Responses;

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
        result.Sort((p1, p2) => OrganizeAccountPlanByCode.Compare(p1.Code, p2.Code));
        return result;
    }

    public async Task<Result<AccountPlanCreatedResponse>> Create(CreateAccountPlanCommand createAccountPlanCommand)
    {
        if (!createAccountPlanCommand.SequenceCode.StartsWith(createAccountPlanCommand.ParentCode))
            return Result.Fail<AccountPlanCreatedResponse>("400", "O codigo informado não pertence a conta pai");

        var exists = await _accountPlanRepository.ExistsCode(createAccountPlanCommand.SequenceCode);
        var newEntity = new AccountPlanEntity
        {
            Code = createAccountPlanCommand.SequenceCode,
            AccountName = createAccountPlanCommand.AccountName,
            AccountType = createAccountPlanCommand.AccountType,
            AcceptLaunches = createAccountPlanCommand.AcceptLaunches
        };
        if (exists)
        {
            var list = await GetAll();
            var next = AccountPlanEntity.GetNextSequence(list.Select(x => x.Code).ToList(),
                createAccountPlanCommand.ParentCode);
            newEntity.Code = next;
        }

        var t = await _accountPlanRepository.Create(newEntity);
        return Result.Ok(new AccountPlanCreatedResponse
        {
            Message = t.Code == createAccountPlanCommand.SequenceCode
                ? $"O codigo criado foi {t.Code}"
                : $"O codigo criado foi {t.Code}, o codígo {createAccountPlanCommand.SequenceCode} já esta em uso"
        });
    }
}