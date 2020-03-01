namespace BLL.Interfaces
{
    public interface IValidator
    {
        bool IsValid<T>(T obj);
        void Validate<T>(T obj);
    }
}