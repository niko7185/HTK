using HTK.Utilities;
using System;
using System.Collections.Generic;

namespace HTK.Entitties
{
    public partial class Courts
    {

        private string courtName;
        private int courtId;

        public Courts()
        {
            Reservations = new HashSet<Reservations>();
        }

        public int CourtId
        {
            get => courtId;
            set
            {
                (bool failed, string message) validation = Validation.IsTooLow("Bane id", value, 1);

                if(validation.failed)
                    throw new ArgumentOutOfRangeException(nameof(CourtId), validation.message);

                if(courtId != value)
                    courtId = value;
            }
        }
        public string CourtName 
        {
            get => courtName;
            set
            {
                (bool failed, string message) validation = Validation.IsTooLong("Bane navn", value, 10);

                if(validation.failed)
                    throw new ArgumentOutOfRangeException(nameof(CourtName), validation.message);

                if(courtName != value)
                    courtName = value;
            }
        }

        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
