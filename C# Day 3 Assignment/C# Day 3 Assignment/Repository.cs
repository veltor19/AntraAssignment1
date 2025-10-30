using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day_3_Assignment {
    internal class Repository<T> : IRepository<T> where T : Entity {

        private List<T> items;
        private List<T> itemsToAdd;
        private List<T> itemsToRemove;

        public Repository() {
            items = new List<T>();
            itemsToAdd = new List<T>();
            itemsToRemove = new List<T>();
        }

        public void Add(T item) {
            itemsToAdd.Add(item);
        }
        public void Remove(T item) {
            itemsToRemove.Remove(item);
        }
        public void Save() {
            foreach (var item in itemsToAdd) {
                items.Add(item);
            }

            foreach (var item in itemsToRemove) {
                items.Remove(item);
            }
            itemsToAdd.Clear();
            itemsToRemove.Clear();
        }
        public IEnumerable<T> GetAll() {
            return items;
        }
        public T GetById(int id) {
            for (int i = 0; i < items.Count; i++) {
                if (items[i].Id == id) {
                    return items[i];
                }
            }
            return null;

        }

    }
}
