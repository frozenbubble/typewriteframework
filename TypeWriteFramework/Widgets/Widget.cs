using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace TypeWrite.Widgets
{
    public delegate void WidgetEventHandler(object sender, EventArgs args);

    
    public abstract class Widget: DependencyObject
    {
        internal class ConsoleCursorPosiotion
        {
            internal int Top { get; set; }
            internal int Left { get; set; }

            internal ConsoleCursorPosiotion(int top, int left)
            {
                Top = top;
                Left = left;
            }
        }

        internal class Area 
        {
            internal int Width { get; set; }
            internal int Height { get; set; }

            internal Area (int height, int width)
	        {
                Height = height;
                Width = width;
	        }
        }

        public event WidgetEventHandler Action;
        public event WidgetEventHandler FocusReceived;
        public event WidgetEventHandler FocuseLost;
        public event WidgetEventHandler KeyPressed;

        public Widget()
        {
            BackGround = ConsoleColor.Black;
            ForeGround = ConsoleColor.Gray;
        }

        public ConsoleColor BackGround { get; set; }
        public ConsoleColor ForeGround { get; set; }

        public int Left { get; set; }
        public int Top { get; set; }

        protected ConsoleCursorPosiotion BeginRender()
        {
            Console.CursorLeft += Left;
            Console.CursorTop += Top;

            return new ConsoleCursorPosiotion(Console.CursorTop, Console.CursorLeft);
        }

        public void EndRender()
        {
            Console.CursorLeft -= Left;
            Console.CursorTop -= Top;
        }

        public abstract void Measure(Area available);

        public abstract void Render(Screen screen);
    }
}
