using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Entities.DbContexts;

public class SimpleTestDbContextFactory : IDesignTimeDbContextFactory<SimpleTestDbContext>
{
	public SimpleTestDbContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<SimpleTestDbContext>();
		//  Local Windows - not tested.
		// optionsBuilder.UseSqlServer("Server=localhost;Database=SimpleTestDbContext;Integrated Security=True;MultipleActiveResultSets=True");

		//  Docker - you will need to add, name and set your own: container and credentials.
		optionsBuilder.UseSqlServer(
			"Server=tcp:localhost,1433;Initial Catalog=SimpleTestDbContext;Persist Security Info=False;User ID=SA;Password=Local@DevPa55word;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");

		return new SimpleTestDbContext(optionsBuilder.Options);
	}
}