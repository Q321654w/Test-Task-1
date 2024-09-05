namespace Sources.Core
{
    public interface IInput<T>
    {
        T Read();
    }
}