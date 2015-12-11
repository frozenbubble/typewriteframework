using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Xml;
using TypeWrite.Widgets;

namespace TypeWrite
{
    class Program
    {
        static void Main(string[] args)
        {
            //Label originalLabel = new Label();
            //originalLabel.Content = "this is the original label";
            var screen = new Screen();
            var label = new Label();
            label.Content = "this is a label.";
            var grid = new Grid();
            grid.Children.Add(label);
            grid.Children.Add(label);
            grid.Children.Add(label);
            grid.Children.Add(label);
            screen.Content = grid;

            // Save the Button to a string.
            string saved = XamlWriter.Save(screen);

            // Load the button
            //StringReader stringReader = new StringReader(saved);
            //XmlReader xmlReader = XmlReader.Create(stringReader);
            var reader = XmlReader.Create("Test.xml");
            Screen read = (Screen)XamlReader.Load(reader);

            read.Render();

            Console.Read();
        }
    }
}
