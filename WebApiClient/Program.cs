namespace WebApiClient
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string baseUrl = "https://localhost:7048";

            HttpClient client = new HttpClient();

            ContosoPizzaClient apiClient = new ContosoPizzaClient(baseUrl, client);

            List<Pizza> pizzas = new List<Pizza>();

            pizzas = apiClient.GetAllAsync().Result.ToList();

            foreach (Pizza pizza in pizzas)
            {
                Console.WriteLine(pizza.Name);
            }

            Console.ReadLine();

        }
    }
}
