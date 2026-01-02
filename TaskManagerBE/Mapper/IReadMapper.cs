public interface IReadMapper<TEntity, TDto>
{
    TDto ToDto(TEntity entity);
}
