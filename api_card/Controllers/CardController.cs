using api_card.DTO;
using api_card.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api_card.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        test2Context _context = new test2Context();
        private readonly IMapper _mapper;

        public CardController(test2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAllCarđ()
        {
            try
            {
                var list = _context.Carts.ToList();
                return Ok(list);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet("id")]
        public ActionResult GetCardByUserID(int id)
        {
            try
            {
                var card = _context.Carts.FirstOrDefault(c => c.UserId == id);
                if (card == null) return NotFound("Not found id = " + id);
                else { return Ok(card); }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> InsertCard(Card_DTO cart)
        {
            try
            {
                Cart c = new Cart();
                _mapper.Map(cart, c);
                _context.Add(c);
                await _context.SaveChangesAsync();

                return Ok(c);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdadteCard(int id, Card_DTO card)
        {
            try
            {
                var c = _context.Carts.FirstOrDefault(c => c.CartId == id);
                if (c == null) return NotFound("not found card id = " + id);
                else
                {
                    _mapper.Map(card, c);
                    _context.Update(c);
                    await _context.SaveChangesAsync();
                    return Ok(card);
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            try
            {
                var c = _context.Carts.FirstOrDefault(c => c.CartId == id);
                if (c == null) return NotFound("not found card id = " + id);
                else
                {
                    _context.Remove(c);
                    await _context.SaveChangesAsync();
                    return Ok("delete ok");
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
