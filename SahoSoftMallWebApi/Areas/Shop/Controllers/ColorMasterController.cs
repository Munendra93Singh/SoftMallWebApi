using BusinessEntities.Common;
using BusinessEntities.Shop.RequestDto;
using BusinessService.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SoftMallWebApi.Areas.Shop.Controllers
{
    [Area("Shop")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ColorMasterController : ControllerBase
    {
        private readonly IColorMasterService _colorMasterService;
        public ColorMasterController(IColorMasterService colorMasterService)
        {
            _colorMasterService = colorMasterService;
        }
        [HttpGet]
        [ActionName("GetAll")]
        public IActionResult GetAll()
        {
            var res = _colorMasterService.GetAll();
            if (res.ISuccess)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("{Id}")]
        [ActionName("GetById")]
        public IActionResult Get(int Id)
        {
            var res = _colorMasterService.GetById(Id);
            if (res.ISuccess)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpPost]
        [ActionName("Save")]
        public IActionResult Post([FromBody] ColorMasterRequest viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToArray());
            }
            var res = _colorMasterService.Add(viewModel);
            if (res.ISuccess)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update([FromBody] ColorMasterRequest viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToArray());
            }
            var res = _colorMasterService.Update(viewModel);
            if(res.ISuccess)
            {
                return Ok(res);
            }
            return BadRequest(res);

        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete([FromBody] ValueRequest viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToArray());
            }
            var res = _colorMasterService.Delete(viewModel.Id);
            if(res.ISuccess)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
      

    }
}
