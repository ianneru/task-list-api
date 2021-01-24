using System;
using System.Collections.Generic;

namespace TaskList.SharedKernel
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataEdicao { get; set; }

        public DateTime DataRemocao { get; set; }

        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}