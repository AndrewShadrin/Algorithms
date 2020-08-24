using System;

namespace Lesson_5
{
    public class Stack
    {
        private readonly int dimension;
        private char[] elements;
        private int pos = -1;
        public bool Empty => pos == -1;

        public Stack(int dim = 100)
        {
            dimension = dim;
            elements = new char[dimension];
        }

        public void Push(char s)
        {
            if (pos == dimension-1)
            {
                throw new StackOverflowException("Stack overflow");
            }
            pos++;
            elements[pos] = s;
        }

        public char Pop()
        {
            if (pos == -1)
            {
                throw new ArgumentOutOfRangeException("Stack is empty");
            }
            char s = elements[pos];
            pos--;

            return s;
        }

        public char Top()
        {
            if (pos == -1)
            {
                throw new ArgumentOutOfRangeException("Stack is empty");
            }

            return elements[pos];
        }

        public void Clear()
        {
            pos = -1;
            elements = new char[dimension];
        }
    }
    
    public class Stack<T>
    {
        private readonly int dimension;
        private T[] elements;
        private int pos = -1;
        public bool Empty => pos == -1;

        public Stack(int dim = 100)
        {
            dimension = dim;
            elements = new T[dimension];
        }

        public void Push(T s)
        {
            if (pos == dimension-1)
            {
                throw new StackOverflowException("Stack overflow");
            }
            pos++;
            elements[pos] = s;
        }

        public T Pop()
        {
            if (pos == -1)
            {
                throw new ArgumentOutOfRangeException("Stack is empty");
            }
            T s = elements[pos];
            pos--;

            return s;
        }

        public T Top()
        {
            if (pos == -1)
            {
                throw new ArgumentOutOfRangeException("Stack is empty");
            }

            return elements[pos];
        }

        public void Clear()
        {
            pos = -1;
            elements = new T[dimension];
        }
    }
}
