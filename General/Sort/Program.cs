﻿using System;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class ArrayList<T>{

        T[] internalStorage;
        int lastItemIndex;

        public ArrayList()
        {
            internalStorage = new T[4];
            lastItemIndex = -1;
        }

        public void Add(T item){

            if (lastItemIndex == internalStorage.Length - 1)
                ExpandStorage();

            internalStorage[lastItemIndex + 1] = item;
            lastItemIndex++;
        }

        public void Insert(T item, int index){
            Validate(index);

            if (lastItemIndex == internalStorage.Length - 1)
                ExpandStorage();

            int segment = lastItemIndex - index;

            Array.Copy(internalStorage, index, internalStorage, index + 1, segment);

            lastItemIndex++;
        }

        private void Validate(int index){
            if (index == -1 || index > lastItemIndex)
                throw new ArgumentOutOfRangeException();
        }

        private void ExpandStorage(){
            T[] newStorage = new T[internalStorage.Length * 2];
            Array.Copy(internalStorage, newStorage, internalStorage.Length - 1);

            internalStorage = newStorage;
        }

        public T this[int index] { 
            get { return internalStorage[index]; }
            set { internalStorage[index] = value; }
        }
    
    }
}
