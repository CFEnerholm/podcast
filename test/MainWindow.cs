using System;
using System.Collections.Generic;
using Gtk;
using logic;


public partial class MainWindow : Gtk.Window
{

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        FillComboBoxes();
        FillComboBoxesKategori();


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

    private void FillComboBoxesKategori()
    {
        var kdb = new Kategori();      
        var i = 0;

        foreach (var k in kdb.KategoriLista)
        {
            combobox7.InsertText(i, k);
            i++;      
        }
    }
}


