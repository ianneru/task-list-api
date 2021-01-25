using System;

namespace TaskList.SharedKernel
{
    public abstract class BaseModel<T>
    {
        public BaseModel()
        {
        }

        public BaseModel(T id)
        {
            Id = id;
        }

        public T Id { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataEdicao { get; set; }

        public DateTime? DataRemocao { get; set; }
    }
}