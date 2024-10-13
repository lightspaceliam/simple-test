// See https://aka.ms/new-console-template for more information
using Entities.DbContexts;
using EntitiesService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimpleTests.SeedData;

var host = Host.CreateDefaultBuilder(args)
	.ConfigureAppConfiguration((context, config) =>
	{
		/*
		 HACK: override the project base path for simple use of reading the appsettings file.
		 Normally sensitive configuration properties stored in UserSecrets or a Key Vault. 
		 */
		// config.AddUserSecrets<Program>();
		
		var projectPath = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).FullName;
		config.SetBasePath(projectPath);
		
		//  Pick up configuration settings.
		config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
	})
	.ConfigureLogging(logging =>
	{
		logging.AddConsole();
	})
	.ConfigureServices((hostContext, services) =>
	{
		services.AddLogging();
		
		services.AddDbContext<SimpleTestDbContext>(options =>
		{
			options.UseSqlServer(
				hostContext.Configuration["ConnectionStrings:DockerConnection"],
				optionsBuilder =>
				{
					optionsBuilder.ExecutionStrategy(
						context => new SqlServerRetryingExecutionStrategy(context, 10, TimeSpan.FromMilliseconds(200), null));
				});
		});
		
		services.AddTransient<StudentEntityService>();
		services.AddTransient<FacultyEntityService>();
	})
	.Build();

/*
 * Given the variable declaration in C#: 
 * provide code that creates an array of the even numbers in ascending order
 */
Console.WriteLine("\n\nProvide code that creates an array of the even numbers in ascending order:\n");
var numbers = new List<int> { 5, 10, 8, 3, 6, 12};

var sortedAndEven = numbers
	.Where(p => p % 2 == 0)
	.OrderBy(p => p)
	.ToList();

foreach (var item in sortedAndEven)
{ 
	Console.WriteLine($"Nbr: {item}");
}

/*
 * Given the variable declaration in C#:
 * provide a code example of "x" being used (assume it's been initialised)
 */
Console.WriteLine("\n\nProvide a code example of \"x\" being used (assume it's been initialised):\n");

Func<int, bool, string> myFunc = (number, flag) =>
{
	numbers.Add(number);
	if (flag)
	{
		var even = numbers
			.Where(p => p % 2 == 0)
			.OrderBy(p => p)
			.ToList();
		
		return string.Join(", ", even);
	}
	var odd = numbers
		.Where(p => p % 2 != 0)
		.OrderBy(p => p)
		.ToList();
	
	return string.Join(", ", odd);
};

Console.WriteLine($"Odd: {myFunc(11, false)}");
Console.WriteLine($"Even: {myFunc(20, true)}");

/*
 * Given the following database tables, write an SQL query to return the names of students in the faculty named "Medicine"
 */
Console.WriteLine("\n\nGiven the following database tables, write an SQL query to return the names of students in the faculty named “Medicine”:\n");

//  Seed.
var studentService = host.Services.GetRequiredService<StudentEntityService>();
var facultyService = host.Services.GetRequiredService<FacultyEntityService>();

var hasStudents = (studentService.FindByPredicate() ?? new())
	.Any();

//  Apply Auto Migrations.
var context = host.Services.GetRequiredService<SimpleTestDbContext>();
context.Database.Migrate();

//  Seed database but only if there is no data.
if (!hasStudents)
{
	Console.WriteLine($"Seed data - Students, Faculties and many to many relationship.");
	context.Students.AddRange(StudentFacultySeedData.Students);
	context.Faculties.AddRange(StudentFacultySeedData.Faculties);
	context.StudentFaculty.AddRange(StudentFacultySeedData.StudentFaculties);
	await context.SaveChangesAsync();	
}

const string facultyName = "Medicine";

/*
 * Get all students assigned to the faculty: 'Medicine', implementing FindByPredicate that takes a Func of type Facility, bool.
 * This implementation facilitates queries across the entire entity in the context of T
 * In this concrete implementation include/s navigational properties (MVP - now additional filtering) to include data across multiple entities. 
 */   
var facultiesByName = facultyService.FindByPredicate(p => p.Name == facultyName);

if (facultiesByName is null || !facultiesByName.Any())
{
	Console.WriteLine($"Could not find any faculty by the name of {facultyName}");
	return;
}
foreach (var faculty in facultiesByName)
{
	var studentNames = faculty.StudentFaculties
		.Select(p => p.Student.Name)
		.ToList();
	
	Console.WriteLine($"\n");
	
	if (!studentNames.Any())
	{
		Console.WriteLine($"Students are not assigned to Faculty: {facultyName}");
	}
	foreach (var name in studentNames)
	{
		Console.WriteLine($"Student name: {name}, Faculty: {faculty.Name}");	
	}
}