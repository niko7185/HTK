using HTK.UI.ViewModels;
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

            //Save the viewmodel from the datacontext to a field
            viewModel = DataContext as MemberViewModel;

            memberSelected = true;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            //Load all members from db
            viewModel.LoadAll();

            if(viewModel.Members.Count > 0)
            {
                memberList.SelectedIndex = 0;
            }
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {

            //Save or add either members or courts depending on which is selected
            if(memberSelected)
            {

                try
                {

                    //If a member is selected then update it. If not add it
                    if(memberList.SelectedIndex < 0)
                    {
                        viewModel.AddMember(level.SelectedIndex);
                    }
                    else
                    {
                        viewModel.SaveMember();
                    }

                    viewModel.Error = "";
                }
                catch(Exception ex)
                {

                    viewModel.Error = ex.Message;
                }

            }
            else
            {
                try
                {
                    //If a court is selected then update it. If not add it
                    if(courtList.SelectedIndex < 0)
                    {
                        viewModel.AddCourt();
                    }
                    else
                    {
                        viewModel.SaveCourt();
                    }

                    viewModel.Error = "";
                }
                catch(Exception ex)
                {

                    MessageBox.Show(ex.Message);

                    viewModel.Error = ex.Message;
                }
            }

            AddBtn.IsEnabled = true;
            level.IsEnabled = false;
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            if(memberSelected)
                memberList.SelectedIndex = -1;
            else
                courtList.SelectedIndex = -1;

            AddBtn.IsEnabled = false;

            level.IsEnabled = true;
        }
    }
}
