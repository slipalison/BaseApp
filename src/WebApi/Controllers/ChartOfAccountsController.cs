using Domain.AccountPlan;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ChartOfAccountsController : ControllerBase
{
    private readonly List<AccountPlanEntity> _list;

    public ChartOfAccountsController()
    {
        var t = new AccountPlanEntity();
    }

    [HttpGet]
    public IActionResult Index()
    {
        return Ok(_list);
    }


    [HttpPost]
    public IActionResult Post([FromBody] AccountPlanEntity accountPlanEntity)
    {
        _list.Add(accountPlanEntity);
        return Ok(_list);
    }

    [HttpGet("Categories")]
    public IActionResult GetHighCategory()
    {

        return Ok(_list.Where(x => x.Code.Split(".").Length <= 2).Select(x => new { Code = x.Code, AccountName = x.AccountName }));
    }
}
