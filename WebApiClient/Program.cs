using PizzaApiClient;

namespace WebApiClient
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            PizzaApiClient.PizzaApiClient client = new PizzaApiClient.PizzaApiClient("https://localhost:7048", httpClient);

            // Get Pizzas
            IEnumerable<Pizza> pizzas = await client.GetAllAsync();

            foreach (Pizza pizza in pizzas)
            {
                Console.WriteLine($"Pizza Id: {pizza.Id} Pizza Name: {pizza.Name}");
            }

            Console.ReadLine();

        }
    }
}