using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace TypeWrite.Widgets
{
    [ContentProperty("Content")]
    public abstract class ContentContainer: Widget
    {
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("content", typeof(object), typeof(Widget));

        /// <summary>
        /// Gets or sets the Content.
        /// </summary>
        /// <value>The Content.</value>
        public object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
    }
}
