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
            if (!ModelState.IsValid)
            {
                // Nếu dữ liệu không hợp lệ, trả về lỗi cùng với thông tin chi tiết
                return BadRequest(ModelState);
            }
            try
            {
                List<ProductCart> p = _context.ProductCarts.Include(c => c.Product).Include(c => c.Card).ToList();
                List<Product_CardDTO> product_CardDTOs = new List<Product_CardDTO>();

                foreach (var item in p)
                {
                    Product_CardDTO pr = new Product_CardDTO();
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
        [HttpGet("id")]
        public async Task<IActionResult> GetAllPro_CardByCardId(int CardId)
        {
            if (!ModelState.IsValid)
            {
                // Nếu dữ liệu không hợp lệ, trả về lỗi cùng với thông tin chi tiết
                return BadRequest(ModelState);
            }
            try
            {
                List<ProductCart> p = _context.ProductCarts.Include(c => c.Product).Include(c => c.Card).Where(pc => pc.CardId == CardId).ToList();
                List<Product_CardDTO> product_CardDTOs = new List<Product_CardDTO>();

                foreach (var item in p)
                {
                    Product_CardDTO pr = new Product_CardDTO();
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
        [HttpPost]
        public async Task<IActionResult> AddtoCard(int cardid, int productid)
        {
            if (!ModelState.IsValid)
            {
                // Nếu dữ liệu không hợp lệ, trả về lỗi cùng với thông tin chi tiết
                return BadRequest(ModelState);
            }
            try
            {
                var ca = _context.Carts.FirstOrDefault(c => c.CartId == cardid);
                var pr = _context.ProductCarts.FirstOrDefault(p => p.ProductId == productid);
                if (ca == null || pr == null)
                {
                    return BadRequest("null");
                }
                else
                {
                    var p_c = _context.ProductCarts.FirstOrDefault(pc => pc.ProductId == productid && pc.CardId == cardid);
                    if (p_c == null)
                    {
                        ProductCart pc = new ProductCart(productid, cardid, 1);
                        await _context.ProductCarts.AddAsync(pc);
                        _context.SaveChangesAsync();
                        return Ok("da tao them 1 san pham vao gio hang voi productid = " + productid);
                    }
                    else
                    {
                        p_c.Quantity += 1;
                        _context.Update(p_c);
                        _context.SaveChangesAsync();
                        return Ok("da add them 1 san pham co productidd = " + productid + " va so luong = " + p_c.Quantity);
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
