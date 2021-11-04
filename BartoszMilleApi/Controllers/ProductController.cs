using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository.Model;
using Service;
using System;
using System.Threading.Tasks;

namespace BartoszMilleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private IProductService _productsService;

        public ProductController(ILogger<ProductController> logger,
            IProductService productsService)
        {
            _logger = logger;
            _productsService = productsService;
        }

        //C
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            try
            {
                var result = _productsService.Create(product);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return BadRequest(e.Message);
            }
        }

        //R
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var result = _productsService.Read(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return BadRequest(e.Message);
            }
        }

        //U
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            try
            {
                var result = _productsService.Update(product);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return BadRequest(e.Message);
            }
        }

        //D
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                _productsService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
