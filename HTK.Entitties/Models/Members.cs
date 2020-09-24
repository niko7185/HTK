using HTK.Utilities;
using System;
using System.Collections.Generic;

namespace HTK.Entitties
{
    public partial class Members
    {

        private int memberId;
        private string memberName;
        private string memberAddress;
        private string memberPhone;
        private string memberMail;
        private DateTime memberBirthDate;
        private bool isActive;
        private int rankId;

        public int MemberId
        {
            get => memberId;
            set
            {
                (bool failed, string message) validation = Validation.IsTooLow("Medlem id", value, 1);

                if(validation.failed)
                    throw new ArgumentOutOfRangeException(nameof(MemberId), validation.message);

                if(memberId != value)
                    memberId = value;
            }
        }
        public string MemberName
        {
            get => memberName;
            set
            {
                (bool failed, string message) validation = Validation.IsTooLong("Navn", value, 20);

                if(validation.failed)
                    throw new ArgumentOutOfRangeException(nameof(MemberId), validation.message);

                if(memberName != value)
                    memberName = value;
            }
        }
        public string MemberAddress
        {
            get => memberAddress;
            set
            {
                (bool failed, string message) validation = Validation.IsTooLong("Adresse", value, 20);

                if(validation.failed)
                    throw new ArgumentOutOfRangeException(nameof(MemberAddress), validation.message);

                if(memberAddress != value)
                    memberAddress = value;
            }
        }
        public string MemberPhone
        {
            get => memberPhone;
            set
            {
                (bool failed, string message) validation = Validation.IsTooLong("Mobilnummer", value, 20);

                if(validation.failed)
                    throw new ArgumentOutOfRangeException(nameof(MemberPhone), validation.message);

                if(memberPhone != value)
                    memberPhone = value;
            }
        }
        public string MemberMail
        {
            get => memberMail;
            set
            {
                (bool failed, string message) validation = Validation.IsTooLong("E-mail", value, 20);

                if(validation.failed)
                    throw new ArgumentOutOfRangeException(nameof(MemberMail), validation.message);

                if(memberMail != value)
                    memberMail = value;
            }
        }
        public DateTime MemberBirthDate
        {
            get => memberBirthDate;
            set
            {
                (bool failed, string message) validation = Validation.IsFutureDate("Fødselsdato", value);

                if(validation.failed)
                    throw new ArgumentOutOfRangeException(nameof(MemberBirthDate), validation.message);

                if(memberBirthDate != value)
                    memberBirthDate = value;
            }
        }
        public bool IsActive
        {
            get => isActive;
            set
            {
                if(isActive != value)
                    isActive = value;
            }
        }
        public int? ReservationId { get; set; }
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

        public virtual Ranks Rank { get; set; }
        public virtual Reservations Reservation { get; set; }
    }
}
