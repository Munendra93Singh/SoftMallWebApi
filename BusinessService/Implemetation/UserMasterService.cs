using AutoMapper;
using BusinessEntities.Common;
using BusinessEntities.Shop.RequestDto;
using BusinessEntities.Shop.ResponseDto;
using BusinessService.Interface;
using Respository.Interface;
using Respository.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService.Implemetation
{
    public class UserMasterService : IUserMasterService
    {
        private readonly IUserMasterRepos _iUserMasterRepository;
        private IMapper _mapper;
        public UserMasterService(IUserMasterRepos repository, IMapper mapper)
        {
            _iUserMasterRepository = repository;
            _mapper = mapper;
        }
        public ResultDto<long> Add(UserMasterRequest viewModel)
        {
            var res = new ResultDto<long>()
            {
                ISuccess = false,
                Data = 0,
                Errors = new List<string>()
            };
            var response = _iUserMasterRepository.Add(viewModel);
            if (response == -1)
            {
                res.Errors.Add("User Email Id Already Exists !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = response;
            }
            return res;
        }
        public ResultDto<long> Update(UserMasterRequest viewModel)
        {
            var res = new ResultDto<long>()
            {
                ISuccess = false,
                Data = 0,
                Errors = new List<string>()
            };
            var response = _iUserMasterRepository.Update(viewModel);
            if (response == -1)
            {
                res.Errors.Add("User Email Id Already Exists !!");
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
            var response = _iUserMasterRepository.Delete(Id);
            if (response == -1)
            {
                res.Errors.Add("User Does Not Exists For This Id!!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = response;
            }
            return res;
        }

        public ResultDto<IEnumerable<UserMasterResponse>> GetAll()
        {
            var res = new ResultDto<IEnumerable<UserMasterResponse>>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iUserMasterRepository.GetAll();

            if (response == null)
            {
                res.Errors.Add("Data Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<IEnumerable<DBUserMaster>, IEnumerable<UserMasterResponse>>(response);
            }
            return res;
        }

        public ResultDto<UserMasterResponse> GetById(long Id)
        {
            var res = new ResultDto<UserMasterResponse>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iUserMasterRepository.GetById(Id);
            if (response == null)
            {
                res.Errors.Add("Data Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<DBUserMaster, UserMasterResponse>(response);
            }

            return res;
        }

        public ResultDto<UserMasterLoginResponse> Login(LoginRequest model)
        {
            var res = new ResultDto<UserMasterLoginResponse>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iUserMasterRepository.Login(model);
            if (response == null)
            {
                res.Errors.Add("User Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<DBUserMasterLogin, UserMasterLoginResponse>(response);
            }

            return res;
        }
    }
}