﻿using HTK.UI.ViewModels;

using System;
using System.Collections.Generic;
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

namespace HTK.UI.UserControls
{
    /// <summary>
    /// Interaction logic for RankControl.xaml
    /// </summary>
    public partial class RankControl: UserControl
    {
        private RankViewModel viewModel;

        public RankControl()
        {
            InitializeComponent();

            viewModel = DataContext as RankViewModel;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            viewModel.LoadAll();


        }


    }
}
