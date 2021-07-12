using Hahn.ApplicatonProcess.July2021.Data;
using Hahn.ApplicatonProcess.July2021.Domain;
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
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private UnitOfWork unitOfWork = new UnitOfWork();

        public UserController(ILogger<UserController> logger, DBContext context, IUserService userService)
        {
            _logger = logger;
            _context = context;
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await unitOfWork.UserRepository.GetUser(id);
            //var user = await _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddUser(UserDTO userAsset)
        {
            /* await _userService.AddUser(userAsset);
             return CreatedAtAction(nameof(GetUser), new { id = userAsset.Id }, userAsset);*/

            await unitOfWork.UserRepository.AddUser(userAsset);
            return CreatedAtAction(nameof(GetUser), new { id = userAsset.Id }, userAsset);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, UserDTO userAsset)
        {
            if (id != userAsset.Id)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var todoItem = await _context.User.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.User.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssetExists(long id) =>
            _context.UserAsset.Any(e => e.ID == id);
    }
}
