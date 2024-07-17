using api.Dtos.Comment;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers {

    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;


        public CommentController(/*ApplicationDBContext context, */ICommentRepository commentRepo, IStockRepository stockRepo) {
            // _context = context;
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll() {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var comments =  await _commentRepo.GetAllAsync();
            var CommentDto = comments.Select(s => s.ToCommentDto());
            return Ok(CommentDto);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id) {

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = await _commentRepo.GetByIdAsync(id);
            if(comment == null) {
                return NotFound();
            }

            return Ok(comment.ToCommentDto());
        }


        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentDto commentDto) {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await _stockRepo.StockExists(stockId)) {
                return BadRequest("Stock does not exist 9999");
            }
            var commentModel = commentDto.ToCommentFromCreate(stockId);
            await _commentRepo.CreateAsync(commentModel);

            return CreatedAtAction(nameof(GetById), new {id = commentModel}, commentModel.ToCommentDto());
        }















        [HttpPut("{id:int}")]
        // [Route("{id: int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto updateDto) {

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = await _commentRepo.UpdateAsync(id, updateDto.ToCommenFromUpdate());
            if(comment == null) {
                return NotFound("Comment not Found 3999");
            }
                return Ok(comment.ToCommentDto());
        }


        [HttpDelete("{id:int}")]
        // [Route("{id: int}")]
        public async Task<IActionResult> Delete([FromRoute] int id) {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var commentModel = await _commentRepo.DeleteAsync(id);
            {
                if(commentModel == null) {
                    return NotFound("Comment does not exits 3999");
                }

                return Ok(commentModel);
            }
        }
    }
}