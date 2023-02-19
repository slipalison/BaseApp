using Domain.AccountPlan;
using Domain.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Databases.SqlServers.UCondo.Repositories;

public class AccountPlanRepository : IAccountPlanRepository
{
    private readonly UCondoContext _context;

    public AccountPlanRepository(UCondoContext uCondoContext)
    {
        _context = uCondoContext;
    }

    public Task<List<AccountPlanEntity>> GetAll()
    {
        return _context.AccountPlanEntities.ToListAsync();
    }

    public async Task<AccountPlanEntity> Create(AccountPlanEntity accountPlanEntity)
    {
        var ent = await _context.AddAsync(accountPlanEntity);
        await _context.SaveChangesAsync();

        return ent.Entity;
    }

    public Task<bool> ExistsCode(string sequenceCode)
    {
        return _context.AccountPlanEntities.AnyAsync(x => x.Code == sequenceCode);
    }
    
    public Task<bool> ParentCodeNotAcceptLaunches(string parentCode)
    {
        return _context.AccountPlanEntities.AnyAsync(x => x.Code == parentCode && !x.AcceptLaunches );
    }
}