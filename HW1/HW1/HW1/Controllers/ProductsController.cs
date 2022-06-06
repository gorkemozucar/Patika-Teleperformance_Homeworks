using HW1.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HW1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> ProductList = new List<Product>()
        {
            new Product {ID = 1,Name ="Çatal",Description="Yemekler için birebir.",CategoryID=1},
            new Product {ID = 2,Name ="Kazma",Description="Çok kullanışlı toprak eşeleme aleti",CategoryID=2},
            new Product {ID = 3,Name ="Havlu",Description="Kir tutmayan ilk havlu",CategoryID=3}

        };
        [HttpGet]
        public IActionResult GetProduct()
        {
            var productList = ProductList.OrderBy(x => x.ID);

            return Ok(productList);

        }
        [HttpGet("{colon}/{orderby}")]
        public IActionResult GetProducts(string colon = "id", string orderby = "asc")
        {
            var productList = ProductList;
            if (colon.ToLower() == "id" && orderby.ToLower() == "asc")
            {
                productList = ProductList.OrderBy(x => x.ID).ToList();
            }
            else if (colon.ToLower() == "id" && orderby.ToLower() == "desc")
            {
                productList = ProductList.OrderByDescending(x => x.ID).ToList();
            }
            else if (colon.ToLower() == "name" && orderby.ToLower() == "asc")
            {
                productList = ProductList.OrderBy(x => x.Name).ToList();
            }
            else if (colon.ToLower() == "name" && orderby.ToLower() == "desc")
            {
                productList = ProductList.OrderByDescending(x => x.Name).ToList();
            }
            else
            {
                BadRequest("Yanlış sıralama tercihleri yapılıdı.");
            }


            return Ok(productList);

        }

        [HttpGet("id")]
        public IActionResult GetProductByID(int id)
        {
            var student = ProductList.SingleOrDefault(x => x.ID == id);
            if (student == null)
                return NotFound("Ürün Bulunamadı.");
            return Ok(student);
        }
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product newProduct)
        {
            var student = ProductList.SingleOrDefault(x => x.ID == newProduct.ID);
            if (student != null)
                return NotFound("Eklenmek istenen ürün bulunuyor");
            ProductList.Add(newProduct);
            return Created("Ürün Eklendi", newProduct);

        }
        [HttpPut("id")]
        public IActionResult UpdateProduct(int id, [FromBody] Product newProduct)
        {
            var product = ProductList.SingleOrDefault(x => x.ID == id);
            if (product == null)
                return NotFound("Güncellenmek İstenen Öğrenci Bulunamadı.");

            product.Name = newProduct.Name != default ? newProduct.Name : product.Name;
            product.Description = newProduct.Description != default ? newProduct.Description : product.Description;

            return Ok(product);
        }
        [HttpDelete("id")]
        public IActionResult DeleteProduct(int id)
        {
            var product = ProductList.SingleOrDefault(x => x.ID == id);
            if (product == null)
                return NotFound("Ürün Bulunamadı.");
            ProductList.Remove(product);
            return Ok(product);
        }
    }
}

