using Domain.AccountPlan;
using Domain.Commands;
using Domain.Queries;
using Flurl.Http;
using Responses;
using Responses.Http;
using WebApi;


namespace UnitTest.IntegratedTests;

public class WorkFlowIntegratedTest : AbstractIntegratedTest
{
    public WorkFlowIntegratedTest(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task GetAll()
    {
        var t = await CallHttp("/ChartOfAccounts").GetAsync().ReceiveResult<List<AccountPlanEntity>>();

        Assert.True(t.IsSuccess);
        Assert.NotEmpty(t.Value);
    }

    [Fact]
    public async Task GetHighCategory()
    {
        var t = await CallHttp("/ChartOfAccounts/Categories").GetAsync().ReceiveResult<List<AccountPlanResponse>>();

        Assert.True(t.IsSuccess);
        Assert.NotEmpty(t.Value);
    }


    [Fact]
    public async Task Create()
    {
        var categories = await CallHttp("/ChartOfAccounts/Categories").GetAsync()
            .ReceiveResult<List<AccountPlanResponse>>();

        var objetoAleatorio = GetNextObj(new Random(), categories);

        var result = await CallHttp("/ChartOfAccounts").PostJsonAsync(new CreateAccountPlanCommand
            {
                AcceptLaunches = true,
                AccountType = AccountType.Despesa,
                AccountName = "Teste",
                ParentCode = objetoAleatorio.Code,
                SequenceCode = objetoAleatorio.NextSequencie!
            })
            .ReceiveResult<AccountPlanCreatedResponse>();

        Assert.True(result.IsSuccess);
        Assert.Contains(objetoAleatorio.NextSequencie!,result.Value.Message);
    }


    [Fact]
    public async Task CreateIgnoreSequencie()
    {
        var categories = await CallHttp("/ChartOfAccounts/Categories").GetAsync()
            .ReceiveResult<List<AccountPlanResponse>>();

        var objetoAleatorio = GetNextObj(new Random(), categories);

        var result = await CallHttp("/ChartOfAccounts").PostJsonAsync(new CreateAccountPlanCommand
            {
                AcceptLaunches = true,
                AccountType = AccountType.Despesa,
                AccountName = "Teste",
                ParentCode = objetoAleatorio.Code,
                SequenceCode = $"{objetoAleatorio.Code}.30"
            })
            .ReceiveResult<AccountPlanCreatedResponse>();

        Assert.True(result.IsSuccess);
        Assert.Contains($"{objetoAleatorio.Code}.30", result.Value.Message);
    }
    
    [Fact]
    public async Task CreateIgnoreSequencieWithError()
    {
        var categories = await CallHttp("/ChartOfAccounts/Categories").GetAsync()
            .ReceiveResult<List<AccountPlanResponse>>();

        var objetoAleatorio = GetNextObj(new Random(), categories);

        var result = await CallHttp("/ChartOfAccounts").PostJsonAsync(new CreateAccountPlanCommand
            {
                AcceptLaunches = true,
                AccountType = AccountType.Despesa,
                AccountName = "Teste",
                ParentCode = objetoAleatorio.Code,
                SequenceCode = $"30.2"
            })
            .ReceiveResult<AccountPlanCreatedResponse>();

        Assert.False(result.IsSuccess);
        Assert.True(result.Error.Message == "O codigo informado não pertence a conta pai");
    }

    private static AccountPlanResponse GetNextObj(Random rnd, Result<List<AccountPlanResponse>> categories)
    {
        var objetoAleatorio = categories.Value[rnd.Next(categories.Value.Count)];
        if (objetoAleatorio.Code.Contains("999"))
            objetoAleatorio = GetNextObj(rnd, categories);
        return objetoAleatorio;
    }
}