using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeWrite.Model;
using TypeWrite.Widgets;

namespace TypeWrite.Widgets
{
    public class Screen : ContentContainer
    {
        public VisualTree Tree { get; set; }

        public void DrawRect(int w, int h, ConsoleColor background)
        {
            var row = new String(' ', w);
            Console.BackgroundColor = background;

            for (int i = 0; i < h; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(row);
            }
        }

        public void PutText(int left, int top, string text, ConsoleColor background, ConsoleColor foreground)
        {
            Console.SetCursorPosition(left, top);
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
            Console.Write(text);
        }

        public void PutText(int left, int top, string text)
        {
            PutText(left, top, text, BackGround, ForeGround);
        }

        public void PutTextel(int x, int y, ConsoleColor color, char pattern = ' ')
        {

        }

        public override void Render(Screen screen)
        {
            var childElement = Content as Widget;

            if (Content == null) throw new Exception("Content must be a widget");

            childElement.Render(screen);
        }

        public void Render()
        {
            Render(this);
        }
    }
}
