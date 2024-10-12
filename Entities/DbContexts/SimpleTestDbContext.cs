using System.Reflection;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Entities.DbContexts;

public class SimpleTestDbContext : DbContext
{
	public SimpleTestDbContext(DbContextOptions<SimpleTestDbContext> options)
		: base (options) { }

	public SimpleTestDbContext() { }
	
	public DbSet<Student> Students { get; set; }
	public DbSet<Faculty> Faculties { get; set; }
	public DbSet<StudentFaculty> StudentFaculty { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		var entityTypes = Assembly.GetExecutingAssembly().GetTypes()
			.Where(type => type.IsClass
			               && !type.IsAbstract
			               && type.IsSubclassOf(typeof(EntityBase)))
			.ToList();
		
		foreach (var entityType in entityTypes)
		{
			var idProperty = entityType.GetProperty("Id");

			if (idProperty == null) continue;
			
			//  Set default value for Guid primary keys
			if (idProperty.PropertyType == typeof(Guid?))
			{
				modelBuilder.Entity(entityType).Property("Id").HasDefaultValueSql("NEWID()");
			}

			#region Index's

			modelBuilder.Entity<Student>(entity =>
			{
				entity.HasIndex(e => e.FirstName);
				entity.HasIndex(e => e.LastName);
			});
			
			modelBuilder.Entity<Faculty>(entity =>
			{
				entity.HasIndex(e => e.Name);
				entity.HasIndex(e => e.Name).IsUnique();
			});

			#endregion

			#region Many to Many relationships

			modelBuilder.Entity<StudentFaculty>()
				.HasOne(e => e.Faculty)
				.WithMany(e => e.StudentFaculties)
				.OnDelete(DeleteBehavior.Restrict);
			
			modelBuilder.Entity<StudentFaculty>()
				.HasOne(e => e.Student)
				.WithMany(e => e.StudentFaculties)
				.OnDelete(DeleteBehavior.Restrict);

			#endregion
		}
	}
}