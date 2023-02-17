namespace Domain;

public class PlanoDeConta
{
    public string Codigo { get; set; }
    public string NomeDaConta { get; set; }
    public TipoDeConta Tipo { get; set; }
    public bool AceitaLancamentos { get; set; }
}

public static class PlanoEx
{
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
                Codigo = "1.1", NomeDaConta = "Taxa condominial", Tipo = TipoDeConta.Receita, AceitaLancamentos = true
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
                Codigo = "2.2.1", NomeDaConta = "Energia elétrica", Tipo = TipoDeConta.Despesa, AceitaLancamentos = true
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