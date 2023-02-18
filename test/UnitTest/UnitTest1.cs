using Domain.AccountPlan;
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
        var list = _list.Where(x => x.Code.Split(".").Length <= 2).ToList();
        foreach (var plans in list)
        {
            var t = PlanoDeConta.GetNextSequence(_list.Select(x => x.Code).ToList(), plans.Code);
            var result = $"Pai: {plans.Code} Filho {t}";
            _testOutputHelper.WriteLine(result);
            Assert.Contains(result, _listReturns);
            _listReturns.Remove(result);
        }

        Assert.False(_listReturns.Count >= 1);
    }

    public static IEnumerable<object[]> ListsCategories() => new PlanoDeConta().Return()
        .Where(x => x.Code.Split(".").Length <= 2).Select(x => new object[] { x.Code });

    [Theory]
    [MemberData(nameof(ListsCategories))]
    public void VerifyCondisions(string codigo)
    {
        var t = PlanoDeConta.GetNextSequence(_list.Select(x => x.Code).ToList(), codigo);
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
                Code = "1", AccountName = "Receitas", AccountType = AccountType.Receita, AceitaLancamentos = false
            },

            new()
            {
                Code = "5", AccountName = "Rendimento de investimentos", AccountType = AccountType.Receita,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "5.999", AccountName = "Rendimento de investimentos", AccountType = AccountType.Receita,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "999", AccountName = "Receitas", AccountType = AccountType.Receita, AceitaLancamentos = false
            },
            new()
            {
                Code = "999.999", AccountName = "Receitas", AccountType = AccountType.Receita, AceitaLancamentos = false
            },
            new()
            {
                Code = "999.999.999", AccountName = "Receitas", AccountType = AccountType.Receita, AceitaLancamentos = false
            },
            new()
            {
                Code = "1.1", AccountName = "Taxa condominial", AccountType = AccountType.Receita, AceitaLancamentos = true
            },
            new()
            {
                Code = "1.2.999", AccountName = "Taxa condominial", AccountType = AccountType.Receita,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "1.999.999", AccountName = "Taxa condominial", AccountType = AccountType.Receita,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "1.2", AccountName = "Reserva de dependência", AccountType = AccountType.Receita,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "1.3", AccountName = "Multas", AccountType = AccountType.Receita, AceitaLancamentos = true
            },
            new()
            {
                Code = "1.4", AccountName = "Juros", AccountType = AccountType.Receita, AceitaLancamentos = true
            },
            new()
            {
                Code = "1.5", AccountName = "Multa condominial", AccountType = AccountType.Receita, AceitaLancamentos = true
            },
            new()
            {
                Code = "1.6", AccountName = "Água", AccountType = AccountType.Receita, AceitaLancamentos = true
            },
            new()
            {
                Code = "1.7", AccountName = "Gás", AccountType = AccountType.Receita, AceitaLancamentos = true
            },
            new()
            {
                Code = "1.8", AccountName = "Luz e energia", AccountType = AccountType.Receita, AceitaLancamentos = true
            },
            new()
            {
                Code = "1.9", AccountName = "Fundo de reserva", AccountType = AccountType.Receita, AceitaLancamentos = true
            },
            new()
            {
                Code = "1.10", AccountName = "Fundo de obras", AccountType = AccountType.Receita, AceitaLancamentos = true
            },
            new()
            {
                Code = "1.11", AccountName = "Correção monetária", AccountType = AccountType.Receita,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "1.12", AccountName = "Transferência entre contas", AccountType = AccountType.Receita,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "1.13", AccountName = "Pagamento duplicado", AccountType = AccountType.Receita,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "1.14", AccountName = "Cobrança", AccountType = AccountType.Receita, AceitaLancamentos = true
            },
            new()
            {
                Code = "1.15", AccountName = "Crédito", AccountType = AccountType.Receita, AceitaLancamentos = true
            },
            new()
            {
                Code = "1.16", AccountName = "Água mineral", AccountType = AccountType.Receita, AceitaLancamentos = true
            },
            new()
            {
                Code = "1.17", AccountName = "Estorno taxa de resgate", AccountType = AccountType.Receita,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "1.18", AccountName = "Acordo", AccountType = AccountType.Receita, AceitaLancamentos = true
            },
            new()
            {
                Code = "1.19", AccountName = "Honorários", AccountType = AccountType.Receita, AceitaLancamentos = true
            },
            new()
            {
                Code = "2", AccountName = "Despesas", AccountType = AccountType.Despesa, AceitaLancamentos = false
            },
            new()
            {
                Code = "2.1", AccountName = "Com pessoal", AccountType = AccountType.Despesa, AceitaLancamentos = false
            },
            new()
            {
                Code = "2.1.1", AccountName = "Salário", AccountType = AccountType.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Code = "2.1.2", AccountName = "Adiantamento salarial", AccountType = AccountType.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "2.1.3", AccountName = "Hora extra", AccountType = AccountType.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Code = "2.1.4", AccountName = "Férias", AccountType = AccountType.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Code = "2.1.5", AccountName = "13º salário", AccountType = AccountType.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Code = "2.1.6", AccountName = "Adiantamento 13º salário", AccountType = AccountType.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "2.1.7", AccountName = "Adicional de função", AccountType = AccountType.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "2.1.8", AccountName = "Aviso prévio", AccountType = AccountType.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Code = "2.1.9", AccountName = "INSS", AccountType = AccountType.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Code = "2.1.10", AccountName = "FGTS", AccountType = AccountType.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Code = "2.1.11", AccountName = "PIS", AccountType = AccountType.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Code = "2.1.12", AccountName = "Vale refeição", AccountType = AccountType.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Code = "2.1.13", AccountName = "Vale transporte", AccountType = AccountType.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Code = "2.1.14", AccountName = "Cesta básica", AccountType = AccountType.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Code = "2.1.15", AccountName = "Acordo trabalhista", AccountType = AccountType.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "2.2", AccountName = "Mensais", AccountType = AccountType.Despesa, AceitaLancamentos = false
            },
            new()
            {
                Code = "2.2.999", AccountName = "Energia elétrica", AccountType = AccountType.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "2.2.2", AccountName = "Água e esgoto", AccountType = AccountType.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Code = "2.2.3", AccountName = "Taxa de administração", AccountType = AccountType.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "2.2.4", AccountName = "Gás", AccountType = AccountType.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Code = "2.2.5", AccountName = "Seguro obrigatório", AccountType = AccountType.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "2.2.6", AccountName = "Telefone", AccountType = AccountType.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Code = "2.2.7", AccountName = "Softwares e aplicativos", AccountType = AccountType.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "2.3", AccountName = "Manutenção", AccountType = AccountType.Despesa, AceitaLancamentos = false
            },
            new()
            {
                Code = "2.3.1", AccountName = "Elevador", AccountType = AccountType.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Code = "2.3.2", AccountName = "Limpeza e conservação", AccountType = AccountType.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "2.3.3", AccountName = "Jardinagem", AccountType = AccountType.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Code = "2.4", AccountName = "Diversas", AccountType = AccountType.Despesa, AceitaLancamentos = false
            },
            new()
            {
                Code = "2.4.1", AccountName = "Honorários de advogado", AccountType = AccountType.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "2.4.2", AccountName = "Xerox", AccountType = AccountType.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Code = "2.4.3", AccountName = "Correios", AccountType = AccountType.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Code = "2.4.4", AccountName = "Despesas judiciais", AccountType = AccountType.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "2.4.5", AccountName = "Multas", AccountType = AccountType.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Code = "2.4.6", AccountName = "Juros", AccountType = AccountType.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Code = "2.4.7", AccountName = "Transferência entre contas", AccountType = AccountType.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "3", AccountName = "Despesas bancárias", AccountType = AccountType.Despesa, AceitaLancamentos = false
            },
            new()
            {
                Code = "3.1", AccountName = "Registro de boletos", AccountType = AccountType.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "3.2", AccountName = "Processamento de boletos", AccountType = AccountType.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "3.3", AccountName = "Registro e processamento de boletos", AccountType = AccountType.Despesa,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "3.4", AccountName = "Resgates", AccountType = AccountType.Despesa, AceitaLancamentos = true
            },
            new()
            {
                Code = "4", AccountName = "Outras receitas", AccountType = AccountType.Receita, AceitaLancamentos = false
            },
            new()
            {
                Code = "4.1", AccountName = "Rendimento de poupança", AccountType = AccountType.Receita,
                AceitaLancamentos = true
            },
            new()
            {
                Code = "4.2", AccountName = "Rendimento de investimentos", AccountType = AccountType.Receita,
                AceitaLancamentos = true
            }
        };
    }
}