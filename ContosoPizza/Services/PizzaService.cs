using ContosoPizza.Models;
namespace ContosoPizza.Services;

/// <summary>
/// Service Layer for Pizza CRUD Actions
/// </summary>
public static class PizzaService
{
    /// <summary>
    /// In-memory static list of Pizzas
    /// (mock of database later)
    /// </summary>
    static internal List<Pizza> Pizzas { get; set; }
    
    /// <summary>
    /// Unique Identifier Pointer (int)
    /// (for assignment of new pizza identifiers)
    /// (mock of database layer)
    /// </summary>
    static int nextId = 3;
    
    /// <summary>
    /// Constructor
    /// Creates new static list of pizzas
    /// </summary>
    static PizzaService()
    {
        if(Pizzas is null)
        {
            Pizzas = new List<Pizza>
            {
                new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
                new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
            };
        }       
    }

    /// <summary>
    /// Retrieves all pizzas from in-memory
    /// </summary>
    /// <returns>(List) of Pizza model objects</returns>
    public static List<Pizza> GetAll() => Pizzas;

    /// <summary>
    /// Retrieves one pizza from in-memory
    /// that matches the identifier
    /// </summary>
    /// <param name="id">unique identifier for the pizza (int)</param>
    /// <returns>A single pizza (pizza that matches the identifier)</returns>
    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    /// <summary>
    /// Adds (Creates) a new Pizza model object
    /// to the static list of pizzas
    /// </summary>
    /// <param name="pizza">(Pizza) pizza model object to add</param>
    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    /// <summary>
    /// Deletes a specific pizza with a unique identifier
    /// </summary>
    /// <param name="id">(int) unique identifier of the pizza</param>
    public static void Delete(int id)
    {
        Pizza? pizza = Get(id);
        if (pizza is null)
            return;

        Pizzas.Remove(pizza);
    }

    /// <summary>
    /// Replaces (entire) Pizza model object given
    /// a whole Pizza model object with the same 
    /// unique identifier 
    /// </summary>
    /// <param name="pizza">(Pizza) pizza to replace in the list</param>
    public static void Update(Pizza pizza)
    {
        int index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        
        if (index == -1)
            return;

        Pizzas[index] = pizza;
    }

} // end of class
