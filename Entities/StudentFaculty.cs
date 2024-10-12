using System.Runtime.Serialization;
using Entities.Abstract;

namespace Entities;

public class StudentFaculty : EntityBase
{
	[DataMember]
	public Guid FacultyId { get; set; }
	
	[DataMember]
	public Faculty Faculty { get; set; }
	
	[DataMember]
	public Guid StudentId { get; set; }
	
	[DataMember]
	public Student Student { get; set; }
}