using System;
namespace TemplateProject.Entities
{
    public abstract class Entity
    {
        public Entity()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; init; }
    }
}