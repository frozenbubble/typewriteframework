using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace TypeWrite.Widgets
{
    public class ObjectList : List<object> { }

    [ContentPropertyAttribute("Children")]
    public abstract class Panel: Widget
    {
        protected ObjectList children = new ObjectList();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ObjectList Children
        {
            get { return children; }
        }

        public Panel()
        {
            children = new ObjectList();
        }

        public override void Render(Screen screen)
        {
            throw new NotImplementedException();
        }
    }
}
