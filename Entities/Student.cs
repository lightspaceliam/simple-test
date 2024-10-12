using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Entities.Abstract;

namespace Entities;

public class Student : EntityBase
{
	[DataMember]
	[NotMapped]
	public string Name => $"{FirstName} {LastName}";
	
	[DataMember]
	[Required(ErrorMessage = "First name is required")]
	[StringLength(150, ErrorMessage = "First name exceeds {1} characters")]
	public string FirstName { get; set; } = default!;
	
	[DataMember]
	[Required(ErrorMessage = "Last name is required")]
	[StringLength(150, ErrorMessage = "Last name exceeds {1} characters")]
	public string LastName { get; set; } = default!;
	
	[DataMember]
	public List<StudentFaculty> StudentFaculties { get; set; }
}