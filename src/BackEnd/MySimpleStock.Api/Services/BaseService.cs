using AutoMapper;
using FluentValidation;
using MySimpleStock.Api.Models;
using MySimpleStock.Api.Models.Entity;
using MySimpleStock.Api.Models.ViewModel;
using MySimpleStock.Api.Repositories;

namespace MySimpleStock.Api.Services
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

        public virtual async Task<ResponseApiModel<T>> CreateAsync(T entity)
        {
            entity.Id = null;
            var validation = _validator.Validate(entity);
            if (!validation.IsValid)
                return new ResponseApiModel<T>(validation.Errors);
            try
            {
                var mapperModel = _mapper.Map<A>(entity);
                var res = await _repository.CreateAsync(mapperModel);
                if (res == null)
                    return new ResponseApiModel<T>("Erro ao tentar criar registro!");

                entity.Id = mapperModel.Id.ToString();
                return new ResponseApiModel<T>(entity);
            }
            catch (Exception)
            {
                return new ResponseApiModel<T>("Erro interno no servidor!");
            }

        }

        public virtual async Task<ResponseApiModel<T>> UpdateAsync(T entity)
        {
            var validation = _validator.Validate(entity);
            if (!validation.IsValid)
                return new ResponseApiModel<T>(validation.Errors);
            try
            {
                var mapperModel = _mapper.Map<A>(entity);

                var res = await _repository.UpdateAsync(mapperModel);
                if (res == null)
                    return new ResponseApiModel<T>("Erro ao tentar atualizar registro!");

                entity.Id = mapperModel.Id.ToString();
                return new ResponseApiModel<T>(entity);
            }
            catch (Exception)
            {
                return new ResponseApiModel<T>("Erro interno no servidor!");
            }
        }

        public virtual async Task<ResponseApiModel<T>> DeleteAsync(Guid id, Guid userId)
        {
            try
            {
                var entity = await _repository.GetById(id, userId);
                if (entity == null)
                    return new ResponseApiModel<T>("Id", "Id não encontrado!");

                await _repository.DeleteAsync(entity);
                return new ResponseApiModel<T>();
            }
            catch (Exception)
            {
                return new ResponseApiModel<T>("Erro interno no servidor");
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
