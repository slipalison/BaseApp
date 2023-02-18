using Domain.AccountPlan;
using Domain.Queries;
using Flurl.Http;
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
}