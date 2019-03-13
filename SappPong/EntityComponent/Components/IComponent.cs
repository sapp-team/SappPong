using EntityComponent.Enities;

namespace EntityComponent.Components
{
    public interface IComponent
    {
        IEntity Entity { get; }

        void Initialize();
    }
}
