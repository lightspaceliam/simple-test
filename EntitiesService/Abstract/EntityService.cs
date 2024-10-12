using Entities.Abstract;
using Entities.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntitiesService.Abstract;

public abstract class EntityService<T> : IEntityService<T>
	where T : class, IEntity
{
	protected readonly SimpleTestDbContext Db;
	protected readonly ILogger<EntityService<T>> Logger;

	protected EntityService(
		SimpleTestDbContext db,
		ILogger<EntityService<T>> logger)
	{
		Db = db;
		Logger = logger;
	}
	
	/// <summary>
	/// Optimistically finds a record or records by the specified predicate unique to the current type of T.
	/// </summary>
	/// <param name="predicate"></param>
	/// <returns></returns>
	public virtual List<T>? FindByPredicate(Func<T, bool>? predicate = null)
	{
		var query = Db.Set<T>()
			.AsQueryable();

		if (predicate is not null)
		{
			query = query.AsEnumerable()
				.Where(predicate)
				.AsQueryable();
		}
            
		var entities = query
			.ToList();

		return entities;
	}
}