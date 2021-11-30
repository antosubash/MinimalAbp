using Volo.Abp.Domain.Entities.Auditing;

public class Book : AuditedAggregateRoot<Guid>
{
    public Book(string name)
    {
        this.Name = name;
    }
    public string Name { get; set; }
}