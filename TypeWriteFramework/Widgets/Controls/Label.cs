using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeWrite.Widgets
{
    public class Label : ContentContainer
    {
        public override void Render(Screen screen)
        {
            var text = Content as string;
            var currentPosition = BeginRender();

            if (text == null) throw new Exception("Content must be text");

            screen.PutText(currentPosition.Left, currentPosition.Top, text);

            EndRender();
        }
    }
}
