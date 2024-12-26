using BusinessEntities.Common;
using BusinessEntities.Shop.RequestDto;
using BusinessEntities.Shop.ResponseDto;
using BusinessService.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;

namespace SoftMallWebApi.Areas.Shop.Controllers
{
    [Area("Shop")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductMasterController : ControllerBase
    {
        private readonly IProductMasterService _iProductMasterService;
        public ProductMasterController(IProductMasterService iProductMasterService)
        {
            _iProductMasterService = iProductMasterService;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public IActionResult GetAll()
        {
            var res = _iProductMasterService.GetAll();
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
            var res = _iProductMasterService.GetById(Id);
            if (res.ISuccess)
            {
                return Ok(res);
            }
            return NotFound(res);
        }

        [HttpPost, DisableRequestSizeLimit]
        [ActionName("Save")]
        public IActionResult Post()
        {
            var model = new ProductMasterRequest
            {
                Name = Request.Form["Name"][0],
                Title = Request.Form["Title"][0],
                Code = Request.Form["Code"][0],
                Price = Convert.ToDecimal(Request.Form["Price"][0]),
                SalePrice = Convert.ToDecimal(Request.Form["SalePrice"][0]),
                ShortDetails = Request.Form["ShortDetails"][0],
                Description = Request.Form["Description"][0],
                Quantity = Convert.ToInt32(Request.Form["Quantity"][0]),
                Discount = Convert.ToInt32(Request.Form["Discount"][0]),
                IsNew = Convert.ToInt32(Request.Form["IsNew"][0]),
                IsSale = Convert.ToInt32(Request.Form["IsSale"][0]),
                CategoryId = Convert.ToInt32(Request.Form["CategoryId"][0]),
                TagId = Convert.ToInt32(Request.Form["TagId"][0]),
                ColorId = Convert.ToInt32(Request.Form["ColorId"][0]),
                SizeId = Convert.ToInt32(Request.Form["SizeId"][0]),
            };

            var res = _iProductMasterService.Add(model);
            if (res.ISuccess)
            {
                var files = Request.Form.Files;

                //var FolderName = "Images";
                var FolderName = @"wwwroot\Images";
                var PathToSave = Path.Combine(Directory.GetCurrentDirectory(), FolderName);
                int count = 1;
                foreach (var image in files)
                {
                    if (image != null && image.Length > 0)
                    {
                        var PostedFile = image;
                        if (PostedFile.Length > 0)
                        {
                            var FileName = ContentDispositionHeaderValue.Parse(PostedFile.ContentDisposition).FileName.Trim('"');
                            var FullPath = Path.Combine(PathToSave, FileName);

                            using (var stream = new FileStream(FullPath, FileMode.Create))
                            {
                                PostedFile.CopyTo(stream);
                            }

                            var m = new ProductPictureMappingRequest
                            {
                                ProductId = res.Data.Id,
                                PictureName = FileName,
                                PicturePath = FullPath,
                                IsDelete = count
                            };

                            var res1 = _iProductMasterService.AddImageMapping(m);
                            count++;
                        }
                    }
                }
            }
            return Ok(res);
        }

        [HttpPost, DisableRequestSizeLimit]
        [ActionName("Update")]
        public IActionResult Update()
        {
            var model = new ProductMasterRequest
            {
                Id = Convert.ToInt32(Request.Form["Id"][0] ?? "0"),
                Name = Request.Form["Name"][0],
                Title = Request.Form["Title"][0],
                Code = Request.Form["Code"][0],
                Price = Convert.ToDecimal(Request.Form["Price"][0]),
                SalePrice = Convert.ToDecimal(Request.Form["SalePrice"][0]),
                ShortDetails = Request.Form["ShortDetails"][0],
                Description = Request.Form["Description"][0],
                Quantity = Convert.ToInt32(Request.Form["Quantity"][0]),
                Discount = Convert.ToInt32(Request.Form["Discount"][0]),
                IsNew = Convert.ToInt32(Request.Form["IsNew"][0]),
                IsSale = Convert.ToInt32(Request.Form["IsSale"][0]),
                CategoryId = Convert.ToInt32(Request.Form["CategoryId"][0]),
                TagId = Convert.ToInt32(Request.Form["TagId"][0]),
                ColorId = Convert.ToInt32(Request.Form["ColorId"][0]),
                SizeId = Convert.ToInt32(Request.Form["SizeId"][0]),
            };

            var res = _iProductMasterService.Update(model);
            if (res.ISuccess)
            {
                var files = Request.Form.Files;

                //var FolderName = "Images";
                var FolderName = @"wwwroot\Images";
                var PathToSave = Path.Combine(Directory.GetCurrentDirectory(), FolderName);
                int count = 1;
                foreach (var image in files)
                {
                    if (image != null && image.Length > 0)
                    {
                        var PostedFile = image;
                        if (PostedFile.Length > 0)
                        {
                            var FileName = ContentDispositionHeaderValue.Parse(PostedFile.ContentDisposition).FileName.Trim('"');
                            var FullPath = Path.Combine(PathToSave, FileName);

                            using (var stream = new FileStream(FullPath, FileMode.Create))
                            {
                                PostedFile.CopyTo(stream);
                            }

                            var m = new ProductPictureMappingRequest
                            {
                                ProductId = res.Data.Id,
                                PictureName = FileName,
                                PicturePath = FullPath,
                                IsDelete = count
                            };

                            var res1 = _iProductMasterService.AddImageMapping(m);
                            count++;
                        }
                    }
                }
            }
            return Ok(res);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete([FromBody] ValueRequest viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToArray());
            }
            var res = _iProductMasterService.Delete(viewModel.Id);
            if (res.ISuccess)
            {
                return Ok(res);
            }

            return NotFound(res);
        }

        [HttpGet]
        [ActionName("GetProductList")]
        public IActionResult GetProductList()
        {
            var res = _iProductMasterService.GetProductList();
            var resColor = _iProductMasterService.GetProductColorsList();
            var resPicture = _iProductMasterService.GetProductPicturesList();
            var resSize = _iProductMasterService.GetProductSizesList();
            var resTag = _iProductMasterService.GetProductTagsList();
            var resVariant = _iProductMasterService.GetProductVariantsList();


            List<string> list;
            List<variant> variants;


            foreach (var row in res)
            {
                // For Colors
                list = new List<string>();

            }
            return Ok(res);
        }
    }
}