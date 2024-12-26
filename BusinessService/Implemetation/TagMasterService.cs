using BusinessEntities.Shop.RequestDto;
using BusinessEntities.Shop.ResponseDto;
using BusinessService.Interface;
using AutoMapper;
using BusinessEntities.Common;
using Respository.Interface;
using Respository.Shop;

namespace BusinessService.Implementation
{
    public class TagMasterService : ITagMasterService 
    { 
        private readonly ITagMasterRepos _iTagMasterRepository; //Interface
        private IMapper _mapper;
        public TagMasterService(ITagMasterRepos repository, IMapper mapper) //Dependency Injection
        {
            _iTagMasterRepository = repository;
            _mapper = mapper;
        }
        public ResultDto<long> Add(TagMasterRequest viewModel) //method
        {
            var res = new ResultDto<long>()
            {
                ISuccess = false,
                Data = 0,
                Errors = new List<string>()
            };
            var response = _iTagMasterRepository.Add(viewModel);
            if (response == -1)
            {
                res.Errors.Add("Tag Name Already Exists !!");
            }
            else if (response == -2)
            {
                res.Errors.Add("Tag Name length not greater than 5 char long !! !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = response;
            }
            return res;
        }
        public ResultDto<long> Update(TagMasterRequest viewModel)
        {
            var res = new ResultDto<long>()
            {
                ISuccess = false,
                Data = 0,
                Errors = new List<string>()
            };
            var response = _iTagMasterRepository.Update(viewModel);
            if (response == -1)
            {
                res.Errors.Add("Tag Name Already Exists !!");
            }
            else if (response == -2)
            {
                res.Errors.Add("Tag Name length not greater than 5 char long !! !!");
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
            var response = _iTagMasterRepository.Delete(Id);
            if (response == -1)
            {
                res.Errors.Add("Tag Does Not Exists For This Id!!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = response;
            }
            return res;
        }

        public ResultDto<IEnumerable<TagMasterResponse>> GetAll()
        {
            var res = new ResultDto<IEnumerable<TagMasterResponse>>()
            {
                ISuccess = true,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iTagMasterRepository.GetAll();

            if (response == null)
            {
                res.Errors.Add("Data Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<IEnumerable<DBTagMaster>, IEnumerable<TagMasterResponse>>(response);
            }
            return res;
        }

        public ResultDto<TagMasterResponse> GetById(long Id)
        {
            var res = new ResultDto<TagMasterResponse>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iTagMasterRepository.GetById(Id);
            if (response == null)
            {
                res.Errors.Add("Data Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<DBTagMaster, TagMasterResponse>(response);
            }

            return res;
        }
    }
}
