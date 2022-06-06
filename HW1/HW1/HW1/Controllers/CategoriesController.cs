using HW1.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HW1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private static List<Category> CategoryList = new List<Category>()
        {
            new Category {CategoryID = 1,CategoryName ="Mutfak Eşyası"},
            new Category {CategoryID = 2,CategoryName ="Bahçe Eşyası "},
            new Category {CategoryID = 3,CategoryName ="Banyo Eşyası"},
        };


        [HttpGet]
        public IActionResult GetCategories()
        {
            var categoryList = CategoryList.OrderBy(x => x.CategoryID);

            return Ok(categoryList);

        }
        [HttpGet("{colon}/{orderby}")]
        public IActionResult GetCategories(string colon = "id", string orderby = "asc")
        {
            var categoryList = CategoryList;
            if (colon.ToLower() == "id" && orderby.ToLower() == "asc")
            {
                categoryList = CategoryList.OrderBy(x => x.CategoryID).ToList();
            }
            else if (colon.ToLower() == "id" && orderby.ToLower() == "desc")
            {
                categoryList = CategoryList.OrderByDescending(x => x.CategoryID).ToList();
            }
            else if (colon.ToLower() == "name" && orderby.ToLower() == "asc")
            {
                categoryList = CategoryList.OrderBy(x => x.CategoryName).ToList();
            }
            else if (colon.ToLower() == "name" && orderby.ToLower() == "desc")
            {
                categoryList = CategoryList.OrderByDescending(x => x.CategoryName).ToList();
            }
            else
            {
                BadRequest("Yanlış sıralama tercihleri yapılıdı.");
            }


            return Ok(categoryList);

        }

        [HttpGet("id")]
        public IActionResult GetCategoryById(int id)
        {
            var category = CategoryList.SingleOrDefault(x => x.CategoryID == id);
            if (category == null)
                return NotFound("Kategori Bulunamadı.");
            return Ok(category);
        }
        [HttpPost]
        public IActionResult AddCategory([FromBody] Category newCategory)
        {
            var school = CategoryList.SingleOrDefault(x => x.CategoryID == newCategory.CategoryID);
            if (school != null)
                return NotFound("Eklenmek istenen kategori bulunuyor");
            CategoryList.Add(newCategory);
            return Created("Kategori Eklendi", newCategory);

        }
        [HttpPatch("id")]
        public IActionResult UpdateCategory(int id, [FromBody] Category newCategory)
        {
            var category = CategoryList.SingleOrDefault(x => x.CategoryID == id);
            if (category == null)
                return NotFound("Güncellenmek İstenen Kategori Bulunamadı.");

            category.CategoryName = newCategory.CategoryName != default ? newCategory.CategoryName : category.CategoryName;
            return Ok(category);
        }
        [HttpDelete("id")]
        public IActionResult DeleteCategory(int id)
        {
            var category = CategoryList.SingleOrDefault(x => x.CategoryID == id);
            if (category == null)
                return NotFound("Kategori Bulunamadı.");
            CategoryList.Remove(category);
            return Ok(category);
        }
    }
}