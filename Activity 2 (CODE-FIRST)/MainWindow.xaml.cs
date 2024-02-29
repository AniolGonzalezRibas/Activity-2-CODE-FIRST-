﻿using Activity_2__CODE_FIRST_.DAO;
using Activity_2__CODE_FIRST_.MODEL;
using CsvHelper;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Activity_2__CODE_FIRST_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IDAOManager manager;

        public MainWindow()
        {
            InitializeComponent();
            manager = DAOFactory.GetDAOManager();

            manager.ImportAll();
        }
    }
}