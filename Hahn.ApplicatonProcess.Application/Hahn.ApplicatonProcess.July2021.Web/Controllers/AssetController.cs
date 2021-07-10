using Hahn.ApplicatonProcess.July2021.Data;
using Hahn.ApplicatonProcess.July2021.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly AssetDBContext _context;

        private readonly ILogger<AssetController> _logger;

        public AssetController(ILogger<AssetController> logger, AssetDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetTodoItem(int id)
        {
            var todoItem = await _context.User.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User userAsset)
        {
            _context.User.Add(userAsset);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { name = userAsset.FirstName }, userAsset);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, UserAsset userAsset)
        {
            if (id != userAsset.ID)
            {
                return BadRequest();
            }

            _context.Entry(userAsset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return StatusCode(500);
        }

        private bool AssetExists(long id) =>
            _context.UserAsset.Any(e => e.ID == id);
    }
}
