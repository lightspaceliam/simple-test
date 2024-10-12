using Entities;
using Entities.DbContexts;
using EntitiesService.Abstract;
using Microsoft.Extensions.Logging;

namespace EntitiesService;

public class StudentEntityService : EntityService<Student>
{
	public StudentEntityService(
		SimpleTestDbContext db, 
		ILogger<EntityService<Student>> logger) : base(db, logger)
	{ }
}