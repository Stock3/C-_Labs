using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Interfaces
{
    public interface IRateAndCopy<T>
    {
        double rating_of_article { get; }
        T DeepCopy();
    }
}
