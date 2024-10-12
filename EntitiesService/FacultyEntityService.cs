using Entities;
using Entities.DbContexts;
using EntitiesService.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntitiesService;

public class FacultyEntityService : EntityService<Faculty>
{
	public FacultyEntityService(
		SimpleTestDbContext db,
		ILogger<EntityService<Faculty>> logger) : base(db, logger)
	{ }

	public override List<Faculty>? FindByPredicate(Func<Faculty, bool>? predicate = null)
	{
		var query = Db.Set<Faculty>()
			.Include(p => p.StudentFaculties)
			.ThenInclude(p => p.Student)
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