using System.Runtime.Serialization;

namespace Entities.Abstract;

[DataContract]
public class EntityBase : IEntity
{
	[DataMember]
	public Guid Id { get; set; }
}