using AutoMapper;
using CrudWebApiAngularJs.BL.API;
using CrudWebApiAngularJs.BL.API.Handlers;
using CrudWebApiAngularJs.BL.Extensions;
using CrudWebApiAngularJs.Common.API;
using CrudWebApiAngularJs.Common.DTO;
using CrudWebApiAngularJs.DAL.API;
using CrudWebApiAngularJs.DAL.API.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;



namespace CrudWebApiAngularJs.BL.Handlers
{
    public abstract class BaseHandler<TRepository, TDto, TEntity, TKey, TMapper> : IBaseHandler<TDto, TKey>
         where TRepository : IRepository
         where TDto : class, IBaseDto<TKey>
         where TEntity : class, IBaseEntity<TKey>
         where TMapper : IMapper
    {

        protected readonly TRepository repository;
        protected readonly IMapper mapper;
        protected BaseHandler(TRepository repository, TMapper modelMapper)
        {
            this.mapper = modelMapper;
            //IMapper Mapper = AutoMapperConfig
            this.repository = repository;
        }

        /// <summary>
        /// Used by *Any*HandlerFactory to create query depends on roles, should use in all Get logic,
        /// This property return repository.Get() query by default 
        /// </summary>
        protected virtual IQueryable<TEntity> PrefilteredQuery
        {
            get { return repository.Get<TEntity>(); }
        }

        public virtual IHandlerResult<TDto> Add(TDto data)
        {
            var entity = mapper.Map<TDto, TEntity>(data);
            this.repository.Save<TEntity>(entity);
            data.Id = entity.Id;

            return new HandlerResult<TDto>(mapper.Map<TEntity, TDto>(entity));
        }
        public virtual void Delete(TKey id)
        {
            repository.Delete<TEntity>(id);
        }
        public virtual IHandlerResult<IEnumerable<TDto>> Get()
        {            
            var result = mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(PrefilteredQuery);
            return new HandlerResult<IEnumerable<TDto>>(result);
        }
        public virtual IHandlerResult<TDto> Get(TKey id)
        {
            var result = mapper.Map<TEntity, TDto>(PrefilteredQuery.Where("Id = @0", id).FirstOrDefault());
            return new HandlerResult<TDto>(result);
        }

        public virtual IHandlerResult<PageData<TDto>> GetPageData(PagingData pagingData)
        {
            
            var userFiltered = PrefilteredQuery.AndFilter(pagingData.Filters);
            var entities = userFiltered.GetPage(pagingData.SortColumns, pagingData.SkipPageSize, pagingData.TakePageSize);

            IEnumerable<TDto> items = mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(entities);

            var pageData = new PageData<TDto>
            {
                Items = items,
                TotalItems = userFiltered.Count()
            };

            return new HandlerResult<PageData<TDto>>(pageData);
        }

        public virtual IHandlerResult<TDto> Update(TDto data)
        {
            var entity = PrefilteredQuery.Where("Id = @0", data.Id).FirstOrDefault();
            mapper.Map(data, entity);
            repository.Save(entity);
            return new HandlerResult<TDto>(mapper.Map<TEntity, TDto>(entity));
        }
    }
}
