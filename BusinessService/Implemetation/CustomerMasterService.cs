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
    public class CustomerMasterService : ICustomerMasterService
    {
        private readonly ICustomerMasterRepos _iCustomerMasterRepository;
        private IMapper _mapper;
        public CustomerMasterService(ICustomerMasterRepos repository, IMapper mapper)
        {
            _iCustomerMasterRepository = repository;
            _mapper = mapper;
        }
        public ResultDto<long> Add(CustomerMasterRequest viewModel)
        {
            var res = new ResultDto<long>()
            {
                ISuccess = false,
                Data = 0,
                Errors = new List<string>()
            };
            var response = _iCustomerMasterRepository.Add(viewModel);
            if (response == -1)
            {
                res.Errors.Add("Customer Email Id Already Exists !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = response;
            }
            return res;
        }
        public ResultDto<long> Update(CustomerMasterRequest viewModel)
        {
            var res = new ResultDto<long>()
            {
                ISuccess = false,
                Data = 0,
                Errors = new List<string>()
            };
            var response = _iCustomerMasterRepository.Update(viewModel);
            if (response == -1)
            {
                res.Errors.Add("Customer Email Id Already Exists !!");
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
            var response = _iCustomerMasterRepository.Delete(Id);
            if (response == -1)
            {
                res.Errors.Add("Customer Does Not Exists For This Id!!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = response;
            }
            return res;
        }

        public ResultDto<IEnumerable<CustomerMasterResponse>> GetAll()
        {
            var res = new ResultDto<IEnumerable<CustomerMasterResponse>>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iCustomerMasterRepository.GetAll();

            if (response == null)
            {
                res.Errors.Add("Data Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<IEnumerable<DBCustomerMaster>, IEnumerable<CustomerMasterResponse>>(response);
            }
            return res;
        }

        public ResultDto<CustomerMasterResponse> GetById(long Id)
        {
            var res = new ResultDto<CustomerMasterResponse>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iCustomerMasterRepository.GetById(Id);
            if (response == null)
            {
                res.Errors.Add("Data Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<DBCustomerMaster, CustomerMasterResponse>(response);
            }

            return res;
        }

        public ResultDto<CustomerMasterLoginResponse> Login(LoginRequest model)
        {
            var res = new ResultDto<CustomerMasterLoginResponse>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iCustomerMasterRepository.Login(model);
            if (response == null)
            {
                res.Errors.Add("Customer Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<DBCustomerMasterLogin, CustomerMasterLoginResponse>(response);
            }

            return res;
        }
    }
}