using System;

namespace TaskList.SharedKernel
{
    public  class BaseEntity<T>
    {
        public BaseEntity()
        {
        }

        public BaseEntity(T id)
        {
            Id = id;
        }

        public T Id { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataEdicao { get; set; }

        public DateTime? DataRemocao { get; set; }
    }
}