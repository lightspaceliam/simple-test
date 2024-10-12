using Entities;

namespace SimpleTests.SeedData;

public static class StudentFacultySeedData
{
	public static readonly Guid StudentHarryId = new Guid("759AC997-C558-4432-9516-E0DE1BE6A7CD");
	public static readonly Guid StudentHermioneId = new Guid("51585DFE-29EF-44EE-8B7F-931AFB492EB7");
	public static readonly Guid StudentRonId = new Guid("BD88CD4E-EC34-4D37-A1DF-435DFD6230C2");
	public static readonly Guid FacultyMedicineId = new Guid("FF709DAB-AEAB-463F-B8AB-EA1D3E2BD771");
	public static readonly Guid FacultyPotionsId = new Guid("43B651E6-7E98-43CE-81D1-5D3954349FC8");

	public static readonly List<Faculty> Faculties = new List<Faculty>
	{
		new Faculty
		{
			Id = FacultyMedicineId, Name = "Medicine"
		},
		new Faculty
		{
			Id = Guid.NewGuid(), Name = "Herbology"
		},
		new Faculty
		{
			Id = FacultyPotionsId, Name = "Astronomy"
		},
	};
	
	public static readonly List<Student> Students = new List<Student>
	{
		new Student
		{
			Id = StudentHarryId, FirstName = "Harry", LastName = "Potter"
		},
		new Student
		{
			Id = StudentHermioneId, FirstName = "Hermione", LastName = "Granger"
		},
		new Student
		{
			Id = StudentRonId, FirstName = "Ron", LastName = "Weasley"
		},
	};

	public static readonly List<StudentFaculty> StudentFaculties = new List<StudentFaculty>
	{
		new StudentFaculty
		{
			Id = Guid.NewGuid(), StudentId = StudentHarryId, FacultyId = FacultyMedicineId
		},
		new StudentFaculty
		{
			Id = Guid.NewGuid(), StudentId = StudentHermioneId, FacultyId = FacultyMedicineId
		},
		new StudentFaculty
		{
			Id = Guid.NewGuid(), StudentId = StudentRonId, FacultyId = FacultyMedicineId
		},
		new StudentFaculty
		{
			Id = Guid.NewGuid(), StudentId = StudentHermioneId, FacultyId = FacultyPotionsId
		},
	};
}