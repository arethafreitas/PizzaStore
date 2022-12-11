namespace PizzaStore.DB;

public record PizzaSample
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class PizzaDatabase
{
    private static List<PizzaSample> _pizzas = new List<PizzaSample>()
    {
        new PizzaSample{ Id=1, Name="Montemagno, Pizza shaped like a great mountain" },
        new PizzaSample{ Id=2, Name="The Galloway, Pizza shaped like a submarine, silent but deadly"},
        new PizzaSample{ Id=3, Name="The Noring, Pizza shaped like a Viking helmet, where's the mead"}
    };

    public static List<PizzaSample> GetPizzas()
    {
        return _pizzas;
    }

    public static PizzaSample? GetPizza(int id)
    {
        return _pizzas.SingleOrDefault(pizza => pizza.Id == id);
    }

    public static PizzaSample CreatePizza(PizzaSample pizza)
    {
        _pizzas.Add(pizza);
        return pizza;
    }

    public static PizzaSample UpdatePizza(PizzaSample update)
    {
        _pizzas = _pizzas.Select(pizza =>
        {
            if (pizza.Id == update.Id)
            {
                pizza.Name = update.Name;
            }
            return pizza;

        }).ToList();
        return update;
    }

    public static void RemovePizza(int id)
    {
        _pizzas = _pizzas.FindAll(pizza => pizza.Id != id).ToList();
    }
}
