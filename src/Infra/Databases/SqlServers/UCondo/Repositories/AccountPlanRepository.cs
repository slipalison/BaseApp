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
}