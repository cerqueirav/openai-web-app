namespace GptApi.Services.Interface
{
    public interface IRabitMQProducer
    {
        public void SendProductMessage<T>(T message);
    }
}
