using EntityComponent.Components;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityComponent.Enities
{
    public class Entity : IEntity
    {
        private int _id;
        public int ID => _id;

        private int _parentID;
        public int ParentID => _parentID;

        public int GameComponentCount => _updatableComponents.Count;
        public int DrawableGameComponentCount => _drawableComponents.Count;

        private List<IUpdatableComponent> _updatableComponents;
        private List<IDrawableComponent> _drawableComponents;

        public Entity()
        {
            _updatableComponents = new List<IUpdatableComponent>();
            _drawableComponents = new List<IDrawableComponent>();
        }

        public IEntity AddComponent(IComponent component)
        {
            switch (component)
            {
                case DrawableGameComponent dgc:
                    _drawableComponents.Add(dgc);
                    _updatableComponents.Add(dgc);
                    break;
                case GameComponent gc:
                    _updatableComponents.Add(gc);
                    break;
                default:
                    throw new ArgumentException("Unkown component type!", component.ToString());
            }

            return this;
        }

        public IEntity RemoveComponent(IComponent component)
        {
            switch (component)
            {
                case DrawableGameComponent dgc:
                    _updatableComponents.Remove(dgc);
                    _drawableComponents.Remove(dgc);
                    break;
                case GameComponent gc:
                    _updatableComponents.Remove(gc);
                    break;
                default:
                    throw new ArgumentException("Unkown component type!", component.ToString()); ;
            }

            return this;
        }

        public TType GetComponent<TType>() where TType : class
        {
            foreach (var uComp in _updatableComponents)
            {
                if (uComp is TType desiredComponent)
                    return desiredComponent;
            }

            foreach (var dComp in _drawableComponents)
            {
                if (dComp is TType desiredComponent)
                    return desiredComponent;
            }

            return null; // Возвращать null - плохо! Но что поделать...
        }

        public void Update(float deltaTime)
        {
            for (int index = 0; index < _updatableComponents.Count; index++)
            {
                _updatableComponents[index].Update(deltaTime);
            }
        }

        public void Render(SpriteBatch batch)
        {
            for (int index = 0; index < _drawableComponents.Count; index++)
            {
                _drawableComponents[index].Render(batch);
            }
        }
    }
}
