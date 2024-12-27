using AutoMapper;
using FluentValidation;
using MyGoodStock.Api.Models;
using MyGoodStock.Api.Models.Entity;
using MyGoodStock.Api.Models.ViewModel;
using MyGoodStock.Api.Repositories;

namespace MyGoodStock.Api.Services
{
    public class BaseService<T, A> where T : BaseViewModel where A : BaseEntity
    {
        protected readonly BaseRepository<A> _repository;
        protected readonly IMapper _mapper;
        protected readonly IValidator<T> _validator;

        public BaseService(BaseRepository<A> repository, IMapper mapper, IValidator<T> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public virtual async Task<ResponseApiModel> CreateAsync(T entity)
        {
            var validation = _validator.Validate(entity);
            if (!validation.IsValid)
                return new ResponseApiModel(validation.Errors);
            try
            {
                var mapperModel = _mapper.Map<A>(entity);
                var res = await _repository.CreateAsync(mapperModel);
                if (res == null)
                    return new ResponseApiModel("Erro ao tentar criar registro!");
                return new ResponseApiModel();
            }
            catch (Exception)
            {
                return new ResponseApiModel("Erro interno no servidor!");
            }

        }

        public virtual async Task<ResponseApiModel> UpdateAsync(T entity)
        {
            var validation = _validator.Validate(entity);
            if (!validation.IsValid)
                return new ResponseApiModel(validation.Errors);
            try
            {
                var mapperModel = _mapper.Map<A>(entity);
                var res = await _repository.UpdateAsync(mapperModel);
                if (res == null)
                    return new ResponseApiModel("Erro ao tentar atualizar registro!");
                return new ResponseApiModel();
            }
            catch (Exception)
            {
                return new ResponseApiModel("Erro interno no servidor!");
            }
        }

        public virtual async Task<ResponseApiModel> DeleteAsync(Guid id, Guid userId)
        {
            try
            {
                var entity = await _repository.GetById(id, userId);
                if (entity == null)
                    return new ResponseApiModel("Id", "Id não encontrado!");
                var mapperModel = _mapper.Map<A>(entity);
                await _repository.DeleteAsync(mapperModel);
                return new ResponseApiModel();
            }
            catch (Exception)
            {
                return new ResponseApiModel("Erro interno no servidor");
            }
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(Guid userId)
        {
            var res = await _repository.GetAll(userId);
            return _mapper.Map<IEnumerable<T>>(res);
        }

        public virtual async Task<T> GetOneAsync(Guid id, Guid userId)
        {
            var res = await _repository.GetById(id, userId);
            return _mapper.Map<T>(res);
        }
    }
}
