using HTK.Utilities;
using System;
using System.Collections.Generic;

namespace HTK.Entitties
{
    public partial class Reservations
    {
        private int reservationId;
        private DateTime reservationStart;
        private DateTime reservationEnd;
        private int courtId;

        public Reservations()
        {
            Members = new HashSet<Members>();
        }

        public int ReservationId
        {
            get => reservationId;
            set
            {
                (bool failed, string message) validation = Validation.IsTooLow("Reservation id", value, 1);

                if(validation.failed)
                    throw new ArgumentOutOfRangeException(nameof(ReservationId), validation.message);

                if(reservationId != value)
                    reservationId = value;
            }
        }
        public DateTime ReservationStart
        {
            get => reservationStart;
            set
            {
                (bool failed, string message) validation = Validation.IsWrongTime("Reservation tidspunktet", value);

                if(validation.failed)
                    throw new ArgumentOutOfRangeException(nameof(ReservationStart), validation.message);

                if(reservationStart != value)
                    reservationStart = value;

                reservationEnd = reservationStart.AddHours(1);
            }
        }
    
        public DateTime ReservationEnd
        {
            get => reservationEnd;
            set
            {
                if(ReservationStart == null)
                    throw new ArgumentNullException("Reservation tidspunkt ikke fundet");

                reservationEnd = ReservationStart.AddHours(1);
            }
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

        public virtual Courts Court { get; set; }
        public virtual ICollection<Members> Members { get; set; }
    }
}
