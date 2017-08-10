using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using lab9kos.Util;

namespace lab9kos.Models.Domain
{
    public class Werkweek
    {
        public long Id { get; set; }

        private int _maandag;
        private int _dinsdag;
        private int _woensdag;
        private int _donderdag;
        private int _vrijdag;

        public int Maandag
        {
            get => _maandag;
            set
            {
                if (value < 0 || value > 8)
                {
                    throw new ArgumentException(value < 0 ? "Aantal uren was te klein" : "Aantal uren was te groot");
                }
                _maandag = value;
            }
        }

        public int Dinsdag
        {
            get => _dinsdag;
            set
            {
                if (value < 0 || value > 8)
                {
                    throw new ArgumentException(value < 0 ? "Aantal uren was te klein" : "Aantal uren was te groot");
                }
                _dinsdag = value;
            }
        }

        public int Woensdag
        {
            get => _woensdag;
            set
            {
                if (value < 0 || value > 8)
                {
                    throw new ArgumentException(value < 0 ? "Aantal uren was te klein" : "Aantal uren was te groot");
                }
                _woensdag = value;
            }
        }

        public int Donderdag
        {
            get => _donderdag;
            set
            {
                if (value < 0 || value > 8)
                {
                    throw new ArgumentException(value < 0 ? "Aantal uren was te klein" : "Aantal uren was te groot");
                }
                _donderdag = value;
            }
        }

        public int Vrijdag
        {
            get => _vrijdag;
            set
            {
                if (value < 0 || value > 8)
                {
                    throw new ArgumentException(value < 0 ? "Aantal uren was te klein" : "Aantal uren was te groot");
                }
                _vrijdag = value;
            }
        }

        public Gebruiker Werknemer { get; set; }
        public DateTime StartDatum { get; set; }

        public int GetWeekNummer() => DateUtilities.GetIso8601WeekOfYear(StartDatum);


        public String ToReadableFormat()
        {
            return Werknemer.Voornaam + " " + Werknemer.Naam + " - " + Maandag + " | " 
                + Dinsdag + " | " +Woensdag + " | " + Donderdag + " | " + Vrijdag + " \n";
        }
        public int GetYear() => StartDatum.Year;
    }
}