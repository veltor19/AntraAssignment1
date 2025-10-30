using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day_2_Assignment {
    internal class Ball {
        private int size;
        private Color color;
        private int throwCount;

        public Ball(int size, Color color) {
            this.size = size;
            this.color = color;
            this.throwCount = 0;
        }

        public int Size {
            get { return size; }
            set { size = value; }
        }

        public Color Color {
            get { return color; }
            set { color = value; }
        }

        public void Pop() {
            size = 0;
        }

        public void Throw() {
            if (size > 0) {
                throwCount++;
            } else {
                Console.WriteLine("Cannot throw a popped ball.");
            }
        }

        public int GetThrowCount() {
            return throwCount;
        }
    }
}
