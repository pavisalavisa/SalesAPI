namespace Application.Common
{
    public class EntityCreatedModel
    {
        // Nice conversation starter :)
        // CQRS Purists advise against returning anything from commands
        // When to bend the rules and when to be evangelist
        public EntityCreatedModel(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
