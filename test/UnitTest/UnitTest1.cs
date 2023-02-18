using Domain;
using Xunit.Abstractions;

namespace UnitTest;

public class UnitTest1
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly List<PlanoDeConta> _list;
    private readonly List<string> _listReturns;

    public UnitTest1(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _list = new PlanoDeConta().Return();
        _listReturns = PlanoEx.Retuns();
    }

    [Fact]
    public void Test1()
    {
        var list = _list.Where(x => x.Codigo.Split(".").Length <= 2).ToList();
        foreach (var plans in list)
        {
            var t = PlanoDeConta.GetNextSequence(_list.Select(x => x.Codigo).ToList(), plans.Codigo);
            var result = $"Pai: {plans.Codigo} Filho {t}";
            _testOutputHelper.WriteLine(result);
            Assert.Contains(result, _listReturns);
            _listReturns.Remove(result);
        }

        Assert.False(_listReturns.Count >= 1);
    }

    public static IEnumerable<object[]> ListsCategories() => new PlanoDeConta().Return()
        .Where(x => x.Codigo.Split(".").Length <= 2).Select(x => new object[] { x.Codigo });

    [Theory]
    [MemberData(nameof(ListsCategories))]
    public void VerifyCondisions(string codigo)
    {
        var t = PlanoDeConta.GetNextSequence(_list.Select(x => x.Codigo).ToList(), codigo);
        _testOutputHelper.WriteLine($"Pai: {codigo} Filho {t}");
        var result = $"Pai: {codigo} Filho {t}";
        Assert.Contains(result, _listReturns);
        _listReturns.Remove(result);
    }
}

public static class PlanoEx
{
    public static List<string> Retuns()
    {
        return new List<string>()
        {
            "Pai: 1 Filho 2.5", "Pai: 5 Filho 6", "Pai: 5.999 Filho 5.999.1", "Pai: 999 Filho 1000",
            "Pai: 1.1 Filho 1.1.1", "Pai: 1.2 Filho 2.5", "Pai: 1.3 Filho 1.3.1",
            "Pai: 1.4 Filho 1.4.1", "Pai: 1.5 Filho 1.5.1", "Pai: 1.6 Filho 1.6.1", "Pai: 1.7 Filho 1.7.1",
            "Pai: 1.8 Filho 1.8.1", "Pai: 1.9 Filho 1.9.1", "Pai: 1.10 Filho 1.10.1", "Pai: 1.11 Filho 1.11.1",
            "Pai: 1.12 Filho 1.12.1", "Pai: 1.13 Filho 1.13.1", "Pai: 1.14 Filho 1.14.1", "Pai: 1.15 Filho 1.15.1",
            "Pai: 1.16 Filho 1.16.1", "Pai: 1.17 Filho 1.17.1", "Pai: 1.18 Filho 1.18.1", "Pai: 1.19 Filho 1.19.1",
            "Pai: 2 Filho 2.5", "Pai: 2.1 Filho 2.1.16", "Pai: 2.2 Filho 2.5", "Pai: 2.3 Filho 2.3.4",
            "Pai: 2.4 Filho 2.4.8", "Pai: 3 Filho 3.5", "Pai: 3.1 Filho 3.1.1", "Pai: 3.2 Filho 3.2.1",
            "Pai: 3.3 Filho 3.3.1", "Pai: 3.4 Filho 3.4.1", "Pai: 4 Filho 4.3", "Pai: 4.1 Filho 4.1.1",
            "Pai: 4.2 Filho 4.2.1", "Pai: 999.999 Filho 1000"
        };
    }

