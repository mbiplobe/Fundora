public record EntityID
{
    public Guid Value { get; }

    public EntityID(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new UserInvalidException("Invalid user ID.");
        }

        Value = value;
    }
    public static EntityID NewId()
         => new(Guid.NewGuid());
        
    public static implicit operator Guid(EntityID id)
        => id.Value;

    public static implicit operator EntityID(Guid id)
        => new(id);
}