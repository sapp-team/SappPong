using EntityComponent.Enities;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityComponent.Components
{
    public abstract class DrawableGameComponent : GameComponent, IDrawableComponent
    {
        public DrawableGameComponent(IEntity entity) : base(entity) { }

        public abstract void Render(SpriteBatch batch);
    }
}
