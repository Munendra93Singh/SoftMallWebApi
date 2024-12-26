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
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepos _iContactUsRepository;
        private IMapper _mapper;
        public ContactUsService(IContactUsRepos repository, IMapper mapper)
        {
            _iContactUsRepository = repository;
            _mapper = mapper;
        }
        public ResultDto<long> Add(ContactUsRequest viewModel)
        {
            var res = new ResultDto<long>()
            {
                ISuccess = false,
                Data = 0,
                Errors = new List<string>()
            };
            var response = _iContactUsRepository.Add(viewModel);
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
            var response = _iContactUsRepository.Delete(Id);
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

        public ResultDto<IEnumerable<ContactUsResponse>> GetAll()
        {
            var res = new ResultDto<IEnumerable<ContactUsResponse>>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iContactUsRepository.GetAll();

            if (response == null)
            {
                res.Errors.Add("Data Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<IEnumerable<DBContactUs>, IEnumerable<ContactUsResponse>>(response);
            }
            return res;
        }
    }
}
