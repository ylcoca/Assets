using FluentValidation.Results;
using Hahn.ApplicatonProcess.July2021.Data;
using Hahn.ApplicatonProcess.July2021.Data.Repository;
using Hahn.ApplicatonProcess.July2021.Domain.Model;
using Hahn.ApplicatonProcess.July2021.Domain.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAssetController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly ILogger<UserAssetController> _logger;
        private readonly UnitOfWork unitOfWork;
        UserValidator validator;

        public UserAssetController(ILogger<UserAssetController> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
            unitOfWork  = new UnitOfWork(_context);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddUserAsset(UserAsset userAsset)
        {
            var assets = HTTPDataAccess.Assets();
            validator = new(assets);

            ValidationResult results =   validator.Validate(userAsset);
            if (results.IsValid)
            {
                await unitOfWork.UserAssetRepository.InsertUserAsset(userAsset);
                return CreatedAtAction(nameof(GetUserAsset), new { userAsset.ID }, userAsset);
            }
            return BadRequest(results.Errors);
               
        }

        [HttpGet("{id}")]
        public ActionResult<UserAsset> GetUserAsset(int id)
        {
            var userAsset = unitOfWork.UserAssetRepository.GetUserAsset(id);

            if (userAsset == null)
            {
                return NotFound();
            }

            return userAsset;
        }        

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAsset(int id, UserAsset modifiedUserAsset)
        {            
            if (id != modifiedUserAsset.ID)
            {
                return BadRequest();
            }         

            try
            {
                unitOfWork.UserAssetRepository.UpdateUserAsset(modifiedUserAsset);                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!unitOfWork.UserAssetRepository.UserAssetExists(id))
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
        public async Task<IActionResult> DeleteUserAsset(int id)
        {
            var userAsset = unitOfWork.UserAssetRepository.GetUserAsset(id);

            if (userAsset == null)
            {
                return NotFound();
            }
            await unitOfWork.UserAssetRepository.DeleteUserAsset(userAsset.Value);
            return Ok();
        }
    }
}
