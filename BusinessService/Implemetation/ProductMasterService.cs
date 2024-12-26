using BusinessEntities.Shop.RequestDto;
using BusinessEntities.Shop.ResponseDto;
using BusinessService.Interface;
using System.Collections.Generic;
using AutoMapper;
using BusinessEntities.Common;
using Respository.Interface;
using Respository.Shop;
using Repositories.Implementation;
using Repositories.Shop;


namespace BusinessService.Implemetation
{
    public class ProductMasterService : IProductMasterService
    {
        private readonly IProductMasterRepos _iproductMasterRepos;
        private IMapper _mapper;

        public ProductMasterService(IProductMasterRepos productMasterRepos, IMapper mapper)
        {
            _iproductMasterRepos = productMasterRepos;
            _mapper = mapper;
        }

        public ResultDto<ProductMasterResponse> Add(ProductMasterRequest viewModel)
        {
            var res = new ResultDto<ProductMasterResponse>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            var response = _iproductMasterRepos.Add(viewModel);
            if (response == null)
            {
                res.Errors.Add("Product Name Already Exists !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<DBProductMaster, ProductMasterResponse>(response);
            }
            return res;
        }
        public ResultDto<ProductMasterResponse> Update(ProductMasterRequest viewModel)
        {
            var res = new ResultDto<ProductMasterResponse>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            var response = _iproductMasterRepos.Update(viewModel);
            if (response == null)
            {
                res.Errors.Add("Product Name Already Exists !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<DBProductMaster, ProductMasterResponse>(response);
            }
            return res;
        }
       public ResultDto<long> Delete(long Id)
        {
            var res = new ResultDto<long>()
            {
                ISuccess = false,
                Data = 0,
                Errors = new List<string>()
            };
            var response = _iproductMasterRepos.Delete(Id);
            if (response == -1)
            {
                res.Errors.Add("Product Does Not Exists For This Id!!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = response;
            }
            return res;
        }

        public ResultDto<IEnumerable<ProductMasterResponse>> GetAll()
        {
            var res = new ResultDto<IEnumerable<ProductMasterResponse>>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iproductMasterRepos.GetAll();

            if (response == null)
            {
                res.Errors.Add("Data Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<IEnumerable<DBProductMaster>, IEnumerable<ProductMasterResponse>>(response);
            }
            return res;
        }

        public ResultDto<ProductMasterResponse> GetById(long Id)
        {
            var res = new ResultDto<ProductMasterResponse>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iproductMasterRepos.GetById(Id);
            if (response == null)
            {
                res.Errors.Add("Data Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<DBProductMaster, ProductMasterResponse>(response);
            }

            return res;
        }

        public ResultDto<long> AddImageMapping(ProductPictureMappingRequest viewModel)
        {
            var res = new ResultDto<long>()
            {
                ISuccess = false,
                Data = 0,
                Errors = new List<string>()
            };
            var response = _iproductMasterRepos.AddImageMapping(viewModel);
            if (response == -1)
            {
                res.Errors.Add("Product Picture Already Exists !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = response;
            }
            return res;
        }

        public IEnumerable<ProductListResponse> GetProductList()
        {
            var response = _iproductMasterRepos.GetProductList();
            var res = _mapper.Map<IEnumerable<DBProductList>, IEnumerable<ProductListResponse>>(response);
            return res;
        }


       
        public ResultDto<IEnumerable<ProductListColorsResponse>> GetProductColorsList()
        {
            var res = new ResultDto<IEnumerable<ProductListColorsResponse>>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iproductMasterRepos.GetProductColorsList();

            if (response == null)
            {
                res.Errors.Add("Data Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<IEnumerable<DBProductListColors>, IEnumerable<ProductListColorsResponse>>(response);
            }
            return res;
        }

        public ResultDto<IEnumerable<ProductListPicturesResponse>> GetProductPicturesList()
        {
            var res = new ResultDto<IEnumerable<ProductListPicturesResponse>>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iproductMasterRepos.GetProductPicturesList();

            if (response == null)
            {
                res.Errors.Add("Data Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<IEnumerable<DBProductListPictures>, IEnumerable<ProductListPicturesResponse>>(response);
            }
            return res;
        }

        public ResultDto<IEnumerable<ProductListSizesResponse>> GetProductSizesList()
        {
            var res = new ResultDto<IEnumerable<ProductListSizesResponse>>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iproductMasterRepos.GetProductSizesList();

            if (response == null)
            {
                res.Errors.Add("Data Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<IEnumerable<DBProductListSizes>, IEnumerable<ProductListSizesResponse>>(response);
            }
            return res;
        }

        public ResultDto<IEnumerable<ProductListTagsResponse>> GetProductTagsList()
        {
            var res = new ResultDto<IEnumerable<ProductListTagsResponse>>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iproductMasterRepos.GetProductTagsList();

            if (response == null)
            {
                res.Errors.Add("Data Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<IEnumerable<DBProductListTags>, IEnumerable<ProductListTagsResponse>>(response);
            }
            return res;
        }

        public ResultDto<IEnumerable<ProductListVariantsResponse>> GetProductVariantsList()
        {
            var res = new ResultDto<IEnumerable<ProductListVariantsResponse>>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iproductMasterRepos.GetProductVariantsList();

            if (response == null)
            {
                res.Errors.Add("Data Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<IEnumerable<DBProductListVariants>, IEnumerable<ProductListVariantsResponse>>(response);
            }
            return res;
        }
    }
}