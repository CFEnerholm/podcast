using System;
using Gtk;

namespace Validation
{
    public class CategoryValidation : PodcastValidation
    {
        

        public CategoryValidation()
        {
            
            

        }

        public override void MessageDialog(string Message)
        {
            string message = Message;

            MessageDialog md = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, message);
            
            md.Title = "Felinmatning av Kategori";
            md.Run();
            md.Destroy();
        }

        public override bool ValidateInput(string input)
        {
            string namn = input;
            Boolean ok = false;
            if (namn.Length>1)
            {
                ok = true;
            }

            else
            {
                ok = false;
                MessageDialog("Kontrollera val eller inmatning av kategori, rutan får inte vara tom");
            }


            return ok;
        }
    }

    }


