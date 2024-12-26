using BusinessEntities.Common;
using BusinessEntities.Shop.RequestDto;
using BusinessService.Interface;
using Microsoft.AspNetCore.Mvc;


namespace SoftMallWebApi.Areas.Shop.Controllers
{
    [Area("Shop")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TagMasterController : ControllerBase
    {
        private readonly ITagMasterService _iTagMasterService;
        public TagMasterController(ITagMasterService iTagMasterService)
        {
            _iTagMasterService = iTagMasterService;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public IActionResult GetAll()
        {
            var res = _iTagMasterService.GetAll();
            if (res.ISuccess)
            {
                return Ok(res);
            }
            return NotFound(res);
        }
        [HttpGet("{Id}")]
        [ActionName("GetById")]
        public IActionResult GetById(long Id)
        {
            var res = _iTagMasterService.GetById(Id);
            if (res.ISuccess)
            {
                return Ok(res);
            }
            return NotFound(res);
        }

        [HttpPost]
        [ActionName("Save")]
        public IActionResult Post([FromBody] TagMasterRequest viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToArray());
            }
            var res = _iTagMasterService.Add(viewModel);
            if (res.ISuccess)
            {
                return Ok(res);
            }

            return NotFound(res);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update([FromBody] TagMasterRequest viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToArray());
            }
            var res = _iTagMasterService.Update(viewModel);
            if (res.ISuccess)
            {
                return Ok(res);
            }

            return NotFound(res);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete([FromBody] ValueRequest viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToArray());
            }
            var res = _iTagMasterService.Delete(viewModel.Id);
            if (res.ISuccess)
            {
                return Ok(res);
            }

            return NotFound(res);
        }

    }
}