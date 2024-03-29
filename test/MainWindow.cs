
using System;
using System.Linq;
using Gtk;
using logic;
using Validation;

public partial class MainWindow : Gtk.Window
{
    ListMaker ListMaker;
    PodcastValidation PodcastValidation;
    CategoryValidation CategoryValidation;
    string gtkKategori = "";
    string gtkPodcast = "";




    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        ListMaker = new ListMaker();
        PodcastValidation = new PodcastValidation();
        CategoryValidation = new CategoryValidation();
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
        try
        {
            var i = 1;
            foreach (var f in Enum.GetNames(typeof(Frekvens)))
            {
                comboboxFrekvens.InsertText(i, f);
                i++;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void FillComboBoxKategorier()
    {
        try
        {
            var lista = ListMaker.KategoriList;
            var i = 0;

            foreach (var k in lista)
            {
                comboboxKategori.InsertText(i, k.Namn);
                i++;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private void FillTreeviewPodcast()
    {
        try
        {
            String clear = "";
            entryNamn.Text = clear;
            treeviewAvsnitt.RemoveColumn(treeviewAvsnitt.GetColumn(0));
            var lista = ListMaker.PodcastList;

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
                var avsnitt = p.AvsnittsLista.Count.ToString();
                podcastListStore.AppendValues(avsnitt, namn, frekvens, kategori);
            }


            treeviewPodcast.Model = podcastListStore;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private void FillTreeviewPodcast(String kategorin)
    {
        try
        {
            if (kategorin.Equals(""))
            {
                FillTreeviewPodcast();
            }
            else
            {
                String clear = "";
                entryNamn.Text = clear;
                treeviewAvsnitt.RemoveColumn(treeviewAvsnitt.GetColumn(0));

                var lista = ListMaker.PodcastList;

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
                    var kategori = p.Kategorin.Namn;

                    if (kategorin.Equals(kategori))
                    {
                        var namn = p.Namn;
                        var frekvens = p.Frekvensen.ToString();
                        var avsnitt = p.AvsnittsLista.Count.ToString();
                        podcastListStore.AppendValues(avsnitt, namn, frekvens, kategori);
                    }
                }
                treeviewPodcast.Model = podcastListStore;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }


    private void FillTreeviewKategori()
    {
        try
        {
            var lista = ListMaker.KategoriList;

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
            }
            treeviewKategorier.Model = kategoriListStore;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
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
        try
        {
            ListMaker.UpdateAvsnitt();
            var podcast = gtkPodcast;
            var podcastList = ListMaker.PodcastList;

            Gtk.TreeViewColumn avsnittColumn = new Gtk.TreeViewColumn();
            avsnittColumn.Title = "Avsnitt:";
            Gtk.CellRendererText avsnittNameCell = new Gtk.CellRendererText();
            avsnittColumn.PackStart(avsnittNameCell, true);
            treeviewAvsnitt.AppendColumn(avsnittColumn);
            avsnittColumn.AddAttribute(avsnittNameCell, "text", 0);
            Gtk.ListStore avsnittListStore = new Gtk.ListStore(typeof(string));

            foreach (Podcast p in podcastList)
            {
                if (podcast.Equals(p.Namn))
                {

                    var avsnittsList = p.AvsnittsLista;

                    foreach (Avsnitt a in avsnittsList)
                    {

                        avsnittListStore.AppendValues(a.Namn);
                    }
                }
            }
            treeviewAvsnitt.Model = avsnittListStore;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    protected void AddKategori(object sender, EventArgs e)
    {
        try
        {
            var kategori = entryKategori.Text;

            if (CategoryValidation.ValidateInput(kategori))
            {

                var newKategori = new Kategori(kategori);
                ListMaker.AddKategori(newKategori);
                String clear = "";
                entryKategori.Text = clear;
                RemoveColumn(treeviewKategorier);
                FillTreeviewKategori();
                RemoveComboBox(comboboxKategori);
                FillComboBoxKategorier();
            }
        }
        catch (Exception a)
        {
            Console.WriteLine(a.Message);
        }
    }

    protected void AddPodFeed(object sender, EventArgs e)
    {
        try
        {
            var url = entryURL.Text;
            var frekvens = comboboxFrekvens.ActiveText;
            var kategori = comboboxKategori.ActiveText;

            if (PodcastValidation.ValidateInput(entryURL.Text) && PodcastValidation.IsComboBoxEmpty(frekvens, kategori))
            {

                Frekvens frekvensen = (Frekvens)Enum.Parse(typeof(Frekvens), frekvens);

                var list = ListMaker.KategoriList;

                foreach (Kategori k in list)
                {
                    if (k.Namn.Equals(kategori))
                    {
                        Kategori kategorin;
                        kategorin = k;
                        var newPodcast = new Podcast(url, frekvensen, kategorin);
                        ListMaker.AddPodcast(newPodcast);
                    }
                }
                treeviewPodcast.RemoveColumn(treeviewPodcast.GetColumn(0));
                treeviewPodcast.RemoveColumn(treeviewPodcast.GetColumn(0));
                treeviewPodcast.RemoveColumn(treeviewPodcast.GetColumn(0));
                treeviewPodcast.RemoveColumn(treeviewPodcast.GetColumn(0));
                FillTreeviewPodcast();
            }
        }
        catch (Exception a)
        {
            Console.WriteLine(a.Message);
        }
    }

    protected void RemoveKategori(object sender, EventArgs e)
    {
        try
        {
            var kategori = entryKategori.Text;

            if (CategoryValidation.ValidateInput(kategori))
            {

                ListMaker.RemoveKategori(kategori);
                String clear = "";
                entryKategori.Text = clear;
                RemoveColumn(treeviewKategorier);
                FillTreeviewKategori();
                RemoveComboBox(comboboxKategori);
                FillComboBoxKategorier();
            }
        }
        catch (Exception a)
        {
            Console.WriteLine(a.Message);
        }
    }

    protected void OnTreeviewKategorierRowActivated(object o, RowActivatedArgs args)
    {
        try
        {
            var model = treeviewKategorier.Model;
            TreeIter iter;
            model.GetIter(out iter, args.Path);
            object value = model.GetValue(iter, 0);
            gtkKategori = value.ToString();
            entryKategori.Text = gtkKategori;
        }
        catch (Exception a)
        {
            Console.WriteLine(a.Message);
        }
    }

    protected void ShowDiscription(object o, RowActivatedArgs args)
    {
        try
        {
            var podcastList = ListMaker.PodcastList;
            var model = treeviewAvsnitt.Model;
            TreeIter iter;
            model.GetIter(out iter, args.Path);
            object value = model.GetValue(iter, 0);
            var gtkAvsnitt = value.ToString();

            foreach (Podcast p in podcastList)
            {
                var avsnittsList = p.AvsnittsLista;

                foreach (Avsnitt a in avsnittsList)
                {
                    if (gtkAvsnitt.Equals(a.Namn))
                    {
                        textviewAvsnitt.Buffer.Text = a.Beskrivning;
                    }
                }
            }
        }
        catch (Exception a)
        {
            Console.WriteLine(a.Message);
        }
    }

    protected void OnTreeviewPodcastRowActivated(object o, RowActivatedArgs args)
    {
        try
        {
            var model = treeviewPodcast.Model;
            TreeIter iter;
            model.GetIter(out iter, args.Path);
            object value = model.GetValue(iter, 1);
            gtkPodcast = value.ToString();
            entryNamn.Text = gtkPodcast;
            RemoveColumn(treeviewAvsnitt);
            FillTreeviewAvsnitt();

            var list = ListMaker.PodcastList;
            string url = "Saknar URL?!?!?!";

            foreach (var p in list)
            {
                if (gtkPodcast.Equals(p.Namn))
                {
                    url = p.URL;
                }
            }
            entryURL.Text = url;
        }
        catch (Exception a)
        {
            Console.WriteLine(a.Message);
        }
    }

    protected void RemovePodcast(object sender, EventArgs e)
    {
        try
        {

            if (PodcastValidation.IsInputEmpty(gtkPodcast))
            {
                ListMaker.RemovePodcast(gtkPodcast);
                String clear = "http://";
                entryNamn.Text = clear;
                treeviewPodcast.RemoveColumn(treeviewPodcast.GetColumn(0));
                treeviewPodcast.RemoveColumn(treeviewPodcast.GetColumn(0));
                treeviewPodcast.RemoveColumn(treeviewPodcast.GetColumn(0));
                treeviewPodcast.RemoveColumn(treeviewPodcast.GetColumn(0));
                FillTreeviewPodcast();
            }
        }
        catch (Exception a)
        {
            Console.WriteLine(a.Message);
        }
    }

    protected void ChangePodcast(object sender, EventArgs e)
    {
        try
        {
            var url = entryURL.Text;
            var frekvens = comboboxFrekvens.ActiveText;
            var kategori = comboboxKategori.ActiveText;

            if (PodcastValidation.IsInputEmpty(gtkPodcast) && PodcastValidation.ValidateInput(url) && PodcastValidation.IsComboBoxEmpty(frekvens, kategori))
            {


                Frekvens frekvensen = (Frekvens)Enum.Parse(typeof(Frekvens), frekvens);

                var list = ListMaker.KategoriList;

                foreach (Kategori k in list)
                {
                    if (k.Namn.Equals(kategori))
                    {
                        Kategori kategorin;
                        kategorin = k;
                        ListMaker.ChangePodcast(gtkPodcast, frekvensen, kategorin, url);
                    }
                }
                String clear = "";
                entryNamn.Text = clear;
                treeviewPodcast.RemoveColumn(treeviewPodcast.GetColumn(0));
                treeviewPodcast.RemoveColumn(treeviewPodcast.GetColumn(0));
                treeviewPodcast.RemoveColumn(treeviewPodcast.GetColumn(0));
                treeviewPodcast.RemoveColumn(treeviewPodcast.GetColumn(0));
                FillTreeviewPodcast();
            }
        }
        catch (Exception a)
        {
            Console.WriteLine(a.Message);
        }
    }

    protected void ShowKategori(object sender, EventArgs e)
    {
        try
        {
            var kategori = entryKategori.Text;

            if (CategoryValidation.ValidateInput(kategori))
            {

                treeviewPodcast.RemoveColumn(treeviewPodcast.GetColumn(0));
                treeviewPodcast.RemoveColumn(treeviewPodcast.GetColumn(0));
                treeviewPodcast.RemoveColumn(treeviewPodcast.GetColumn(0));
                treeviewPodcast.RemoveColumn(treeviewPodcast.GetColumn(0));
                FillTreeviewPodcast(kategori);
            }
        }
        catch (Exception a)
        {
            Console.WriteLine(a.Message);
        }
    }

    protected void ChangeCategory(object sender, EventArgs e)
    {
        try
        {
            var kategori = entryKategori.Text;

            if (CategoryValidation.ValidateInput(kategori))
            {

                string nyKategori = entryKategori.Text;
                ListMaker.ChangeCategory(kategori, nyKategori);
                String clear = "";
                entryKategori.Text = clear;
                RemoveColumn(treeviewKategorier);
                FillTreeviewKategori();
                RemoveComboBox(comboboxKategori);
                FillComboBoxKategorier();
            }
        }
        catch (Exception a)
        {
            Console.WriteLine(a.Message);
        }
    }


        protected async void ShowNumberOfCategorys(object sender, EventArgs e)
    {
        try
        {
            var lista = await ListMaker.GetAllKategorier();

            var i = lista.Count;

            string message = "Du har " + i/2 + " kategorier!";

            entryKategori.Text = message;

        }
        catch (Exception a)
        {
            Console.WriteLine(a.Message);

        }
    }

}

