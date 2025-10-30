using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day_3_Assignment {
    internal class MyList <T> {

        private T[] list;
        private int count;
        public MyList (int capacity) {
            list = new T[capacity];
        }

        public void Add(T element) {
            if (count == list.Length) {
                IncreaseSize();
            }
            list[count++] = element;
        }

        public T Remove(int index) {
            T removedItem = list[index];

            // Shift elements to the left
            for (int i = index; i < count - 1; i++) {
                list[i] = list[i + 1];
            }

            list[count - 1] = default(T);
            count--;

            return removedItem;
        }

        public bool Contains(T element) {
            for (int i = 0; i < count; i++) {
                if (list[i] != null&& element != null && list[i].Equals(element)) {
                    return true;
                }
            }
            return false;
        }

        public void Clear() {
            for (int i = 0; i < count; i++) {
                list[i] = default(T);
            }
            count = 0;
        }

        public void InsertAt(int index, T element) {
            if (count == list.Length) {
                IncreaseSize();
            }
            for (int i = count; i > index; i--) {
                list[i] = list[i - 1];
            }
            list[index] = element;
            count++;
        }

        public void DeleteAt(int index) {
            for (int i = index; i < count - 1; i++) {
                list[i] = list[i + 1];
            }
            list[count - 1] = default(T);
            count--;
        }

        public T Find(int index) {
            return list[index];
        }

        private void IncreaseSize() {
            T[] newList = new T[list.Length * 2];
            for (int i = 0; i < list.Length; i++) {
                newList[i] = list[i];
            }
            list = newList;
        }

    }
}
