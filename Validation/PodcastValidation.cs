using System;
using Gtk;

namespace Validation
{
    public class PodcastValidation
    {
        public PodcastValidation()
        {
        }

        public virtual void MessageDialog(string Message)
        {
            string message = Message;

            MessageDialog md = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, message);

            md.Title = "Felinmatning av Podcast";
            md.Run();
            md.Destroy();
        }

        public virtual Boolean ValidateInput(string Url)
        {
            string url = Url;
            Boolean ok = false;
            if(url.Length>=14 && url.Contains("/"))
            {
                ok = true;
            }

            else
            {
                ok = false;
                MessageDialog("Kontrollera inmatning av URL, minst 14 tecken och den ska innehålla / ");
            }


            return ok;
        }

        public Boolean IsComboBoxEmpty(String Frekvens, String Kategori)
        {
            string frekvens = Frekvens;
            string kategori = Kategori;
            Boolean ok = false;
            if (frekvens != null && kategori != null)
            {
                ok = true;
            }

            else
            {
                ok = false;
                MessageDialog("Frekvens och Kategori får inte vara tom");
            }


            return ok;
        }

        public bool IsInputEmpty(String Namn)
        {
            string namn = Namn;
            Boolean ok = false;
            if (namn.Length > 1)
            {
                ok = true;
            }

            else
            {
                ok = false;
                MessageDialog("Du måste välja en podcast.");
            }


            return ok;
        }
    }
}

    

