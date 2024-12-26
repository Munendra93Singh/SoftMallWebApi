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
    public class ColorMasterService : IColorMasterService
    {
        private readonly IColorMasterRepos _iColorMasterRepository; //interface
        private IMapper _mapper;
        public ColorMasterService(IColorMasterRepos repository, IMapper mapper) //Dependency Injection
        {
            _iColorMasterRepository = repository;
            _mapper = mapper;
        }
        public ResultDto<long> Add(ColorMasterRequest ViewModel)
        {
            var res = new ResultDto<long>()
            {
                ISuccess = false,
                Data = 0,
                Errors = new List<string>()
            };
            var response = _iColorMasterRepository.Add(ViewModel);
            if (response == -1)
            {
                res.Errors.Add("Color Name Already Exists !!");
            }
            else if (response == -2)
            {
                res.Errors.Add("Color Name Length not greater than 5 char long !!");
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
            var respnse = _iColorMasterRepository.Delete(Id);
            if(respnse == -1)
            {
                res.Errors.Add("Color Does Not Exists For this Id");
            }
            else
            {
                res.ISuccess= true;
                res.Data = respnse;
            }
            return res;
        }

        public ResultDto<IEnumerable<ColorMasterResponse>> GetAll()
        {
            var res = new ResultDto<IEnumerable<ColorMasterResponse>>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iColorMasterRepository.GetAll();

            if (response == null)
            {
                res.Errors.Add("Data Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<IEnumerable<DBColorMaster>, IEnumerable<ColorMasterResponse>>(response);
            }
            return res;
        }

        public ResultDto<ColorMasterResponse> GetById(long Id)
        {
            var res = new ResultDto<ColorMasterResponse>()
            {
                ISuccess = false,
                Data = null,
                Errors = new List<string>()
            };

            var response = _iColorMasterRepository.GetById(Id);
            if (response == null)
            {
                res.Errors.Add("Data Not Found !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = _mapper.Map<DBColorMaster, ColorMasterResponse>(response);
            }

            return res;
        }

        public ResultDto<long> Update(ColorMasterRequest ViewModel)
        {
            var res = new ResultDto<long>()
            {
                ISuccess = false,
                Data = 0,
                Errors = new List<string>()
            };
            var response = _iColorMasterRepository.Update(ViewModel);
            if(response == -1)
            {
                res.Errors.Add("Color Name Already Exits");
            }
            else if(response == -2) 
            {
                res.Errors.Add("Color name length not greater than 5 char long !!");
            }
            else
            {
                res.ISuccess = true;
                res.Data = response;
            }
            return res;
        }
    }
}
