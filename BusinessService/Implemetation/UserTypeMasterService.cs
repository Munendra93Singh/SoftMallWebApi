using AutoMapper;
using BusinessEntities.Common;
using BusinessEntities.Shop.RequestDto;
using BusinessEntities.Shop.ResponseDto;
using BusinessService.Interface;
using Microsoft.EntityFrameworkCore;
using Respository.Interface;
using Respository.Shop;
using System.Collections.Generic;


namespace BusinessService.Implemetation
{
    public class UserTypeMasterService : IUserTypeMasterService
    {
        private readonly IUserTypeMasterRepos _iUserTypeMasterRepository;
        private IMapper _mapper;
        public UserTypeMasterService(IUserTypeMasterRepos repository, IMapper mapper)
        {
            _iUserTypeMasterRepository = repository;
            _mapper = mapper;
        }
        public ResultDto<long> Add(UserTypeMasterRequest viewModel)
        {
            var res = new ResultDto<long>()
            {
                ISuccess = false,
                Data = 0,
                Errors = new List<string>()
            };
            var response = _iUserTypeMasterRepository.Add(viewModel);
            if (response == -1)
            {
                res.Errors.Add("UserType Name Already Exists !!");
            }
            else if (response == -2)
            {
                res.Errors.Add("UserType Name length not greater than 5 char long !! !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = response;
            }
            return res;
        }
        public ResultDto<long> Update(UserTypeMasterRequest viewModel)
        {
            var res = new ResultDto<long>()
            {
                ISuccess = false,
                Data = 0,
                Errors = new List<string>()
            };
            var response = _iUserTypeMasterRepository.Update(viewModel);
            if (response == -1)
            {
                res.Errors.Add("UserType Name Already Exists !!");
            }
            else if (response == -2)
            {
                res.Errors.Add("UserType Name length not greater than 5 char long !! !!");
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
            var response = _iUserTypeMasterRepository.Delete(Id);
            if (response == -1)
            {
                res.Errors.Add("UserType Does Not Exists For This Id!!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = response;
            }
            return res;
        }

        public ResultDto<IEnumerable<UserTypeMasterResponse>> GetAll()
        {
            var res = new ResultDto<IEnumerable<UserTypeMasterResponse>>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iUserTypeMasterRepository.GetAll();

            if (response == null)
            {
                res.Errors.Add("Data Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<IEnumerable<DBUserTypeMaster>, IEnumerable<UserTypeMasterResponse>>(response);
            }
            return res;
        }

        public ResultDto<UserTypeMasterResponse> GetById(long Id)
        {
            var res = new ResultDto<UserTypeMasterResponse>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iUserTypeMasterRepository.GetById(Id);
            if (response == null)
            {
                res.Errors.Add("Data Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<DBUserTypeMaster, UserTypeMasterResponse>(response);
            }

            return res;
        }
    }
}
