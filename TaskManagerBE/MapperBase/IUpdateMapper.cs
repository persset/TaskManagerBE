namespace TaskManagerBE.MapperBase
{
    public interface IUpdateMapper<TEntity, TDto>
    {
        void MapToEntity(TEntity entity, TDto dto);
    }
}
