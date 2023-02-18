using Domain.AccountPlan;
using Flurl.Http;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Responses.Http;
using Program = WebApi.Program;

namespace UnitTest.IntegratedTests;

public class WorkFlowIntegratedTest : AbstractIntegratedTest
{
    public WorkFlowIntegratedTest(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task GetAll()
    {
        var t = await "/ChartOfAccounts".WithClient(Client).AllowAnyHttpStatus().GetAsync().ReceiveResult<List<AccountPlanEntity>>();

        Assert.True(t.IsSuccess);
        Assert.NotEmpty(t.Value);
    }
}