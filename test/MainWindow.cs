
﻿using System;

using System;
using System.Collections.Generic;
using System.IO;

using Gtk;
using logic;


public partial class MainWindow : Gtk.Window
{

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();

        FyllComboBoxKategorier();
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

    public void FyllComboBoxKategorier()
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

    private void FillTreeviewKategori()
    {
        var service = new Service();
        var lista = service.GetKategori();
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
}

