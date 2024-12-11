using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sudokuweb.SudokuModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sudokuweb.Controllers
{
    [Route("api/sudoku")]
    [ApiController]
    public class SudokuController : ControllerBase
    {
        // GET: api/<SudokuController>
        [HttpGet]
        public IActionResult Get()
        {
            SudokuContext context = new SudokuContext();
            return Ok(context.Puzzles.ToList());
        }

        // GET api/<SudokuController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            SudokuContext context = new SudokuContext();
            var p = (from x in context.Puzzles
                     where x.PuzzleId == id
                     select x).FirstOrDefault();

            if (p == null)
            {
                return NotFound("Nincs ilyen sudoku.");
            }

            return Ok(p);
        }

        // POST api/<SudokuController>
        [HttpPost]
        public IActionResult Post([FromBody] Puzzle ujPuzzle)
        {
            SudokuContext context = new SudokuContext();
            context.Puzzles.Add(ujPuzzle);
            try
            {
                context.SaveChanges();
                return Ok();
            }
            catch (DbUpdateException dbEx)
            {
                return BadRequest("Nem megfelelő a beírt adatok: " + dbEx.Message);
            }
        }

        // PUT api/<SudokuController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SudokuController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            SudokuContext context = new SudokuContext();
            var p = (from x in context.Puzzles
                     where x.PuzzleId == id
                     select x).FirstOrDefault();

            if (p == null)
            {
                return NotFound("Nincs ilyen sudoku");
            }
            context.Puzzles.Remove(p);
            context.SaveChanges();

            return Ok("Sikeres törlés");
        }
    }
}
