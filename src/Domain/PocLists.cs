namespace Domain;

public class PlanoDeConta
{
    public string Codigo { get; set; }
    public string NomeDaConta { get; set; }
    public TipoDeConta Tipo { get; set; }
    public bool AceitaLancamentos { get; set; }

    public static string GetNextSequence(List<string> fullList, string codigo)
    {
        fullList.Sort(new StringNumericOrganizeAccountPlan());
        var children = fullList.Where(x => x.StartsWith(codigo)).Where(x => x == codigo || x.StartsWith(codigo + '.'))
            .ToList();

        if (children.Count == 0) return $"{codigo}";

        if ((children.Any() && children.First() == codigo && children.Count <= 1))
            return $"{codigo}.1";

        var lastChildSplit = children.Last().Split('.');
        var last = int.Parse(lastChildSplit.Last());

        if (MaxValueLastChild(fullList, last, lastChildSplit, out var s)) return s;

        if (codigo.Length != 1 || lastChildSplit.Length != 3) return $"{codigo}.{last + 1}";
        var childrens = children.Where(x => x.Replace(".", "").Length == codigo.Length + 1);
        return $"{codigo}.{int.Parse(childrens.Last().Split('.').Last()) + 1}";
    }

    private static bool MaxValueLastChild(List<string> fullList, int last, IReadOnlyList<string> lastChildSplit,
        out string s)
    {
        if (last != 999)
        {
            s = string.Empty;
            return false;
        }

        if (lastChildSplit.Count != 3)
        {
            s = lastChildSplit[1] == "999"
                ? GetNextSequence(fullList, $"{int.Parse(lastChildSplit[0]) + 1}")
                : GetNextSequence(fullList, lastChildSplit[0]);
            return true;
        }

        s = lastChildSplit[1] == "999"
            ? GetNextSequence(fullList, $"{int.Parse(lastChildSplit[0]) + 1}")
            : GetNextSequence(fullList, lastChildSplit[0]);
        return true;
    }
}