using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Enums;
using Data;
using Data.Interfaces;
using Data.Services;
using Entity.DTOs;
using Entity.Model;

namespace Business.Services
{
    public class BaseModelBusiness<T, D> : ABaseModelBusiness<T, D> where T : BaseModel where D : BaseDto
    {
        private readonly IBaseModelData<T, D> _data;
        private readonly IMapper _mapper;

        public BaseModelBusiness(IBaseModelData<T, D> data, IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
        }

        public override async Task<bool> DeleteAsync(int id, DeleteMode mode)
        {
            IDeleteStrategy<T, D> strategy = mode == DeleteMode.fisico
                ? new DeleteStrategy<T, D>()
                : new LogicalDeleteStrategy<T, D>();

            var result = await strategy.DeleteAsync(id, _data);
            return result;
        }


        public override async Task<List<D>> GetAllAsync()
        {
            var lstDto = await _data.GetAllAsync();
            return lstDto.ToList();
        }

        public override async Task<D> CreateAsync(D dto)
        {
            var entity = _mapper.Map<T>(dto);
            entity = await _data.CreateAsync(entity);
            return _mapper.Map<D>(entity);
        }

        public override async Task UpdateAsync(D dto)
        {
            var entity = _mapper.Map<T>(dto);
            await _data.UpdateAsync(entity);
        }
    }
}
