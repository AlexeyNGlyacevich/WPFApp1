namespace WPFApp1.Services.Event
{
    public class OnEditEvent<T> : IEvent
    {
        public T Entity { get; set; }

        public OnEditEvent(T entity)
        {
            Entity = entity;
        }
    }
}
