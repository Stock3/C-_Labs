using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Classes
{
    public class TestCollections
    {
        private List<Edition> _editions;
        private List<string> _keys;
        private Dictionary<Edition, Magazine> _typeDictionary;
        private Dictionary<string, Magazine> _stringDictionary;

        public static Magazine[] AvtoGenerateMagazines(int count)
        {
            var res = new Magazine[count];
            for (var i = 0; i < count; i++)
            {
                res[i] = new Magazine();
            }
            return res;
        }

        public TestCollections(int count)
        {
            _editions = new List<Edition>(count);
            _keys = new List<string>(count);
            _stringDictionary = new Dictionary<string, Magazine>(count);
            _typeDictionary = new Dictionary<Edition, Magazine>(count);
        }
    }
}
