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
    }
}