using HTK.DataAccess;
using HTK.Entitties;
using HTK.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HTK.UI.ViewModels
{
    public class RankViewModel : ViewModelBase
    {
        private MemberRepository memberRep;
        private RankService service;

        public ObservableCollection<Members> Members { get; set; }

        public RankViewModel()
        {
            Members = new ObservableCollection<Members>();

            memberRep = new MemberRepository();

            service = new RankService();
        }

        public async void LoadAll()
        {

            List<Members> members = await service.GetMembersAsync();
            Members.Clear();

            foreach(var member in members)
            {
                Members.Add(member);
            }
        }

    }
}
