using ContosoPizza.Controllers;
using ContosoPizza.Models;
using FakeItEasy;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ContosoPizza.Tests.Controllers
{
    public class PizzaControllerTests
    {
        [Fact]
        public void GetAll_Returns_ValidCount()
        {
            // Arrange

            List<Pizza> pizzas = A.CollectionOfDummy<Pizza>(10).ToList();
            PizzaController? pizzaController = new PizzaController(pizzas);

            // Act

            ActionResult<List<Pizza>> actionResult = pizzaController.GetAll();

            // Assert

            OkObjectResult? result = actionResult.Result as OkObjectResult;
            List<Pizza>? returnPizzas = result?.Value as List<Pizza>;
            Assert.Equal(pizzas.Count, returnPizzas?.Count);
        }

        [Fact]
        public void Get_Valid_Id_Returns_ExpectedPizza()
        {
            // Arrange

            List<Pizza> pizzas = A.CollectionOfDummy<Pizza>(10).ToList();
            Pizza? testPizza = pizzas.FirstOrDefault();
            testPizza!.Id = 10;
            PizzaController? pizzaController = new PizzaController(pizzas);

            // Act

            ActionResult<Pizza> actionResult = pizzaController.Get(testPizza!.Id);

            // Assert

            OkObjectResult? result = actionResult.Result as OkObjectResult;
            Pizza? returnPizza = result?.Value as Pizza;
            Assert.Equal(testPizza!.Id, returnPizza?.Id);
        }

        [Fact]
        public void Get_NonExisting_Id_Returns_Status_NotFound()
        {
            // Arrange

            List<Pizza> pizzas = A.CollectionOfDummy<Pizza>(10).ToList();
            Pizza? testPizza = pizzas.FirstOrDefault();
            testPizza!.Id = 10;
            PizzaController? pizzaController = new PizzaController(pizzas);

            // Act

            ActionResult<Pizza> actionResult = pizzaController.Get(300);

            // Assert

            IStatusCodeActionResult? result = actionResult.Result as IStatusCodeActionResult;
            Assert.Equal(404, result?.StatusCode);
        }

        [Fact]
        public void Get_Invalid_Id_Returns_Status_BadRequest()
        {
            // Arrange

            List<Pizza> pizzas = A.CollectionOfDummy<Pizza>(10).ToList();
            Pizza? testPizza = pizzas.FirstOrDefault();
            testPizza!.Id = 10;
            PizzaController? pizzaController = new PizzaController(pizzas);

            // Act

            ActionResult<Pizza> actionResult = pizzaController.Get(0);

            // Assert

            IStatusCodeActionResult? result = actionResult.Result as IStatusCodeActionResult;
            Assert.Equal(400, result?.StatusCode);
        }

        [Fact]
        public void GetErrorDemo_ThrowsException_ArgumentOutOfRangeException()
        {
            // Arrange

            List<Pizza> pizzas = A.CollectionOfDummy<Pizza>(10).ToList();
            Pizza? testPizza = pizzas.FirstOrDefault();
            testPizza!.Id = 10;
            testPizza.Name = "pineapple";
            PizzaController? pizzaController = new PizzaController(pizzas);

            Pizza pizzaGet = new Pizza()
            {
                Id = 0, // Invalid Id
                Name = testPizza.Name + "sausage",
                IsGlutenFree = false
            };

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => pizzaController.GetErrorDemo(pizzaGet.Id));
        }

        [Fact]
        public void Create_Returns_ExpectedPizza_Verify_IndexesCorrectly()
        {
            // Arrange

            List<Pizza> pizzas = A.CollectionOfDummy<Pizza>(10).ToList();
            PizzaController? pizzaController = new PizzaController(pizzas);
            
            Pizza pizza1 = new Pizza () 
            { 
                IsGlutenFree = true, 
                Name = "Test1" 
            };

            Pizza pizza2 = new Pizza()
            {
                IsGlutenFree = false,
                Name = "Test2"
            };

            // Act

            IActionResult actionResult1 = pizzaController.Create(pizza1);
            IActionResult actionResult2 = pizzaController.Create(pizza2);

            // Assert

            CreatedAtActionResult? result1 = actionResult1 as CreatedAtActionResult;
            Pizza? returnPizza1 = result1?.Value as Pizza;

            Assert.Equal(pizza1.Name, returnPizza1?.Name);
            Assert.Equal(pizza1.IsGlutenFree, returnPizza1?.IsGlutenFree);
            Assert.True(returnPizza1?.Id != 0);

            CreatedAtActionResult? result2 = actionResult2 as CreatedAtActionResult;
            Pizza? returnPizza2 = result2?.Value as Pizza;

            Assert.Equal(pizza2.Name, returnPizza2?.Name);
            Assert.Equal(pizza2.IsGlutenFree, returnPizza2?.IsGlutenFree);
            Assert.True(returnPizza2?.Id != 0);

            // Verify Indexing Works on Creation
            Assert.True(returnPizza2?.Id == returnPizza1?.Id + 1);
        }

        [Fact]
        public void Update_Valid_Id_Returns_SuccessNoContent_Verify_UpdateSuccessful()
        {
            // Arrange

            List<Pizza> pizzas = A.CollectionOfDummy<Pizza>(10).ToList();
            Pizza? testPizza = pizzas.FirstOrDefault();
            testPizza!.Id = 10;
            testPizza.Name = "pineapple";
            PizzaController? pizzaController = new PizzaController(pizzas);

            Pizza pizzaUpdate = new Pizza()
            {
                Id = testPizza.Id,
                Name = testPizza.Name + "sausage",
                IsGlutenFree = false
            };
            
            // Act

            // Update the Pizza
            IActionResult actionResult = pizzaController.Update(pizzaUpdate.Id, pizzaUpdate);

            // Assert Content Created
            IStatusCodeActionResult? result = actionResult as IStatusCodeActionResult;
            Assert.Equal(204, result?.StatusCode);

            // Act - Retrieve the Same Pizza
            ActionResult<Pizza> actionResult2 = pizzaController.Get(pizzaUpdate.Id);

            // Assert Pizza was Updated 

            OkObjectResult? result2 = actionResult2.Result as OkObjectResult;
            Pizza? returnPizza = result2?.Value as Pizza;            
            Assert.Equal(pizzaUpdate.Name, returnPizza?.Name);
            Assert.Equal(pizzaUpdate.IsGlutenFree, returnPizza?.IsGlutenFree);

        }

        [Fact]
        public void Update_NonExisting_Id_Returns_Status_NotFound()
        {
            // Arrange

            List<Pizza> pizzas = A.CollectionOfDummy<Pizza>(10).ToList();
            Pizza? testPizza = pizzas.FirstOrDefault();
            testPizza!.Id = 10;
            testPizza.Name = "pineapple";
            PizzaController? pizzaController = new PizzaController(pizzas);

            Pizza pizzaUpdate = new Pizza()
            {
                Id = 100,
                Name = testPizza.Name + "sausage",
                IsGlutenFree = false
            };

            // Act

            // Update the Pizza
            IActionResult actionResult = pizzaController.Update(pizzaUpdate.Id, pizzaUpdate);

            // Assert

            IStatusCodeActionResult? result = actionResult as IStatusCodeActionResult;
            Assert.Equal(404, result?.StatusCode);
        }

        [Fact]
        public void Update_Invalid_Id_Returns_Status_BadRequest()
        {
            // Arrange

            List<Pizza> pizzas = A.CollectionOfDummy<Pizza>(10).ToList();
            Pizza? testPizza = pizzas.FirstOrDefault();
            testPizza!.Id = 10;
            testPizza.Name = "pineapple";
            PizzaController? pizzaController = new PizzaController(pizzas);

            Pizza pizzaUpdate = new Pizza()
            {
                Id = 0,
                Name = testPizza.Name + "sausage",
                IsGlutenFree = false
            };

            // Act

            // Update the Pizza
            IActionResult actionResult = pizzaController.Update(pizzaUpdate.Id, pizzaUpdate);

            // Assert

            IStatusCodeActionResult? result = actionResult as IStatusCodeActionResult;
            Assert.Equal(400, result?.StatusCode);

        }

        [Fact]
        public void Update_Mismatch_Id_Returns_Status_BadRequest()
        {
            // Arrange

            List<Pizza> pizzas = A.CollectionOfDummy<Pizza>(10).ToList();
            Pizza? testPizza = pizzas.FirstOrDefault();
            testPizza!.Id = 10;
            testPizza.Name = "pineapple";
            PizzaController? pizzaController = new PizzaController(pizzas);

            Pizza pizzaUpdate = new Pizza()
            {
                Id = 100,
                Name = testPizza.Name + "sausage",
                IsGlutenFree = false
            };

            // Act

            // Update the Pizza
            IActionResult actionResult = pizzaController.Update(pizzaUpdate.Id+1, pizzaUpdate);

            // Assert

            IStatusCodeActionResult? result = actionResult as IStatusCodeActionResult;
            Assert.Equal(400, result?.StatusCode);

        }

        [Fact]
        public void Patch_Valid_Id_Returns_SuccessNoContent_Verify_UpdateSuccessful()
        {
            // Arrange

            List<Pizza> pizzas = A.CollectionOfDummy<Pizza>(10).ToList();
            Pizza? testPizza = pizzas.FirstOrDefault();
            testPizza!.Id = 10;
            testPizza.Name = "pineapple";
            PizzaController? pizzaController = new PizzaController(pizzas);

            Pizza pizzaUpdate = new Pizza()
            {
                Id = testPizza.Id,
                Name = testPizza.Name + "sausage",
                IsGlutenFree = false
            };

            JsonPatchDocument<Pizza> patch = new JsonPatchDocument<Pizza>();
            patch.Replace(x => x.Name,  pizzaUpdate.Name);
            patch.Replace(x => x.IsGlutenFree, pizzaUpdate.IsGlutenFree);

            // Act

            // Patch the Pizza
            IActionResult actionResult = pizzaController.Patch(pizzaUpdate.Id, patch);

            // Assert Successful No Content

            IStatusCodeActionResult? result = actionResult as IStatusCodeActionResult;
           
            Assert.Equal(204, result?.StatusCode);

            // Act - Retrieve the Same Pizza (To verify it was actually patched)
            ActionResult<Pizza> actionResult2 = pizzaController.Get(pizzaUpdate.Id);

            // Assert Pizza was updated with patched values
            OkObjectResult? result2 = actionResult2.Result as OkObjectResult;
            Pizza? returnPizza = result2?.Value as Pizza;     
            Assert.Equal(pizzaUpdate.Name, returnPizza?.Name);
            Assert.Equal(pizzaUpdate.IsGlutenFree, returnPizza?.IsGlutenFree);

        }

        [Fact]
        public void Patch_NonExisting_Id_Returns_Status_NotFound()
        {
            // Arrange

            List<Pizza> pizzas = A.CollectionOfDummy<Pizza>(10).ToList();
            Pizza? testPizza = pizzas.FirstOrDefault();
            testPizza!.Id = 10;
            testPizza.Name = "pineapple";
            PizzaController? pizzaController = new PizzaController(pizzas);

            Pizza pizzaUpdate = new Pizza()
            {
                Id = 100,
                Name = testPizza.Name + "sausage",
                IsGlutenFree = false
            };

            JsonPatchDocument<Pizza> patch = new JsonPatchDocument<Pizza>();
            patch.Replace(x => x.Name, pizzaUpdate.Name);
            patch.Replace(x => x.IsGlutenFree, pizzaUpdate.IsGlutenFree);

            // Act

            // Patch the Pizza
            IActionResult actionResult = pizzaController.Patch(pizzaUpdate.Id, patch);

            // Assert

            IStatusCodeActionResult? result = actionResult as IStatusCodeActionResult;
            Assert.Equal(404, result?.StatusCode);

        }

        [Fact]
        public void Patch_Invalid_Id_Returns_Status_BadRequest()
        {
            // Arrange

            List<Pizza> pizzas = A.CollectionOfDummy<Pizza>(10).ToList();
            Pizza? testPizza = pizzas.FirstOrDefault();
            testPizza!.Id = 10;
            testPizza.Name = "pineapple";
            PizzaController? pizzaController = new PizzaController(pizzas);

            Pizza pizzaUpdate = new Pizza()
            {
                Id = 0,
                Name = testPizza.Name + "sausage",
                IsGlutenFree = false
            };

            JsonPatchDocument<Pizza> patch = new JsonPatchDocument<Pizza>();
            patch.Replace(x => x.Name, pizzaUpdate.Name);
            patch.Replace(x => x.IsGlutenFree, pizzaUpdate.IsGlutenFree);

            // Act

            // Patch the Pizza
            IActionResult actionResult = pizzaController.Patch(pizzaUpdate.Id, patch);

            // Assert

            IStatusCodeActionResult? result = actionResult as IStatusCodeActionResult;
            Assert.Equal(400, result?.StatusCode);

        }

        [Fact]
        public void Delete_Valid_Id_Returns_SuccessNoContent_Verify_UpdateSuccessful()
        {
            // Arrange

            List<Pizza> pizzas = A.CollectionOfDummy<Pizza>(10).ToList();
            Pizza? testPizza = pizzas.FirstOrDefault();
            testPizza!.Id = 10;
            testPizza.Name = "pineapple";
            PizzaController? pizzaController = new PizzaController(pizzas);

            Pizza pizzaDelete = new Pizza()
            {
                Id = testPizza.Id,
                Name = testPizza.Name + "sausage",
                IsGlutenFree = false
            };

            // Act

            IActionResult actionResult = pizzaController.Delete(pizzaDelete.Id);

            // Assert

            // Response from Delete Request
            IStatusCodeActionResult? result = actionResult as IStatusCodeActionResult;

            // Assert Successful No Content
            Assert.Equal(204, result?.StatusCode);

            // Act - Try to get the deleted pizza
            ActionResult<Pizza> actionResult2 = pizzaController.Get(testPizza!.Id);

            // Assert the Pizza is Actually Deleted
            IStatusCodeActionResult? result2 = actionResult2.Result as IStatusCodeActionResult;
            Assert.Equal(404, result2?.StatusCode);

        }

        [Fact]
        public void Delete_NonExisting_Id_Returns_Status_NotFound()
        {
            // Arrange

            List<Pizza> pizzas = A.CollectionOfDummy<Pizza>(10).ToList();
            Pizza? testPizza = pizzas.FirstOrDefault();
            testPizza!.Id = 10;
            testPizza.Name = "pineapple";
            PizzaController? pizzaController = new PizzaController(pizzas);

            Pizza pizzaDelete = new Pizza()
            {
                Id = 100, // Non existing Id
                Name = testPizza.Name + "sausage",
                IsGlutenFree = false
            };

            // Act

            IActionResult actionResult = pizzaController.Delete(pizzaDelete.Id);

            // Assert

            IStatusCodeActionResult? result = actionResult as IStatusCodeActionResult;
            Assert.Equal(404, result?.StatusCode);

        }

        [Fact]
        public void Delete_Invalid_Id_Returns_Status_BadRequest()
        {
            // Arrange

            List<Pizza> pizzas = A.CollectionOfDummy<Pizza>(10).ToList();
            Pizza? testPizza = pizzas.FirstOrDefault();
            testPizza!.Id = 10;
            testPizza.Name = "pineapple";
            PizzaController? pizzaController = new PizzaController(pizzas);

            Pizza pizzaDelete = new Pizza()
            {
                Id = 0, // Invalid Id
                Name = testPizza.Name + "sausage",
                IsGlutenFree = false
            };

            // Act

            IActionResult actionResult = pizzaController.Delete(pizzaDelete.Id);

            // Assert

            IStatusCodeActionResult? result = actionResult as IStatusCodeActionResult;
            Assert.Equal(400, result?.StatusCode);

        }

    }
}