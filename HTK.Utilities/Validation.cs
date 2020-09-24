using System;
using System.Collections.Generic;
using System.Text;

namespace HTK.Utilities
{
    public static class Validation
    {

        public static (bool, string) IsTooLong(string prop, string value, int length)
        {
            bool isTooLong = value.Length > length;

            return (isTooLong, prop + " er for langt. Maximum antal bogstaver er " + length);
        }

        public static (bool, string) IsTooLow(string prop, int value, int min)
        {
            bool isTooLow = value < min;

            return (isTooLow, prop + " er for lavt. Minimum er " + min);
        }

        public static (bool, string) IsFutureDate(string prop, DateTime value)
        {
            bool isFutureDate = value > DateTime.Now;

            return (isFutureDate, prop + " kan ikke være i fremtiden");
        }

        public static (bool, string) IsWrongTime(string prop, DateTime value)
        {
            int hour = value.Hour;
            bool isWrongTime = !(hour >= 10 && hour <= 14) && !(hour >= 18 && hour <= 21);

            return (isWrongTime, prop + " kan kun være i mellem 10:00-14:00 og 18:00-21:00");
        }

    }
}
