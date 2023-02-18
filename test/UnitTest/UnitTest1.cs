using Domain;

namespace UnitTest;

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

public class UnitTest1
{
    private readonly List<PlanoDeConta> _list;

    public UnitTest1()
    {
        _list = new PlanoDeConta().Return();
    }

    [Fact]
    public void Test1()
    {
        var list = _list.Where(x => x.Codigo.Split(".").Length <= 2).Select(x => new { x.Codigo, x.NomeDaConta });
        foreach (var plans in list)
        {
            //var t = ProximoTopico(_list.Select(x => x.Codigo).ToList(), plans.Codigo);
            var t = GetNextSequence(_list.Select(x => x.Codigo).ToList(), plans.Codigo);
            // var t = ProximoTopico( plans.Codigo, _list.Select(x => x.Codigo).ToList());
            //var t = ProximoItem( plans.Codigo, _list.Select(x => x.Codigo).ToList());

            Console.WriteLine($"Pai: {plans.Codigo} Filho {t}");
        }
    }

    public static string GetNextSequence(List<string> list, string parent)
    {
        list.Sort(new StringNumericOrganizeAccountPlan());
        var children = list.Where(x => x.StartsWith(parent)).ToList();

        if (children.Count == 0)
        {
            // Se não houver filhos, o próximo número da sequência é o primeiro
            return $"{parent}.1";
        }

        var lastChild = children.Last();

        if (lastChild == $"{parent}.999")
        {
            // Se o último filho já for 999, não há sequência disponível
            throw new Exception("Não há sequência disponível");
        }

        if (list.Contains($"{parent}.{Int32.Parse(lastChild.Split('.').Last()) + 1}"))
        {
            // Se o próximo número já existe na lista, encontra o próximo valor disponível
            for (int i = Int32.Parse(lastChild.Split('.').Last()) + 1; i <= 999; i++)
            {
                if (!list.Contains($"{parent}.{i}"))
                {
                    return $"{parent}.{i}";
                }
            }

            throw new Exception("Não há sequência disponível");
        }

        var t = lastChild.Split('.');
        if (t.Length == 2 && parent.Split('.').Length == 2)
        {
            //return $"{parent}.{Int32.Parse(lastChild.Split('.').Last()) + 1}";
            return $"{parent}.{1}";
        }

        if (parent.Length == 1 && lastChild.Split('.').Length == 3)
        {
            var childrens = children.Where(x => x.Replace(".", "").Length == parent.Length + 1);
            return $"{parent}.{Int32.Parse(childrens.Last().Split('.').Last()) + 1}";
        }

        // Caso contrário, o próximo número da sequência é o próximo número
        return $"{parent}.{Int32.Parse(lastChild.Split('.').Last()) + 1}";
    }
}