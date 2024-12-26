using BusinessEntities.Common;
using BusinessEntities.Shop.RequestDto;
using BusinessService.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;

namespace SoftMallWebApi.Areas.Shop.Controllers
{
    [Area("Shop")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandLogoController : ControllerBase
    {
        private readonly IBrandLogoMasterService _iBrandLogoMasterService;
        public BrandLogoController(IBrandLogoMasterService iBrandLogoMasterService)
        {
            _iBrandLogoMasterService = iBrandLogoMasterService;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public IActionResult GetAll()
        {
            var res = _iBrandLogoMasterService.GetAll();
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
            var res = _iBrandLogoMasterService.GetById(Id);
            if (res.ISuccess)
            {
                return Ok(res);
            }
            return NotFound(res);
        }

        [HttpPost]
        [ActionName("Save")]
        public IActionResult Post()
        {
            var LogoName = Request.Form["Name"][0];
            var PostedFile = Request.Form.Files["Image"];
            var FolderName = "Images1";
            //var FolderName = @"wwwroot\Images";
            var PathToSave = Path.Combine(Directory.GetCurrentDirectory(), FolderName);
            if (PostedFile.Length > 0)
            {
                var FileName = ContentDispositionHeaderValue.Parse(PostedFile.ContentDisposition).FileName.Trim('"');
                var FullPath = Path.Combine(PathToSave, FileName);

                using (var stream = new FileStream(FullPath, FileMode.Create))
                {
                    PostedFile.CopyTo(stream);
                }

                var model = new BrandLogoMasterRequest
                {
                    Name = LogoName,
                    ImagePath = FileName
                };

                var res = _iBrandLogoMasterService.Add(model);
                if (res.ISuccess)
                {
                    return Ok(res);
                }

                return NotFound(res);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update()
        {
            var Id = Convert.ToInt32(Request.Form["Id"][0] ?? "0");
            var LogoName = Request.Form["Name"][0];
            var ModifiedBy = Convert.ToInt32(Request.Form["ModifiedBy"][0] ?? "0");
            var ModifiedOn = Request.Form["ModifiedOn"][0];
            var PostedFile = Request.Form.Files["Image"];
            var FolderName = @"wwwroot\Images";
            var PathToSave = Path.Combine(Directory.GetCurrentDirectory(), FolderName);
            if (PostedFile.Length > 0)
            {
                var FileName = ContentDispositionHeaderValue.Parse(PostedFile.ContentDisposition).FileName.Trim('"');
                var FullPath = Path.Combine(PathToSave, FileName);

                using (var stream = new FileStream(FullPath, FileMode.Create))
                {
                    PostedFile.CopyTo(stream);
                }

                var model = new BrandLogoMasterRequest
                {
                    Id = Id,
                    Name = LogoName,
                    ImagePath = FileName,
                    ModifiedBy = ModifiedBy,
                    ModifiedOn = Convert.ToDateTime(ModifiedOn)
                };

                var res = _iBrandLogoMasterService.Update(model);
                if (res.ISuccess)
                {
                    return Ok(res);
                }

                return NotFound(res);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete([FromBody] ValueRequest viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToArray());
            }
            var res = _iBrandLogoMasterService.Delete(viewModel.Id);
            if (res.ISuccess)
            {
                return Ok(res);
            }

            return NotFound(res);
        }

    }
}