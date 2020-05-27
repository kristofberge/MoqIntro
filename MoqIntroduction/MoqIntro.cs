using MoqIntroduction.Database;

namespace MoqIntroduction
{
    public class MoqIntro
    {
        IDatabase _db;

        public MoqIntro(IDatabase db)
        {
            _db = db;
        }

        public int GetSumOfValues(int id1, int id2)
        {
            int value1 = _db.GetValue(id1);
            int value2 = _db.GetValue(id2);

            return value1 + value2;
        }

        public int GetSumByReference(int id1, int id2)
        {
            var model1 = new MyModel();
            var model2 = new MyModel();

            _db.TryGetValue(id1, model1);
            _db.TryGetValue(id2, model2);

            return model1.Value + model2.Value;
        }
        public void AddValue(int value)
        {
            _db.InsertValue(value);
        }
    }
}
