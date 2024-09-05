namespace Sources.Core
{
    public interface IInputSafe<T>
    {
        bool HasNext();
        T Read();
    }
}