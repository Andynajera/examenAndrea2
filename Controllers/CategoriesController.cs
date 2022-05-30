
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Categories;


namespace CategoriesController;


    [ApiController]
    [Route("[Controller]")]
    public class CategoriesController : ControllerBase
    {
        private static List<Category> Categories = new List<Category>{
            new Category { id=1 ,name="categoria1",description="uno"},
            new Category { id=2 ,name="categoria2",description="dos"}

        };
 

[HttpGet]
    public ActionResult<List<Category>> Get(){
        return Ok(Categories);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Category> Get (int id){
        var category = Categories.Find (x =>x.id == id);
        return category == null ? NotFound() : Ok(category);
    }
    



    [HttpPost]
     public ActionResult<Category> Post([FromBody] Category category){
        var existingCategory = Categories.Find(x=>x.id== category.id);
        var prueba = Categories.Find(x=>x.id== category.id);
        if (existingCategory != null){
          
          String url = Request.Path.ToString() + "/" + category.id;
            return Conflict("ya existe esa categoria");
        } 
        if (prueba != null){
          
          String url = Request.Path.ToString() + "/" + category.id;
            return NotFound("error");
        } else 
        
        {
            Categories.Add(category);
            var resourceUrl = Request.Path.ToString()+ "/" + category.id;
            return Created(resourceUrl, category);
            
        }
        }
 
     [HttpPut]
    public ActionResult Put (Category category){
        var existingCategory = Categories.Find(x=>x.id== category.id);
        if (existingCategory == null){
            return Conflict("no existe esa categoria");
        } else {
            existingCategory.name = category.name;
            return Ok();
        }
        }
     [HttpDelete]
    [Route("{id}")]
    public ActionResult<Category> Delete (int id){
        var category = Categories.Find (x =>x.id == id);
        if (category == null){
            return NotFound("no funciona");
        } else{
            Categories.Remove(category);
            return NoContent();
        }
    }
    
    
    }


    
   


