﻿using System;
using System.Collections.Generic;
using System.IO;
using Gtk;
using logic;

namespace test
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();
            

           
           

        }
    }
}
