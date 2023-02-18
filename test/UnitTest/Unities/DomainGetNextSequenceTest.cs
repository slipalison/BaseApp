using Domain.AccountPlan;
using UnitTest.Mocks;
using Xunit.Abstractions;

namespace UnitTest.Unities;

public class DomainGetNextSequenceTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly List<AccountPlanEntity> _list;
    private readonly List<string> _listReturns;

    public DomainGetNextSequenceTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _list = new AccountPlanEntity().Return();
        _listReturns = PlanoEx.Retuns();
    }

    [Fact]
    public void Test1()
    {
        var list = _list.Where(x => x.Code.Split(".").Length <= 2).ToList();
        foreach (var result in from plans in list
                    let t = AccountPlanEntity.GetNextSequence(_list.Select(x => x.Code).ToList(), plans.Code)
                    select $"Pai: {plans.Code} Filho {t}")
        {
            _testOutputHelper.WriteLine(result);
            Assert.Contains(result, _listReturns);
            _listReturns.Remove(result);
        }

        Assert.False(_listReturns.Count >= 1);
    }

    public static IEnumerable<object[]> ListsCategories() => new AccountPlanEntity().Return()
        .Where(x => x.Code.Split(".").Length <= 2).Select(x => new object[] { x.Code });

    [Theory]
    [MemberData(nameof(ListsCategories))]
    public void VerifyCondisions(string codigo)
    {
        var t = AccountPlanEntity.GetNextSequence(_list.Select(x => x.Code).ToList(), codigo);
        _testOutputHelper.WriteLine($"Pai: {codigo} Filho {t}");
        var result = $"Pai: {codigo} Filho {t}";
        Assert.Contains(result, _listReturns);
        _listReturns.Remove(result);
    }
    
}