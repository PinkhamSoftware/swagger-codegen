namespace HomesEngland.Domain.Factory
{
    public interface IFactory<T, TInput>
    {
        T Create(TInput tInput);
    }
}