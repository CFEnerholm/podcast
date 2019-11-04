using System;
using Gtk;

namespace Validation
{
    public class ValidationService
    {
        public ValidationService()
        {
        }




        public void MessageDialog(string message)
        {

            MessageDialog md = new MessageDialog(null, DialogFlags.DestroyWithParent,
                                                  MessageType.Error, ButtonsType.Ok, message);
            md.Title = "Felmedelande";
            md.Run();
            md.Destroy();
        }

    }
}
