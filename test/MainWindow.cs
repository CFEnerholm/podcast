
using System;
using System.Collections.Generic;
using Gtk;
using System.Linq;
using logic;
using System.ComponentModel;

public partial class MainWindow : Gtk.Window
{
    string gtkKategori = "";
    string gtkPodcast = "";

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();

        FillComboBoxKategorier();
        FillComboBoxFrekvens();
        FillTreeviewKategori();
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
            comboboxFrekvens.InsertText(i, f);
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
            comboboxKategori.InsertText(i, k.Namn);
            i++;
        }
    }

    private void FillTreeviewPodcast()
    {
        var listMaker = new ListMaker();
        var lista = listMaker.GetPodcasts();
        var i = 0;


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


        foreach (var p in lista)
        {
            var namn = p.Namn;
            var frekvens = p.Frekvensen.ToString();
            var kategori = p.Kategorin.Namn;
            i++;
            podcastListStore.AppendValues("20", namn, frekvens, kategori);
        }


        treeviewPodcast.Model = podcastListStore;
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
        foreach (var p in a)
        {
            comboBox.RemoveText(p);
        }

    }

    private void FillTreeviewAvsnitt()
    {
        var listmaker = new ListMaker();
        var podcast = entryURL.Text;
        var lista1 = listmaker.GetPodcasts();
        var lista = new List<Avsnitt>();
        foreach(Podcast p in lista1)
        {
            if (podcast.Equals(p.Namn))
            {
                lista = p.AvsnittsLista;
            }
        }
        var i = 0;

        Gtk.TreeViewColumn avsnittColumn = new Gtk.TreeViewColumn();
        avsnittColumn.Title = "Avsnitt:";

        Gtk.CellRendererText avsnittNameCell = new Gtk.CellRendererText();
        avsnittColumn.PackStart(avsnittNameCell, true);

        treeviewAvsnitt.AppendColumn(avsnittColumn);

        avsnittColumn.AddAttribute(avsnittNameCell, "text", 0);


        Gtk.ListStore avsnittListStore = new Gtk.ListStore(typeof(string));


        foreach (var k in lista)
        {
            avsnittListStore.AppendValues(k.AvsnittsNamn);
            i++;
        }

        treeviewAvsnitt.Model = avsnittListStore;
    }

    protected void AddKategori(object sender, EventArgs e)
    {
        var listMaker = new ListMaker();
        var kategori = entryKategori.Text;
        var newKategori = new Kategori(kategori);
        listMaker.AddKategori(newKategori);
        String clear = "";
        entryKategori.Text = clear;
        RemoveColumn(treeviewKategorier);
        FillTreeviewKategori();
        RemoveComboBox(comboboxKategori);
        FillComboBoxKategorier();
    }

    protected void AddPodFeed(object sender, EventArgs e)
    {
        var listMaker = new ListMaker();
        var url = entryURL.Text;

        var frekvens = comboboxFrekvens.ActiveText;
        Frekvens frekvensen = (Frekvens)Enum.Parse(typeof(Frekvens), frekvens);

        var kategori = comboboxKategori.ActiveText;
        var list = listMaker.GetKategorier();


        foreach (Kategori k in list)
        {
            if (k.Namn.Equals(kategori))
            {
                Kategori kategorin;
                kategorin = k;
                var newPodcast = new Podcast(url, frekvensen, kategorin);
                listMaker.AddPodcast(newPodcast);
            }
        }
        treeviewPodcast.RemoveColumn(treeviewPodcast.GetColumn(0));
        treeviewPodcast.RemoveColumn(treeviewPodcast.GetColumn(0));
        treeviewPodcast.RemoveColumn(treeviewPodcast.GetColumn(0));
        treeviewPodcast.RemoveColumn(treeviewPodcast.GetColumn(0));
        FillTreeviewPodcast();

    }

    protected void RemoveKategori(object sender, EventArgs e)
    {
        var listMaker = new ListMaker();
        var kategori = entryKategori.Text;
        listMaker.RemoveKategori(kategori);
        String clear = "";
        entryKategori.Text = clear;
        RemoveColumn(treeviewKategorier);
        FillTreeviewKategori();
        RemoveComboBox(comboboxKategori);
        FillComboBoxKategorier();
    }

    protected void OnTreeviewKategorierRowActivated(object o, RowActivatedArgs args)
    {
        var model = treeviewKategorier.Model;
        TreeIter iter;
        model.GetIter(out iter, args.Path);
        object value = model.GetValue(iter, 0);
        gtkKategori = value.ToString();

        entryKategori.Text = gtkKategori;

    }

    //protected void ShowDescription(object o, RowActivatedArgs args)
    //{
    //    var listMaker = new ListMaker();
    //    var lista = listMaker.allaAvsnitt;
    //    var model = treeviewAvsnitt.Model;

    //    TreeIter iter;
    //    model.GetIter(out iter, args.Path);
    //    object value = model.GetValue(iter, 0);
    //    var gtkAvsnitt = value.ToString();

    //    var description = lista
    //         .Where((p) => p.AvsnittsNamn.Equals(gtkAvsnitt))
    //         .Select(p => p.Podcasten);

    //    string output = description.ElementAt(0);



    //    textviewAvsnitt.Buffer.Text = output;



    //}

    protected void OnTreeviewPodcastRowActivated(object o, RowActivatedArgs args)
    {

        var model = treeviewPodcast.Model;
        TreeIter iter;
        model.GetIter(out iter, args.Path);
        object value = model.GetValue(iter, 1);
        gtkPodcast = value.ToString();
        entryURL.Text = gtkPodcast;

        FillTreeviewAvsnitt();


    }

    protected void RemovePodcast(object sender, EventArgs e)
    {

        var listMaker = new ListMaker();
        var podcast = entryURL.Text;
        listMaker.RemovePodcast(podcast);
        String clear = "http://";
        entryURL.Text = clear;
        treeviewPodcast.RemoveColumn(treeviewPodcast.GetColumn(0));
        treeviewPodcast.RemoveColumn(treeviewPodcast.GetColumn(0));
        treeviewPodcast.RemoveColumn(treeviewPodcast.GetColumn(0));
        treeviewPodcast.RemoveColumn(treeviewPodcast.GetColumn(0));
        FillTreeviewPodcast();


    }
}

