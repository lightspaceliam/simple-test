using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Entities.Abstract;

namespace Entities;

public class Faculty : EntityBase
{
	[DataMember]
	[Required(ErrorMessage = "Name is required")]
	[StringLength(150, ErrorMessage = "Name exceeds {1} characters")]
	public string Name { get; set; } = default!;
	
	[DataMember]
	public List<StudentFaculty> StudentFaculties { get; set; }
}