using EntityComponent.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityComponent.Components
{
    public abstract class GameComponent : IUpdatableComponent
    {
        private IEntity _entity;
        public IEntity Entity => _entity;

        protected GameComponent(IEntity entity)
        {
            _entity = entity;
        }

        public abstract void Initialize();
        public abstract void Update(float deltaTime);
    }
}
