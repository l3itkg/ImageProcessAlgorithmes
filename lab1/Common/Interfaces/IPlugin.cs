namespace Common.Interfaces
{
    public interface IPlugin
    {
        void Process(IDirectBitmap bitmap, AbstractParameter parameter);
    }
}
