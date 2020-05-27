using System;
using System.Collections.Generic;
using System.Text;

namespace MoqIntroduction.Database
{
    public class MyDatabase : IDatabase
    {
        private Dictionary<int, int> _dbValues = new Dictionary<int, int>
        {
            { 0, 0 },
            { 1, 1 },
            { 2, 2 },
            { 3, 3 },
            { 4, 4 },
            { 5, 5 },
            { 6, 6 },
            { 7, 7 },
            { 8, 8 },
            { 9, 9 },
        };

        private int _currentIndex = 10;

        public int GetValue(int id)
        {
            return _dbValues.ContainsKey(id) ? _dbValues[id] : throw new ArgumentException();
        }

        public bool TryGetValue(int id, MyModel model)
        {
            if (_dbValues.ContainsKey(id))
            {
                model.Id = id;
                model.Value = _dbValues[id];
                return true;
            }

            model.Id = -1;
            model.Value = -1;
            return false;
        }

        public void InsertValue(int value)
        {
            _dbValues.Add(_currentIndex, value);
            _currentIndex++;
        }
    }
}
