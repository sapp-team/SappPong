using EntityComponent.Components;
using EntityComponent.Interfaces;

namespace EntityComponent.Enities
{
    public interface IEntity : IUpdatable, IDrawable
    {
        int ID { get; }
        int ParentID { get; }

        TType GetComponent<TType>() where TType : class;

        IEntity AddComponent(IComponent component);
        IEntity RemoveComponent(IComponent component);
    }
}
