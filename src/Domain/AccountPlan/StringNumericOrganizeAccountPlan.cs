namespace Domain.AccountPlan;

public class StringNumericOrganizeAccountPlan : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        var xSegments = x!.Split('.').Select(int.Parse).ToList();
        var ySegments = y!.Split('.').Select(int.Parse).ToList();

        var i = 0;
        while (i < xSegments.Count && i < ySegments.Count)
        {
            if (xSegments[i] < ySegments[i]) return -1;
            if (xSegments[i] > ySegments[i]) return 1;
            i++;
        }

        if (i < xSegments.Count) return 1;
        // if (i < ySegments.Count) return -1;
        return -1;
        // default return 0;
    }
}

public static class OrganizeAccountPlanByCode
{
    public static int Compare(string? x, string? y)
    {
        return new StringNumericOrganizeAccountPlan().Compare(x, y);
    }
}