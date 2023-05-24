using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static currency_converter.Model;

namespace currency_converter.ViewModel
{
    internal class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        static public DateTime currDate = DateTime.Now;
        private ObservableCollection<Cash> valuteList = new();
        private DateTime update;

        public DateTime Update
        {
            get => update;
            set
            {
                if (update == value)
                {
                    return;
                }
                update = value;
                OnPropertyChanged(nameof(update));
                LoadData(update);
            }
        }

        public ObservableCollection<Cash> ValuteList
        {
            get => valuteList;
            set
            {
                if (valuteList != value)
                {
                    valuteList = value;
                    OnPropertyChanged(nameof(ValuteList));
                }
            }
        }

        public async void LoadData(DateTime date)
        {
            string month = date.Month.ToString("D2");
            string day = date.Day.ToString("D2");

            var res = await $"https://www.cbr-xml-daily.ru/archive/{date.Year}/{month}/{day}/daily_json.js".AllowHttpStatus("404").GetJsonAsync<Root>();
            if (res.Valute != null)
            {
                ValuteList.Clear();
                ValuteList.Add(new Cash() { Name = "Российский рубль", Value = 1, Nominal = 1 });
            }
        }
        public void OnPropertyChanged(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