    public static List<PlanoDeConta> Return(this PlanoDeConta planoDeConta)
    {
        return new List<PlanoDeConta>()
        {
            new()
            {
                Codigo = "1", NomeDaConta = "Receitas", Tipo = TipoDeConta.Receita, AceitaLancamentos = false
            },

            new()
            {
                Codigo = "5", NomeDaConta = "Rendimento de investimentos", Tipo = TipoDeConta.Receita,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "5.999", NomeDaConta = "Rendimento de investimentos", Tipo = TipoDeConta.Receita,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "999", NomeDaConta = "Receitas", Tipo = TipoDeConta.Receita, AceitaLancamentos = false
            },
            new()
            {
                Codigo = "999.999", NomeDaConta = "Receitas", Tipo = TipoDeConta.Receita, AceitaLancamentos = false
            },
            new()
            {
                Codigo = "999.999.999", NomeDaConta = "Receitas", Tipo = TipoDeConta.Receita, AceitaLancamentos = false
            },
            new()
            {
                Codigo = "1.1", NomeDaConta = "Taxa condominial", Tipo = TipoDeConta.Receita, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "1.2.999", NomeDaConta = "Taxa condominial", Tipo = TipoDeConta.Receita,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "1.999.999", NomeDaConta = "Taxa condominial", Tipo = TipoDeConta.Receita,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "1.2", NomeDaConta = "Reserva de dependência", Tipo = TipoDeConta.Receita,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "1.3", NomeDaConta = "Multas", Tipo = TipoDeConta.Receita, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "1.4", NomeDaConta = "Juros", Tipo = TipoDeConta.Receita, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "1.5", NomeDaConta = "Multa condominial", Tipo = TipoDeConta.Receita, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "1.6", NomeDaConta = "Água", Tipo = TipoDeConta.Receita, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "1.7", NomeDaConta = "Gás", Tipo = TipoDeConta.Receita, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "1.8", NomeDaConta = "Luz e energia", Tipo = TipoDeConta.Receita, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "1.9", NomeDaConta = "Fundo de reserva", Tipo = TipoDeConta.Receita, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "1.10", NomeDaConta = "Fundo de obras", Tipo = TipoDeConta.Receita, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "1.11", NomeDaConta = "Correção monetária", Tipo = TipoDeConta.Receita,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "1.12", NomeDaConta = "Transferência entre contas", Tipo = TipoDeConta.Receita,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "1.13", NomeDaConta = "Pagamento duplicado", Tipo = TipoDeConta.Receita,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "1.14", NomeDaConta = "Cobrança", Tipo = TipoDeConta.Receita, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "1.15", NomeDaConta = "Crédito", Tipo = TipoDeConta.Receita, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "1.16", NomeDaConta = "Água mineral", Tipo = TipoDeConta.Receita, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "1.17", NomeDaConta = "Estorno taxa de resgate", Tipo = TipoDeConta.Receita,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "1.18", NomeDaConta = "Acordo", Tipo = TipoDeConta.Receita, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "1.19", NomeDaConta = "Honorários", Tipo = TipoDeConta.Receita, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2", NomeDaConta = "Despesas", Tipo = TipoDeConta.Despesa, AceitaLancamentos = false
            },
            new()
            {
                Codigo = "2.1", NomeDaConta = "Com pessoal", Tipo = TipoDeConta.Despesa, AceitaLancamentos = false
            },
            new()
            {
                Codigo = "2.1.1", NomeDaConta = "Salário", Tipo = TipoDeConta.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.1.2", NomeDaConta = "Adiantamento salarial", Tipo = TipoDeConta.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.1.3", NomeDaConta = "Hora extra", Tipo = TipoDeConta.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.1.4", NomeDaConta = "Férias", Tipo = TipoDeConta.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.1.5", NomeDaConta = "13º salário", Tipo = TipoDeConta.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.1.6", NomeDaConta = "Adiantamento 13º salário", Tipo = TipoDeConta.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.1.7", NomeDaConta = "Adicional de função", Tipo = TipoDeConta.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.1.8", NomeDaConta = "Aviso prévio", Tipo = TipoDeConta.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.1.9", NomeDaConta = "INSS", Tipo = TipoDeConta.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.1.10", NomeDaConta = "FGTS", Tipo = TipoDeConta.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.1.11", NomeDaConta = "PIS", Tipo = TipoDeConta.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.1.12", NomeDaConta = "Vale refeição", Tipo = TipoDeConta.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.1.13", NomeDaConta = "Vale transporte", Tipo = TipoDeConta.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.1.14", NomeDaConta = "Cesta básica", Tipo = TipoDeConta.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.1.15", NomeDaConta = "Acordo trabalhista", Tipo = TipoDeConta.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.2", NomeDaConta = "Mensais", Tipo = TipoDeConta.Despesa, AceitaLancamentos = false
            },
            new()
            {
                Codigo = "2.2.999", NomeDaConta = "Energia elétrica", Tipo = TipoDeConta.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.2.2", NomeDaConta = "Água e esgoto", Tipo = TipoDeConta.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.2.3", NomeDaConta = "Taxa de administração", Tipo = TipoDeConta.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.2.4", NomeDaConta = "Gás", Tipo = TipoDeConta.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.2.5", NomeDaConta = "Seguro obrigatório", Tipo = TipoDeConta.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.2.6", NomeDaConta = "Telefone", Tipo = TipoDeConta.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.2.7", NomeDaConta = "Softwares e aplicativos", Tipo = TipoDeConta.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.3", NomeDaConta = "Manutenção", Tipo = TipoDeConta.Despesa, AceitaLancamentos = false
            },
            new()
            {
                Codigo = "2.3.1", NomeDaConta = "Elevador", Tipo = TipoDeConta.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.3.2", NomeDaConta = "Limpeza e conservação", Tipo = TipoDeConta.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.3.3", NomeDaConta = "Jardinagem", Tipo = TipoDeConta.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.4", NomeDaConta = "Diversas", Tipo = TipoDeConta.Despesa, AceitaLancamentos = false
            },
            new()
            {
                Codigo = "2.4.1", NomeDaConta = "Honorários de advogado", Tipo = TipoDeConta.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.4.2", NomeDaConta = "Xerox", Tipo = TipoDeConta.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.4.3", NomeDaConta = "Correios", Tipo = TipoDeConta.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.4.4", NomeDaConta = "Despesas judiciais", Tipo = TipoDeConta.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.4.5", NomeDaConta = "Multas", Tipo = TipoDeConta.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.4.6", NomeDaConta = "Juros", Tipo = TipoDeConta.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "2.4.7", NomeDaConta = "Transferência entre contas", Tipo = TipoDeConta.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "3", NomeDaConta = "Despesas bancárias", Tipo = TipoDeConta.Despesa, AceitaLancamentos = false
            },
            new()
            {
                Codigo = "3.1", NomeDaConta = "Registro de boletos", Tipo = TipoDeConta.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "3.2", NomeDaConta = "Processamento de boletos", Tipo = TipoDeConta.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "3.3", NomeDaConta = "Registro e processamento de boletos", Tipo = TipoDeConta.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "3.4", NomeDaConta = "Resgates", Tipo = TipoDeConta.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Codigo = "4", NomeDaConta = "Outras receitas", Tipo = TipoDeConta.Receita, AceitaLancamentos = false
            },
            new()
            {
                Codigo = "4.1", NomeDaConta = "Rendimento de poupança", Tipo = TipoDeConta.Receita,
                AceitaLancamentos = true
            },
            new()
            {
                Codigo = "4.2", NomeDaConta = "Rendimento de investimentos", Tipo = TipoDeConta.Receita,
                AceitaLancamentos = true
            }
        };
    }
}