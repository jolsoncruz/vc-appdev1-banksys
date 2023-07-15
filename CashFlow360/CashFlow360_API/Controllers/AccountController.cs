using Microsoft.AspNetCore.Mvc;
using CashFlow360_API.Services;
using CashFlow360_API.Models;

namespace CashFlow360_API.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly MongoDBServices _mongoDBService;

        public AccountController(MongoDBServices mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        [HttpGet]
        public async Task<List<Account>> GetUser()
        {
            return await _mongoDBService.GetUserAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] Account a)
        {
            await _mongoDBService.CreateUserAsync(a);
            return CreatedAtAction(nameof(GetUser), new { Id = a.Id }, a);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] string CustomerName, [FromBody] string CustomerAddress, [FromBody] string CustomerPhone, [FromBody] string CustomerSIN, [FromBody] double AccountBalance)
        {
            await _mongoDBService.UpdateUserAsync(id, CustomerName, CustomerAddress, CustomerPhone, CustomerSIN, AccountBalance);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _mongoDBService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
