namespace HomesEngland.UseCase.Models
{
    public interface IInputParser<T>
    {
        T Parse(string[] args);
    }
}
