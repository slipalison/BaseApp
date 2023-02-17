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
        _list = t.Return();
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
        var list = _list.Where(x => x.Codigo.Split(".").Length <= 2).Select(x => new { x.Codigo, x.NomeDaConta });
        var list2 = _list
            .Select(x => new { Last = x.Codigo.Split(".").Last(), x.Codigo });

       // var list3 = list.Where(x => list2.Select(p => p.Codigo).Contains(x.Codigo));

        var listsCategories = list2.Select(lastValues => lastValues.Codigo.Split("."))
            .Select(itens => (dynamic?)(itens.Length switch
            {
                1 => new { categoria = itens[0] },
                2 => new { categoria = itens[0], subcategoria = itens[1] },
                3 => new { categoria = itens[0], subcategoria = itens[1], item = itens[2] },
                _ => null
            }))
            .Where(categoria => categoria != null).Select(x =>
                ((string Categoria, string Subcategoria, string Item))(x.categoria, x.subcategoria, x.item))
            .ToList();

        foreach (var categoria in list)
        {
            var itens = categoria.Codigo.Split(".");

            (string,string, string) pp = itens.Length switch
            {
                1 => (itens[0], null, null),
                2 => (itens[0], itens[1], null),
                3 => (itens[0], itens[1], itens[2])
            };

            foreach (var lastValues in listsCategories)
            {
                

            }
        }

        return Ok(_list.Where(x => x.Codigo.Split(".").Length <= 2).Select(x => new { x.Codigo, x.NomeDaConta }));
    }
}

public class CreatePlanoDeContaCommand
{
    public string Category { get; set; }
}