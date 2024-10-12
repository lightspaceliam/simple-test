namespace EntitiesService.Abstract;

public interface IEntityService<T>
{
	List<T>? FindByPredicate(Func<T, bool>? predicate = null);
}