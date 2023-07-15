using Microsoft.AspNetCore.Mvc;
using CashFlow360_API.Services;
using CashFlow360_API.Models;

namespace CashFlow360_API.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        private readonly MongoDBServices _mongoDBService;

        public TransactionController(MongoDBServices mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        [HttpGet]
        public async Task<List<Transaction>> GetTransaction()
        {
            return await _mongoDBService.GetTransactionAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostTransaction([FromBody] Transaction t)
        {
            await _mongoDBService.CreateTransactionAsync(t);
            return CreatedAtAction(nameof(GetTransaction), new { Id = t.Id }, t);
        }
    }
}
