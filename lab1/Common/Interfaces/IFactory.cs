namespace Common.Interfaces
{
    public interface IFactory
    {
        IPlugin CreatePlugin();
        AbstractParameter CreateParameters();
        string Name();
    }
}