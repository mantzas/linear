namespace Linear.Contracts
{
    public interface IEventSerializer
    {
        string Serialize(object data);
        T Deserialize<T>(string data) where T:class; 
    }
}
