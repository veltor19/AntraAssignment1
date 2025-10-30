using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day_2_Assignment {
    internal class Color {
        private int red;
        private int green;
        private int blue;
        private int alpha;
        public int Red {
            get {
                return red;
            }
            set {
                if (value < 0 || value > 255) {
                    throw new ArgumentOutOfRangeException("Red value must be between 0 and 255.");
                }
                red = value;
            }
        }
        public int Green {
            get {
                return green;
            }
            set {
                if (value < 0 || value > 255) {
                    throw new ArgumentOutOfRangeException("Green value must be between 0 and 255.");
                }
                green = value;
            }
        }
        public int Blue {
            get {
                return blue;
            }
            set {
                if (value < 0 || value > 255) {
                    throw new ArgumentOutOfRangeException("Blue value must be between 0 and 255.");
                }
                blue = value;
            }
        }
        public int Alpha {
            get {
                return alpha;
            }
            set {
                if (value < 0 || value > 255) {
                    throw new ArgumentOutOfRangeException("alpha value must be between 0 and 255.");
                }
                alpha = value;
            }
        }

        public Color(int red, int green, int blue) {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = 255;
        }

        public int GrayScale() {
            return (red + green + blue) / 3;
        }

    }
}
