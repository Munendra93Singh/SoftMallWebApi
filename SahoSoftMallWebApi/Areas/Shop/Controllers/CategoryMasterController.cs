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
    public class CategoryMasterController : ControllerBase
    {
        private readonly ICategoryMasterService _iCategoryMasterService;
        public CategoryMasterController(ICategoryMasterService iCategoryMasterService)
        {
            _iCategoryMasterService = iCategoryMasterService;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public IActionResult GetAll()
        {
            var res = _iCategoryMasterService.GetAll();
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
            var res = _iCategoryMasterService.GetById(Id);
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
            var Title = Request.Form["Title"][0];
            var PostedFile = Request.Form.Files["Image"];
            var IsSave = Request.Form["IsSave"][0];
            var Link = Request.Form["Link"][0];
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

                var model = new CategoryMasterRequest
                {
                    Name = LogoName,
                    ImagePath = FileName,
                    Title = Title,
                    isSave = Convert.ToInt32(IsSave),
                    Link = Link
                };

                var res = _iCategoryMasterService.Add(model);
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
            var Title = Request.Form["Title"][0];
            var IsSave = Request.Form["IsSave"][0];
            var Link = Request.Form["Link"][0];

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

                var model = new CategoryMasterRequest
                {
                    Id = Id,
                    Name = LogoName,
                    ImagePath = FileName,
                    Title = Title,
                    isSave = Convert.ToInt32(IsSave),
                    Link = Link,
                    ModifiedBy = ModifiedBy,
                    ModifiedOn = Convert.ToDateTime(ModifiedOn)
                };

                var res = _iCategoryMasterService.Update(model);
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
            var res = _iCategoryMasterService.Delete(viewModel.Id);
            if (res.ISuccess)
            {
                return Ok(res);
            }

            return NotFound(res);
        }

    }
}