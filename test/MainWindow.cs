using System;
using Gtk;
using logic;


public partial class MainWindow : Gtk.Window
{

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        FillComboBoxes();
        FyllKategorier();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    private void FillComboBoxes()
    {
        var i = 1;

        foreach (var f in Enum.GetNames(typeof(Frekvens)))
        {
            combobox5.InsertText(i, f);
            i++;
        }

    }

    public void FyllKategorier()
    {
        var service = new Service();
        var lista = service.GetKategori();
        var i = 0;

        foreach (var k in lista)
        {
            combobox7.InsertText(i, k.Namn);
            i++;
        }
    }
}





