using Domain.AccountPlan;
using Domain.Commands;
using Domain.Contracts.Services;
using Domain.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ChartOfAccountsController : ControllerBase
{
    private readonly IAccountPlanService _accountPlanService;
    private readonly ILogger<ChartOfAccountsController> _logger;

    public ChartOfAccountsController(IAccountPlanService accountPlanService, ILogger<ChartOfAccountsController> logger)
    {
        _logger = logger;
        _accountPlanService = accountPlanService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AccountPlanEntity>>> GetAll()
    {
        var list = await _accountPlanService.GetAll();
        return Ok(list);
    }


    [HttpPost]
    public async Task<ActionResult<IEnumerable<AccountPlanCreatedResponse>>> Post(
        [FromBody] CreateAccountPlanCommand createAccountPlanCommand)
    {
        var list = await _accountPlanService.Create(createAccountPlanCommand);
        if (!list.IsSuccess)
        {
            _logger.LogWarning("Erro ao criar a conta {@Error}", list.Error);
            return BadRequest(list.Error);
        }

        _logger.LogInformation("Conta criada com sucesso: {Message}", list.Value.Message);
        return Ok(list.Value);
    }

    [HttpGet("Categories")]
    public async Task<ActionResult<IEnumerable<AccountPlanResponse>>> GetHighCategory()
    {
        var list = await _accountPlanService.GetCategoryAndSub();
        return Ok(list);
    }
}