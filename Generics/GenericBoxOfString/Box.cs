using System;
using System.Collections.Generic;


namespace GenericBoxOfString
{
    public class Box<T>
    {
        public Box(T value)
        {
            this.Value = value;
        }
        public T Value { get; private set; }

        public override string ToString()
        {
            return $"{typeof(T)}: {this.Value}";
        }
    }
}
