namespace MoqIntroduction.Database
{
    public interface IDatabase
    {
        int GetValue(int id);
        bool TryGetValue(int id, MyModel model);
        void InsertValue(int value);
    }
}