namespace Sigma.Domain;

public abstract class BaseEntity<TKey>
{
    protected TKey Id { get; set; }
}