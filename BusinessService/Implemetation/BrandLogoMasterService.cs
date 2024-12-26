using AutoMapper;
using BusinessEntities.Common;
using BusinessEntities.Shop.RequestDto;
using BusinessEntities.Shop.ResponseDto;
using BusinessService.Interface;
using Respository.Interface;
using Respository.Shop;

namespace BusinessService.Implemetation
{
    public class BrandLogoMasterService : IBrandLogoMasterService
    {
        private readonly IBrandLogoMasterRepos _iBrandLogoMasterRepository;
        private IMapper _mapper;
        public BrandLogoMasterService(IBrandLogoMasterRepos repository, IMapper mapper)
        {
            _iBrandLogoMasterRepository = repository;
            _mapper = mapper;
        }
        public ResultDto<long> Add(BrandLogoMasterRequest viewModel)
        {
            var res = new ResultDto<long>()
            {
                ISuccess = false,
                Data = 0,
                Errors = new List<string>()
            };
            var response = _iBrandLogoMasterRepository.Add(viewModel);
            if (response == -1)
            {
                res.Errors.Add("BrandLogo Name Already Exists !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = response;
            }
            return res;
        }
        public ResultDto<long> Update(BrandLogoMasterRequest viewModel)
        {
            var res = new ResultDto<long>()
            {
                ISuccess = false,
                Data = 0,
                Errors = new List<string>()
            };
            var response = _iBrandLogoMasterRepository.Update(viewModel);
            if (response == -1)
            {
                res.Errors.Add("BrandLogo Name Already Exists !!");
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
            var response = _iBrandLogoMasterRepository.Delete(Id);
            if (response == -1)
            {
                res.Errors.Add("BrandLogo Does Not Exists For This Id!!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = response;
            }
            return res;
        }

        public ResultDto<IEnumerable<BrandLogoMasterResponse>> GetAll()
        {
            var res = new ResultDto<IEnumerable<BrandLogoMasterResponse>>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iBrandLogoMasterRepository.GetAll();

            if (response == null)
            {
                res.Errors.Add("Data Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<IEnumerable<DBBrandLogoMaster>, IEnumerable<BrandLogoMasterResponse>>(response);
            }
            return res;
        }

        public ResultDto<BrandLogoMasterResponse> GetById(long Id)
        {
            var res = new ResultDto<BrandLogoMasterResponse>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iBrandLogoMasterRepository.GetById(Id);
            if (response == null)
            {
                res.Errors.Add("Data Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<DBBrandLogoMaster, BrandLogoMasterResponse>(response);
            }

            return res;
        }
    }
}