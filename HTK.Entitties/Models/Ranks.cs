using HTK.Utilities;
using System;
using System.Collections.Generic;

namespace HTK.Entitties
{
    public partial class Ranks
    {
        private int rankId;
        private int rank;

        public Ranks()
        {
            Members = new HashSet<Members>();
        }

        public int RankId
        {
            get => rankId;
            set
            {
                (bool failed, string message) validation = Validation.IsTooLow("Rank id", value, 1);

                if(validation.failed)
                    throw new ArgumentOutOfRangeException(nameof(RankId), validation.message);

                if(rankId != value)
                    rankId = value;
            }
        }
        public int Rank
        {
            get => rank;
            set
            {
                (bool failed, string message) validation = Validation.IsTooLow("Rank", value, 1);

                if(validation.failed)
                    throw new ArgumentOutOfRangeException(nameof(Rank), validation.message);

                if(rank != value)
                    rank = value;
            }
        }
        public int Points { get; set; }

        public virtual ICollection<Members> Members { get; set; }
    }
}
