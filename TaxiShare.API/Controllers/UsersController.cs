using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaxiShare.Domain.Entities;
using TaxiShare.Infrastructure.Context;

namespace TaxiShare.Hub.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TaxiShareDbContext context;

        public UsersController(TaxiShareDbContext context)
        {
            this.context = context;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await context.Users.ToListAsync();
            return Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            if (user == null)
                return BadRequest();
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return Ok();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] User user)
        {
            if (user == null)
                return BadRequest(nameof(user));

            var oldUser = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (oldUser == null)
                return NotFound();

            oldUser.Firstname = user.Firstname;
            oldUser.Surname = user.Surname;
            oldUser.PhotoUrl = user.PhotoUrl;
            await context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id ==id);
            if (user == null)
                return NotFound();

            user.InExistance = false;
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
