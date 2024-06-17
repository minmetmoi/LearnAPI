using api_card.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api_card.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        test2Context _context = new test2Context();
        private readonly IMapper _mapper;

        public CategoryController(test2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllCategory()
        {
            if (!ModelState.IsValid)
            {
                // Nếu dữ liệu không hợp lệ, trả về lỗi cùng với thông tin chi tiết
                return BadRequest(ModelState);
            }
            try
            {
                var list = _context.Categories.ToList();
                return Ok(list);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
