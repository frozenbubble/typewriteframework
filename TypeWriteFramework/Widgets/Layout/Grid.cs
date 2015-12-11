using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace TypeWrite.Widgets
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    public class RowDefinitionList : List<RowDefinition> { }
    public class ColumnDefinitionList : List<ColumnDefinition> { }

    public class RowDefinition
    {
        public int Height { get; set; }
    }

    public class ColumnDefinition
    {
        public int Width { get; set; }
    }

    [Serializable]
    public class Grid : Panel
    {

        public static readonly DependencyProperty Row = DependencyProperty.RegisterAttached(
          "Row",
          typeof(int),
          typeof(Grid),
          new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.AffectsRender)
        );
        public static void SetRow(Widget element, int value)
        {
            element.SetValue(Row, value);
        }
        public static int GetRow(Widget element)
        {
            return (int)element.GetValue(Row);
        }

        public static readonly DependencyProperty Column = DependencyProperty.RegisterAttached(
          "Column",
          typeof(int),
          typeof(Grid),
          new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.AffectsRender)
        );
        public static void SetColumn(Widget element, int value)
        {
            element.SetValue(Column, value);
        }
        public static int GetColumn(Widget element)
        {
            return (int)element.GetValue(Column);
        }

        protected RowDefinitionList rowDefinitions;
        public RowDefinitionList RowDefinitions 
        {
            get { return rowDefinitions; }
        }
        
        protected ColumnDefinitionList columnDefinitions;
        public ColumnDefinitionList ColumnDefinitions 
        {
            get { return columnDefinitions; }
        }

        public Grid()
        {
            rowDefinitions = new RowDefinitionList();
            columnDefinitions = new ColumnDefinitionList();
        }

        public override void Render(Screen screen)
        {
            var currentCursorPosition = BeginRender();

            foreach (var child in Children)
            {
                var element = (Widget)child;
                
                Console.CursorTop = currentCursorPosition.Top + AggregateHeight(GetRow(element));
                Console.CursorLeft = currentCursorPosition.Left + AggregateWidth(GetColumn(element));

                element.Render(screen);

                Console.CursorTop = currentCursorPosition.Top;
                Console.CursorLeft = currentCursorPosition.Left;
            }

            EndRender();
        }

        private int AggregateHeight(int row)
        {
            return (RowDefinitions.Count == 0) ? 0 : RowDefinitions.GetRange(0, row + 1).Select(r => r.Height).Sum() - 1;
        }

        private int AggregateWidth(int column)
        {
            return (ColumnDefinitions.Count == 0) ? 0 : ColumnDefinitions.GetRange(0, column + 1).Select(r => r.Width).Sum() - 1;
        }
    }
}
