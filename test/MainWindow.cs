
﻿using System;
using System.Collections.Generic;
using Gtk;
using logic;


public partial class MainWindow : Gtk.Window
{
    string gtkKategori = "";


    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();

        FillComboBoxKategorier();
        FillComboBoxFrekvens();
        FillTreeviewKategori();
        FillTreeviewAvsnitt();
        FillTreeviewPodcast();

    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    private void FillComboBoxFrekvens()
    {
        var i = 1;
        foreach (var f in Enum.GetNames(typeof(Frekvens)))
        {
            combobox5.InsertText(i, f);
            i++;
        }
    }

    public void FillComboBoxKategorier()
    {
        var listMaker = new ListMaker();
        var lista = listMaker.GetKategorier();
        var i = 0;

        foreach (var k in lista)
        {
            combobox7.InsertText(i, k.Namn);
            i++;
        }
    }
   
    private void FillTreeviewKategori()
    {
        var listMaker = new ListMaker();
        var lista = listMaker.GetKategorier();
        var i = 0;

        Gtk.TreeViewColumn kategoriColumn = new Gtk.TreeViewColumn();
        kategoriColumn.Title = "Kategorier:";
        Gtk.CellRendererText kategoriNameCell = new Gtk.CellRendererText();
        kategoriColumn.PackStart(kategoriNameCell, true);
        treeviewKategorier.AppendColumn(kategoriColumn);
        kategoriColumn.AddAttribute(kategoriNameCell, "text", 0);
        Gtk.ListStore kategoriListStore = new Gtk.ListStore(typeof(string));

        foreach (var k in lista)
        {
            kategoriListStore.AppendValues(k.Namn);
            i++;
        }
        treeviewKategorier.Model = kategoriListStore;
    }

    private void RemoveColumn(TreeView treeview)
    {
        treeview.RemoveColumn(treeview.GetColumn(0));
    }

    private void RemoveComboBox(ComboBox comboBox)
        
    {
        int[] a = new int[30];
        foreach (var p in a) {
            combobox7.RemoveText(p);
        }

    }

    private void FillTreeviewAvsnitt()
    {
        Gtk.TreeViewColumn avsnittColumn = new Gtk.TreeViewColumn();
        avsnittColumn.Title = "Avsnitt:";

        Gtk.CellRendererText avsnittNameCell = new Gtk.CellRendererText();
        avsnittColumn.PackStart(avsnittNameCell, true);

        treeviewAvsnitt.AppendColumn(avsnittColumn);

        avsnittColumn.AddAttribute(avsnittNameCell, "text", 0);


        Gtk.ListStore avsnittListStore = new Gtk.ListStore(typeof(string));


        avsnittListStore.AppendValues("Avsnitt 1");
        avsnittListStore.AppendValues("Avsnitt 2");
        avsnittListStore.AppendValues("Avsnitt 3");
        avsnittListStore.AppendValues("Avsnitt 4");

        treeviewAvsnitt.Model = avsnittListStore;
    }

    private void FillTreeviewPodcast()
    {
        Gtk.TreeViewColumn avsnittColumn = new Gtk.TreeViewColumn();
        avsnittColumn.Title = "Avsnitt:";
        Gtk.TreeViewColumn namnColumn = new Gtk.TreeViewColumn();
        namnColumn.Title = "Namn:";
        Gtk.TreeViewColumn frekvensColumn = new Gtk.TreeViewColumn();
        frekvensColumn.Title = "Frekvens:";
        Gtk.TreeViewColumn kategoriColumn = new Gtk.TreeViewColumn();
        kategoriColumn.Title = "Kategori:";

        Gtk.CellRendererText avsnittNameCell = new Gtk.CellRendererText();
        avsnittColumn.PackStart(avsnittNameCell, true);
        Gtk.CellRendererText namnNameCell = new Gtk.CellRendererText();
        namnColumn.PackStart(namnNameCell, true);
        Gtk.CellRendererText frekvensNameCell = new Gtk.CellRendererText();
        frekvensColumn.PackStart(frekvensNameCell, true);
        Gtk.CellRendererText kategoriNameCell = new Gtk.CellRendererText();
        kategoriColumn.PackStart(kategoriNameCell, true);

        treeviewPodcast.AppendColumn(avsnittColumn);
        treeviewPodcast.AppendColumn(namnColumn);
        treeviewPodcast.AppendColumn(frekvensColumn);
        treeviewPodcast.AppendColumn(kategoriColumn);

        avsnittColumn.AddAttribute(avsnittNameCell, "text", 0);
        namnColumn.AddAttribute(namnNameCell, "text", 1);
        frekvensColumn.AddAttribute(frekvensNameCell, "text", 2);
        kategoriColumn.AddAttribute(kategoriNameCell, "text", 3);

        Gtk.ListStore podcastListStore = new ListStore(typeof(string), typeof(string), typeof(string), typeof(string));

        podcastListStore.AppendValues("20", "P3 Historia", "VarjeHalvtimme", "Historia");
        podcastListStore.AppendValues("132", "Tankesmedjean i P3", "VarjeTimme", "Humor");

        treeviewPodcast.Model = podcastListStore;
    }

    protected void AddKategori(object sender, EventArgs e)
    {
        var kategori = entryKategori.Text;
        var newKategori = new Kategori(kategori);
        var listMaker = new ListMaker();
        listMaker.AddKategori(newKategori);
        String clear = "";
        entryKategori.Text = clear;
        RemoveColumn(treeviewKategorier);
        FillTreeviewKategori();
        RemoveComboBox(combobox7);
        FillComboBoxKategorier();
    }

    protected void RemoveKategori(object sender, EventArgs e)
    {
        var kategori = entryKategori.Text;
        var listMaker = new ListMaker();
        listMaker.RemoveKategori(kategori);
        String clear = "";
        entryKategori.Text = clear;
        RemoveColumn(treeviewKategorier);
        FillTreeviewKategori();
        RemoveComboBox(combobox7);
        FillComboBoxKategorier();
    }

  
  

    protected void OnTreeviewKategorierRowActivated(object o, RowActivatedArgs args)
    {
        var model = treeviewKategorier.Model;
        TreeIter iter;
        model.GetIter(out iter, args.Path);
        object value = model.GetValue(iter, 0);
        gtkKategori = value.ToString();

        entryKategori.Text = gtkKategori;       // här sätter vi värdet value till fältet gtkKategori helt i onödan men man
                                                // hade någon tanke om att fält skulle vara bra för att slippa rendundans men nu
    }                                           // är jag så jävla trött så jag vet inte vad jag tänker...
}                                               // nu kan man iaf klicka för att ta bort markerad och combobox funkar!
                                                
