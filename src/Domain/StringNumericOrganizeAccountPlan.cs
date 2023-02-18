namespace Domain;

public class StringNumericOrganizeAccountPlan : IComparer<string>
{
    public int Compare(string x, string y)
    {
        var xSegments = x.Split('.').Select(int.Parse).ToList();
        var ySegments = y.Split('.').Select(int.Parse).ToList();
        var i = 0;

        while (i < xSegments.Count && i < ySegments.Count)
        {
            if (xSegments[i] < ySegments[i])
                return -1;

            if (xSegments[i] > ySegments[i])
                return 1;
            i++;
        }

        if (i < xSegments.Count)
            return 1;

        if (i < ySegments.Count)
            return -1;

        return 0;
    }
}