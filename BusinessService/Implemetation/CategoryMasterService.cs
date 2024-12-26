using BusinessEntities.Shop.RequestDto;
using BusinessEntities.Shop.ResponseDto;
using BusinessService.Interface;
using System.Collections.Generic;
using AutoMapper;
using Respository.Shop;
using BusinessEntities.Common;
using Respository.Shop;
using Respository.Interface;

namespace BusinessService.Implementation
{
    public class CategoryMasterService : ICategoryMasterService
    {
        private readonly ICategoryMasterRepos _iCategoryMasterRepository;
        private IMapper _mapper;
        public CategoryMasterService(ICategoryMasterRepos repository, IMapper mapper)
        {
            _iCategoryMasterRepository = repository;
            _mapper = mapper;
        }
        public ResultDto<long> Add(CategoryMasterRequest viewModel)
        {
            var res = new ResultDto<long>()
            {
                ISuccess = false,
                Data = 0,
                Errors = new List<string>()
            };
            var response = _iCategoryMasterRepository.Add(viewModel);
            if (response == -1)
            {
                res.Errors.Add("Category Name Already Exists !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = response;
            }
            return res;
        }
        public ResultDto<long> Update(CategoryMasterRequest viewModel)
        {
            var res = new ResultDto<long>()
            {
                ISuccess = false,
                Data = 0,
                Errors = new List<string>()
            };
            var response = _iCategoryMasterRepository.Update(viewModel);
            if (response == -1)
            {
                res.Errors.Add("Category Name Already Exists !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = response;
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
            var response = _iCategoryMasterRepository.Delete(Id);
            if (response == -1)
            {
                res.Errors.Add("Category Does Not Exists For This Id!!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = response;
            }
            return res;
        }

        public ResultDto<IEnumerable<CategoryMasterResponse>> GetAll()
        {
            var res = new ResultDto<IEnumerable<CategoryMasterResponse>>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iCategoryMasterRepository.GetAll();

            if (response == null)
            {
                res.Errors.Add("Data Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<IEnumerable<DBCategoryMaster>, IEnumerable<CategoryMasterResponse>>(response);
            }
            return res;
        }

        public ResultDto<CategoryMasterResponse> GetById(long Id)
        {
            var res = new ResultDto<CategoryMasterResponse>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iCategoryMasterRepository.GetById(Id);
            if (response == null)
            {
                res.Errors.Add("Data Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<DBCategoryMaster, CategoryMasterResponse>(response);
            }

            return res;
        }
    }
}