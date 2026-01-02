public interface ICreateMapper<TEntity, TDto>
{
    TEntity ToEntity(TDto dto);
}
