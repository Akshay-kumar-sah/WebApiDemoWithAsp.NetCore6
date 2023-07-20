using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;
using WebApiDemo.Repository;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class WebApiController : ControllerBase
    {
        private readonly IWebApiRepository _webApiRepository;

        public WebApiController(IWebApiRepository webApiRepository)
        {
            _webApiRepository = webApiRepository;
        }

        
        [HttpGet("")]
        public async Task<IActionResult> GetAllWebApi() 
        {
            var webApis = await _webApiRepository.GetAllWebApi();
            return Ok(webApis);
        }
        
         [HttpGet("{id}")]
        public async Task<IActionResult> GetWebApiById([FromRoute]int id) 
        {
            var webApi = await _webApiRepository.GetWebApiById(id);
            if(webApi == null){
                return NotFound();
            }
            return Ok(webApi);
        }

         [HttpPost("")]
        public async Task<IActionResult> CreateWebApi([FromBody] WebApiModel webApiModel) 
        {
            if (ModelState.IsValid)
        {
            await _webApiRepository.CreateWebApi(webApiModel);
            return CreatedAtAction("GetWebApiById", new { id = webApiModel.Id }, webApiModel);
        }
        return BadRequest(ModelState);
        }
       

         [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWebApi([FromBody] WebApiModel webApiModel, [FromRoute] int id) 
        {
         
            await _webApiRepository.UpdateWebApi( id, webApiModel);
            return Ok();
        }
        
          [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWebApi( [FromRoute] int id) 
        {
         
            await _webApiRepository.DeleteWebApi( id);
            return Ok();
        }
       


        public IWebApiRepository WebApiRepository => _webApiRepository;
    }
}