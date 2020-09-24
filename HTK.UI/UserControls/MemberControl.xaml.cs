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
    /// Interaction logic for MemberControl.xaml
    /// </summary>
    public partial class MemberControl: UserControl
    {
        MemberViewModel viewModel;
        private bool memberSelected;

        public MemberControl()
        {
            InitializeComponent();

            viewModel = DataContext as MemberViewModel;

            memberSelected = true;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            viewModel.LoadAll();

            if(viewModel.Members.Count > 0)
            {
                memberList.SelectedIndex = 0;
            }
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {

            if(memberSelected)
            {

                if(memberList.SelectedIndex < 0)
                {

                    try
                    {
                        viewModel.AddMember();
                    }
                    catch(Exception ex)
                    {

                        MessageBox.Show(viewModel.SelectedMember.MemberName);
                    }
                }

            }
            else
            {
                if(courtList.SelectedIndex < 0)
                {

                    try
                    {
                        viewModel.AddCourt();
                    }
                    catch(Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            if(memberSelected)
                memberList.SelectedIndex = -1;
            else
                courtList.SelectedIndex = -1;
        }
    }
}