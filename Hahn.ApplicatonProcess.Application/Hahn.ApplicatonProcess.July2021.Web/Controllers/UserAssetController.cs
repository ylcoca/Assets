using FluentValidation.Results;
using Hahn.ApplicatonProcess.July2021.Core.Model;
using Hahn.ApplicatonProcess.July2021.Domain.BussinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
                _logger.LogInformation($"AddUserAsset asset: {Newtonsoft.Json.JsonConvert.SerializeObject(userAsset)}");
                var results = _service.AddUserAsset(userAsset);
               if (results == null)
                {
                    _logger.LogInformation($"Usser asset created successfully");
                    return CreatedAtAction(nameof(GetUserAsset), new { userAsset.ID }, userAsset);
                }
                else
                {
                    _logger.LogInformation($"Bad Request on AddUserAsset asset: {Newtonsoft.Json.JsonConvert.SerializeObject(userAsset)}, errors {results.Errors}");
                    return BadRequest(results.Errors);
                }
            }
            catch (System.Exception e)
            {

                _logger.LogError(e.Message);
                return StatusCode(500);
            }
            
               
        }

        [HttpGet("{id}")]
        public ActionResult<UserAsset> GetUserAsset(int id)
        {
            try
            {
                _logger.LogInformation($"GetUserAsset id: {id}");
                var result = _service.GetUserAsset(id);

                if (result == null)
                {
                    _logger.LogInformation($"GetUserAsset id: {id} not found");
                    return NotFound();
                }
                return result;
            }
            catch (System.Exception e)
            {

                _logger.LogError(e.Message);
                return StatusCode(500);
            }
             
        }

        [HttpPut("{id}")]
        public IActionResult PutUserAsset(int id, UserAsset modifiedUserAsset)
        {
            _logger.LogInformation($"PutUserAsset id: {id} and asset: {Newtonsoft.Json.JsonConvert.SerializeObject(modifiedUserAsset)}");
            if (id != modifiedUserAsset.ID)
              {
                _logger.LogInformation($"PutUserAsset Bad request ID does not match");
                return BadRequest();
              }         

              try
              {                
                _service.PutUserAsset(modifiedUserAsset);
                _logger.LogInformation($"PutUserAsset id: {id} successful");
                return Ok();
              }
              catch (DbUpdateConcurrencyException e)
              {
                  if (!_service.UserAssetExists(id))
                  {
                    _logger.LogInformation($"UserAsset id: {id} not found");
                    return NotFound();
                  }
                  else
                  {
                    _logger.LogError(e.Message);
                    return StatusCode(500);
                  }
              }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserAsset(int id)
        {
            try
            {
                _logger.LogInformation($"DeleteUserAsset id: {id}");
                var userAsset = _service.GetUserAsset(id);

                if (userAsset == null)
                {
                    return NotFound();
                }                
                _service.DeleteUserAsset(userAsset.Value);
                _logger.LogInformation($"Succesfully Deleted UserAsset id: {id}");
                return Ok();
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
            
        }
    }
}
