using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

/// <summary>
/// Web Api Actions for Pizza Application
/// </summary>
[Produces("application/json")]
[Consumes("application/json")]
[ApiController]
[Route("api/[controller]")]
public class PizzaController : ControllerBase
{
    /// <summary>
    /// Constructor
    /// </summary>
    public PizzaController(List<Pizza>? pizzas = default)
    {
        if (pizzas is not null) {
            PizzaService.Pizzas = pizzas;
        }       
    }

    /// <summary>
    /// Get all the pizza model objects in memory
    /// </summary>
    /// <returns>(List) of Pizza model objects</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<Pizza>> GetAll()
    {
        return Ok(PizzaService.GetAll());
    }

    /// <summary>
    /// Get one specific pizza given a unique identifier (int)
    /// </summary>
    /// <param name="id">(int) unique identifier of the pizza</param>
    /// <returns>(Pizza) one pizza model object if it exists, not found otherwise</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Pizza> Get(int id) 
    {
        // Validate user inputs
        if (id <= 0)
        {
            return BadRequest();
        }

        // Retrieve the pizza
        Pizza? pizza = PizzaService.Get(id);

        // Validate the pizza exists
        if (pizza == null)
        {
            return NotFound();
        }

        // Return the pizza
        return Ok(pizza);
    }

    /// <summary>
    /// Demo of Custom Error Handling for Get Operation
    /// </summary>
    /// <param name="id">(int) unique identifier of the pizza</param>
    /// <returns>(Pizza) one pizza model object if it exists, not found otherwise</returns>
    [HttpGet("/errorDemo/{id}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<Pizza> GetErrorDemo(int id)
    {
        throw new ArgumentOutOfRangeException("This is a demo of custom error handling development vs production.");
    }

    /// <summary>
    /// Creates a pizza and automatically assigns a unique identifier (int)
    /// </summary>
    /// <param name="pizza">(Pizza) pizza model object</param>
    /// <returns>(Pizza) pizza that was created with the assigned unique identifier (int)</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Create(Pizza pizza)
    {
        // Create the pizza
        PizzaService.Add(pizza);

        // Return the newly created pizza and unique identifier
        return CreatedAtAction(nameof(Get), new {id = pizza.Id}, pizza);
    }

    /// <summary>
    /// Updates a specific pizza given a unique identifier (int), if it exists
    /// </summary>
    /// <param name="id">(int) unique identifier of the pizza</param>
    /// <param name="pizza">(Pizza) pizza to delete</param>
    /// <returns>Status of Update Operation</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Update(int id, Pizza pizza)
    {
        // Validate the user input
        if (id <= 0)
        {
            return BadRequest();
        }

        // Validate the user input
        if (id != pizza.Id)
        {
            return BadRequest();
        }

        // Retrieve the pizza
        Pizza? existingPizza = PizzaService.Get(id);
        
        // Validate the pizza exists
        if (existingPizza is null)
        {
            return NotFound();
        }
            
        // Update the pizza
        PizzaService.Update(pizza);

        // Return successful update status 
        return NoContent();
    }

    /// <summary>
    /// Updates properties of a specific pizza given a unique identifier (int), if it exists
    /// </summary>
    /// <param name="id">(int) unique identifier of the pizza</param>
    /// <param name="pizzaUpdates">(JsonPatchDocument) patch of operations</param>
    /// <returns>Status of Update Operation</returns>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Patch(int id, JsonPatchDocument<Pizza> pizzaUpdates)
    {
        // Validate the user input
        if (id <= 0)
        {
            return BadRequest();
        }

        // Retrieve the pizza
        Pizza? existingPizza = PizzaService.Get(id);

        // Validate the pizza exists
        if (existingPizza is null)
        {  
            return NotFound(); 
        }
        
        // Apply specific updates only to the pizza
        pizzaUpdates.ApplyTo(existingPizza);

        // Update the pizza
        PizzaService.Update(existingPizza);

        // Return successful update status
        return NoContent();
    }

    /// <summary>
    /// Delete a specific pizza given a unique identifier, if it exists
    /// </summary>
    /// <param name="id">(int) identifier of the pizza</param>
    /// <returns>Status of the Delete Operation</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        // Validate the user input
        if (id <= 0)
        {
            return BadRequest();
        }

        // Retrieve the pizza
        Pizza? pizza = PizzaService.Get(id);

        // Validate the pizza exists
        if (pizza is null)
        {
            return NotFound();
        }

        // Delete the pizza
        PizzaService.Delete(id);

        // Return successful delete operation
        return NoContent();
    }

} // end of class
