using System.ComponentModel;
using SQLite;

namespace FiveCast.Model
{
    public class Destination : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string country;
        public string Country
        {
            get => country;
            set { country = value; OnPropertyChanged(nameof(Country)); }
        }

        private string city;
        public string City
        {
            get => city;
            set { city = value; OnPropertyChanged(nameof(City)); }
        }

        private DateTime startDate;
        public DateTime StartDate
        {
            get => startDate;
            set { startDate = value; OnPropertyChanged(nameof(StartDate)); }
        }

        private int duration;
        public int Duration
        {
            get => duration;
            set { duration = value; OnPropertyChanged(nameof(Duration)); }
        }

        public DateTime EndDate => StartDate.AddDays(Duration);

        private string purpose;
        public string Purpose
        {
            get => purpose;
            set { purpose = value; OnPropertyChanged(nameof(Purpose)); }
        }

        private string status = "draft";
        public string Status
        {
            get => status;
            set { status = value; OnPropertyChanged(nameof(Status)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
