using Domain.AccountPlan;
using Domain.Contracts.Services;
using Domain.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ChartOfAccountsController : ControllerBase
{
    private readonly IAccountPlanService _accountPlanService;

    public ChartOfAccountsController(IAccountPlanService accountPlanService)
    {
        _accountPlanService = accountPlanService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AccountPlanEntity>>> GetAll()
    {
        var list = await _accountPlanService.GetAll();
        return Ok(list);
    }


    [HttpPost]
    public IActionResult Post([FromBody] AccountPlanEntity accountPlanEntity)
    {
        return Ok();
    }

    [HttpGet("Categories")]
    public async Task<ActionResult<IEnumerable<AccountPlanResponse>>> GetHighCategory()
    {
        var list = await _accountPlanService.GetCategoryAndSub();
        return Ok(list);
    }
}