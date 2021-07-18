using FluentValidation.Results;
using Hahn.ApplicatonProcess.July2021.Core.Model;
using Hahn.ApplicatonProcess.July2021.Domain.BussinessLogic;
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
        private readonly ILogger<UserAssetController> _logger;
        private readonly IService _service;


        public UserAssetController(ILogger<UserAssetController> logger, IService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public IActionResult AddUserAsset(UserAsset userAsset)
        {
            try
            {
                var results = _service.AddUserAsset(userAsset);
               if (results == null)
                {
                    return CreatedAtAction(nameof(GetUserAsset), new { userAsset.ID }, userAsset);
                }
                else
                {
                    return BadRequest(results.Errors);
                }
            }
            catch (System.Exception e)
            {

                //LogException(e);
                return StatusCode(500);
            }
            
               
        }

        [HttpGet("{id}")]
        public ActionResult<UserAsset> GetUserAsset(int id)
        {
            try
            {
                var result = _service.GetUserAsset(id);

                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (System.Exception)
            {

                //LogException(e);
                return StatusCode(500);
            }
             
        }

        [HttpPut("{id}")]
        public IActionResult PutUserAsset(int id, UserAsset modifiedUserAsset)
        {
              if (id != modifiedUserAsset.ID)
              {
                  return BadRequest();
              }         

              try
              {                
                _service.PutUserAsset(modifiedUserAsset);
                return Ok();
              }
              catch (DbUpdateConcurrencyException)
              {
                  if (!_service.UserAssetExists(id))
                  {
                      return NotFound();
                  }
                  else
                  {
                      //LogException(e);
                  return StatusCode(500);
                  }
              }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserAsset(int id)
        {
            try
            {
                var userAsset = _service.GetUserAsset(id);

                if (userAsset == null)
                {
                    return NotFound();
                }
                _service.DeleteUserAsset(userAsset.Value);
                return Ok();
            }
            catch (System.Exception)
            {
                //LogException(e);
                return StatusCode(500);
            }
            
        }
    }
}
