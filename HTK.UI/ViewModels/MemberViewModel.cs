using HTK.DataAccess;
using HTK.Entitties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace HTK.UI.ViewModels
{
    public class MemberViewModel : ViewModelBase
    {
        private Members selectedMember;
        private Courts selectedCourt;
        private List<Members> allMembers;

        private MemberRepository memberRep;
        private CourtRepository courtsRep;
        private string error;

        public ObservableCollection<Members> Members { get; set; }
        public ObservableCollection<Courts> Courts { get; set; }

        public string Error
        {
            get => error;
            set
            {
                error = value;

                OnPropertyChanged(nameof(Error));
            }
        }

        public Members SelectedMember
        {
            get => selectedMember;
            set
            {
                try
                {
                    selectedMember = value;

                    OnPropertyChanged(nameof(SelectedMember));
                }
                catch(ArgumentOutOfRangeException ex)
                {

                    Error = ex.Message;
                }
            }
        }
        public Courts SelectedCourt
        {
            get => selectedCourt;
            set
            {
                try
                {
                    selectedCourt = value;

                    OnPropertyChanged(nameof(SelectedCourt));
                }
                catch(ArgumentOutOfRangeException ex)
                {

                    Error = ex.Message;
                }
            }
        }

        public MemberViewModel()
        {
            memberRep = new MemberRepository();

            courtsRep = new CourtRepository();

            Members = new ObservableCollection<Members>();

            allMembers = new List<Members>();

            Courts = new ObservableCollection<Courts>();

            selectedMember = new Members();
        }

        public void LoadAll()
        {
            allMembers = memberRep.GetAll().ToList();

            List<Members> members = memberRep.GetActiveMembers().ToList();
            Members.Clear();

            foreach(var member in members)
            {
                Members.Add(member);
            }

            List<Courts> courts = courtsRep.GetAll().ToList();
            Courts.Clear();

            foreach(var court in courts)
            {
                Courts.Add(court);
            }
        }

        public void SaveMember()
        {
            memberRep.Update();
        }

        public void SaveCourt()
        {
            courtsRep.Update();
        }

        public void AddMember()
        {
            try
            {
                Members member = selectedMember;

                member.IsActive = true;

                memberRep.Add(member);

                Members.Add(member);
            }
            catch(Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void AddCourt()
        {
            try
            {
                Courts court = selectedCourt;

                courtsRep.Add(court);

                Courts.Add(court);
            }
            catch(Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }

    

}

