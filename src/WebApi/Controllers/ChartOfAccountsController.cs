using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ChartOfAccountsController : ControllerBase
{
    private readonly List<PlanoDeConta> _list;

    public ChartOfAccountsController()
    {
        var t = new PlanoDeConta();
        //_list = t.Return();
    }

    [HttpGet]
    public IActionResult Index()
    {
        return Ok(_list);
    }


    [HttpPost]
    public IActionResult Post([FromBody] PlanoDeConta planoDeConta)
    {
        _list.Add(planoDeConta);
        return Ok(_list);
    }

    [HttpGet("Categories")]
    public IActionResult GetHighCategory()
    {

        return Ok(_list.Where(x => x.Codigo.Split(".").Length <= 2).Select(x => new { x.Codigo, x.NomeDaConta }));
    }
}
