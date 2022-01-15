using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiShare.Application.Models
{
    public class BaseItem<T>
    {
        public BaseItem(T value, string label)
        {
            Value = value;
            Label = label;
        }
        public T Value { get; set; }
        public string Label { get; set; }
    }
}
