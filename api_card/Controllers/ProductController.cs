using api_card.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api_card.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        test2Context _context = new test2Context();
        private readonly IMapper _mapper;

        public ProductController(test2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            if (!ModelState.IsValid)
            {
                // Nếu dữ liệu không hợp lệ, trả về lỗi cùng với thông tin chi tiết
                return BadRequest(ModelState);
            }
            try
            {
                var list = _context.Products.ToList();
                return Ok(list);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet("id")]
        public IActionResult GetPRoductById(int id)
        {
            if (!ModelState.IsValid)
            {
                // Nếu dữ liệu không hợp lệ, trả về lỗi cùng với thông tin chi tiết
                return BadRequest(ModelState);
            }
            try
            {
                var p = _context.Products.FirstOrDefault(c => c.ProductId == id);
                if (p == null) return NotFound("not found id = " + id);
                else return Ok(p);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("caid")]
        public IActionResult GetPRoductByCategoryId(int caid)
        {
            if (!ModelState.IsValid)
            {
                // Nếu dữ liệu không hợp lệ, trả về lỗi cùng với thông tin chi tiết
                return BadRequest(ModelState);
            }
            try
            {
                var p = _context.Products.Where(c => c.CategoryId == caid).ToList();
                if (p == null) return NotFound("not found id = " + caid);
                else return Ok(p);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("name")]
        public IActionResult GetName(string name)
        {
            if (!ModelState.IsValid)
            {
                // Nếu dữ liệu không hợp lệ, trả về lỗi cùng với thông tin chi tiết
                return BadRequest(ModelState);
            }
            try
            {
                var p = _context.Products.Where(c => c.ProductName.Contains(name)).ToList();
                if (p == null) return NotFound(name);
                else
                {
                    return Ok(p);
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
    }
}
