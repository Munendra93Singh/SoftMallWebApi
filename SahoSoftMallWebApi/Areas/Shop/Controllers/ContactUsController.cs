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
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsService _iContactUsService;
        public ContactUsController(IContactUsService iContactUsService)
        {
            _iContactUsService = iContactUsService;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public IActionResult GetAll()
        {
            var res = _iContactUsService.GetAll();
            if (res.ISuccess)
            {
                return Ok(res);
            }
            return NotFound(res);
        }

        [HttpPost]
        [ActionName("Save")]
        public IActionResult Post([FromBody] ContactUsRequest viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToArray());
            }
            var res = _iContactUsService.Add(viewModel);
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
            var res = _iContactUsService.Delete(viewModel.Id);
            if (res.ISuccess)
            {
                return Ok(res);
            }

            return NotFound(res);
        }
    }
}