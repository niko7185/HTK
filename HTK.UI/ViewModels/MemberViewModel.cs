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

        public ObservableCollection<Members> Members { get; set; }
        public ObservableCollection<Courts> Courts { get; set; }

        public Members SelectedMember
        {
            get => selectedMember;
            set
            {
                selectedMember = value;

                OnPropertyChanged(nameof(SelectedMember));
            }
        }
        public Courts SelectedCourt
        {
            get => selectedCourt;
            set
            {
                selectedCourt = value;

                OnPropertyChanged(nameof(SelectedCourt));
            }
        }

        public MemberViewModel()
        {
            memberRep = new MemberRepository();

            courtsRep = new CourtRepository();

            Members = new ObservableCollection<Members>();

            allMembers = new List<Members>();

            Courts = new ObservableCollection<Courts>();
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
            }
            catch(Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }

    

}

