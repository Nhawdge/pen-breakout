using System;
using System.Collections.Generic;
using System.Linq;
using PenBreakout.Components;

namespace PenBreakout.Entities
{
    public class Entity
    {
        public List<Component> Components = new();
        public Entity()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; init; }

        public T GetComponent<T>()
        {
            var component = Components.FirstOrDefault(x => x.GetType() == typeof(T));
            return (T)Convert.ChangeType(component, typeof(T));
        }
        public IEnumerable<T> GetComponents<T>()
        {
            var components = Components.Where(x => x.GetType() == typeof(T)).Select(x => (T)Convert.ChangeType(x, typeof(T)));
            return components;
        }
    }
}