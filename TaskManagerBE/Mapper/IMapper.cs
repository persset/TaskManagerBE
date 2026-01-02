public interface IMapper<TEntity, TDTO>
{
    TEntity ToEntity(TDTO dto);
    TDTO ToDTO(TEntity entity);
}
