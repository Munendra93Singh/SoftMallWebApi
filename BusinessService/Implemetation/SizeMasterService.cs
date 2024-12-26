using AutoMapper;
using BusinessEntities.Common;
using BusinessEntities.Shop.RequestDto;
using BusinessEntities.Shop.ResponseDto;
using BusinessService.Interface;
using Respository.Interface;
using Respository.Shop;

namespace BusinessService.Implemetation
{
    public class SizeMasterService : ISizeMasterService
    {
        private readonly ISizeMasterRepos _iSizeMasterRepository; //interface
        private IMapper _mapper;
        public SizeMasterService(ISizeMasterRepos repository, IMapper mapper) //Dependency Injection
        {
            _iSizeMasterRepository = repository;
            _mapper = mapper;
        }
        public ResultDto<long> Add(SizeMasterRequest viewModel) //Method
        {
            var res = new ResultDto<long>()
            {
                ISuccess = false,
                Data = 0,
                Errors = new List<string>()
        };
            var response = _iSizeMasterRepository.Add(viewModel);
            if (response == -1)
            {
                res.Errors.Add("Size Name Already Exists!!");
            }
            else if(response==-2)
            {
                res.Errors.Add("Size NAme length not greater than 5 cha long !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = response;
            }
            return res;
        }
        public ResultDto<long> Update(SizeMasterRequest viewModel)
        {
            var res = new ResultDto<long>()
            {
                ISuccess = false,
                Data = 0,
                Errors = new List<string>()
            };
            var response = _iSizeMasterRepository.Update(viewModel);
            if (response == -1)
            {
                res.Errors.Add("Size Name Already Exists !!");
            }
            else if (response == -2)
            {
                res.Errors.Add("Size Name length not greater than 5 char long !! !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = response;
            }
            return res;
        }
        public ResultDto<long> Delete(long ID)
        {
            var res = new ResultDto<long>()
            {
                ISuccess = false,
                Data = 0,
                Errors = new List<string>()
            };
            var response = _iSizeMasterRepository.Delete(ID);
            if (response == -1)
            {
                res.Errors.Add("Size Does Not Exists For This Id!!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = response;
            }
            return res;
        }

        public ResultDto< IEnumerable<SizeMasterResponse>> GetAll()
        {
            var res = new ResultDto<IEnumerable<SizeMasterResponse>>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iSizeMasterRepository.GetAll();

            if (response == null)
            {
                res.Errors.Add("Data Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<IEnumerable<DBSizeMaster>, IEnumerable<SizeMasterResponse>>(response);
            }
            return res;
        }

        public ResultDto<SizeMasterResponse> GetById(long Id)
        {
            var res = new ResultDto<SizeMasterResponse>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iSizeMasterRepository.GetById(Id);
            if (response == null)
            {
                res.Errors.Add("Data Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<DBSizeMaster, SizeMasterResponse>(response);
            }

            return res;
        }


    }
}
