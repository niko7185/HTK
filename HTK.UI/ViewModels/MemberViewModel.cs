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
        private RankRepository rankRep;
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
            //initializing fields
            memberRep = new MemberRepository();

            courtsRep = new CourtRepository();

            Members = new ObservableCollection<Members>();

            allMembers = new List<Members>();

            Courts = new ObservableCollection<Courts>();

            selectedMember = new Members();

            rankRep = new RankRepository();
        }

        public async void LoadAll()
        {
            //Retrieve all members and courts from db asynchronously 
            allMembers = (List<Members>)await memberRep.GetAll();

            List<Members> members = (List<Members>)await memberRep.GetActiveMembers();
            Members.Clear();

            foreach(var member in members)
            {
                Members.Add(member);
            }

            List<Courts> courts = (List<Courts>)await courtsRep.GetAll();
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

        public void AddMember(int level)
        {
            // Add new member with the user-entered values and add it to the db
            try
            {
                Members member = new Members();

                Ranks rank = new Ranks();

                rank.Points = 50 + (level * 10);

                member.Rank = rank;

                member.MemberMail = selectedMember.MemberMail;

                member.MemberName = selectedMember.MemberName;

                member.MemberAddress = selectedMember.MemberAddress;

                member.IsActive = true;

                member.MemberBirthDate = selectedMember.MemberBirthDate;

                member.MemberPhone = selectedMember.MemberPhone;

                rankRep.Add(rank);

                member.IsActive = true;

                memberRep.Add(member);

                Members.Add(member);
            }
            catch(Exception ex)
            {

                throw new Exception(ex.GetType().ToString());
            }
        }

        public void AddCourt()
        {
            // Add new court with the user-entered value and add it to the db
            try
            {
                Courts court = new Courts();

                court.CourtName = selectedCourt.CourtName;

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

