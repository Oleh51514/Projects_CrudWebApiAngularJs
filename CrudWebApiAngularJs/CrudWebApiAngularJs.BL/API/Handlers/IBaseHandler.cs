using CrudWebApiAngularJs.Common.DTO;
using System.Collections.Generic;


namespace CrudWebApiAngularJs.BL.API.Handlers
{
    public interface IBaseHandler<TDto, TKey> where TDto : class
    {
        IHandlerResult<TDto> Get(TKey id);

        IHandlerResult<IEnumerable<TDto>> Get();

        IHandlerResult<PageData<TDto>> GetPageData(PagingData pagingData);

        IHandlerResult<TDto> Add(TDto data);

        IHandlerResult<TDto> Update(TDto data);

        void Delete(TKey id);
    }
}
