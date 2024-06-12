using api_card.DTO_output;
using api_card.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_card.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product_Card_Controllers : ControllerBase
    {
        test2Context _context = new test2Context();
        private readonly IMapper _mapper;

        public Product_Card_Controllers(test2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPro_Card()
        {
            try
            {
                List<ProductCart> p = _context.ProductCarts.Include(c => c.Product).Include(c => c.Card).ToList();
                List<Product_CardDTO> product_CardDTOs = new List<Product_CardDTO>();
                Product_CardDTO pr = new Product_CardDTO();
                foreach (var item in p)
                {
                    _mapper.Map(item, pr);
                    product_CardDTOs.Add(pr);
                }
                return Ok(product_CardDTOs);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
