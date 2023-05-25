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
        private DateTime select_date = DateTime.Today;
        private Cash firstValue;
        private Cash secondValue;
        private string getValue;

        public ViewModel() 
        {
            LoadData(currDate);
        }

        public DateTime Select_date
        {
            get => select_date;
            set
            {
                if (select_date == value)
                {
                    return;
                }
                select_date = value;
                OnPropertyChanged(nameof(Select_date));
                LoadData(select_date);
                OnPropertyChanged(nameof(Total));
            }
        }

        public Cash FirstValue
        {
            get => firstValue;
            set
            {
                if (firstValue == value)
                { return; }
                firstValue = value; 
                OnPropertyChanged(nameof(FirstValue));
                OnPropertyChanged(nameof(Total));
            }
        }

        public Cash SecondValue
        {
            get => secondValue;
            set
            {
                if (secondValue == value)
                { return; }
                secondValue = value;
                OnPropertyChanged(nameof(SecondValue));
                OnPropertyChanged(nameof(Total));
            }
        }

        public string GetValue
        {
            get => getValue;
            set
            {
                if (getValue == value)
                {
                    return;
                }
                getValue = value;
                OnPropertyChanged(nameof(GetValue));
                OnPropertyChanged(nameof(Total));
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
            if (select_date != date)
            {
                select_date = date;
                OnPropertyChanged(nameof(Select_date));
            }
            string month, day;
            string f_name = null, s_name = null;

            if (FirstValue != null)
            {
                f_name = FirstValue.Name;
            }
            if (SecondValue != null)
            {
                s_name = SecondValue.Name;
            }

            month = date.Month.ToString("D2");
            day = date.Day.ToString("D2");
            var res = await $"https://www.cbr-xml-daily.ru/archive/{date.Year}/{month}/{day}/daily_json.js".AllowHttpStatus("404").GetJsonAsync<Root>();
            if (res.Valute != null)
            {
                ValuteList.Clear();
                ValuteList.Add(new Cash() { Name = "Российский рубль", Value = 1, Nominal = 1 });
                foreach (var a in res.Valute.Valutes)
                {
                    ValuteList.Add(new Cash() { Name = a.Name, Value = a.Value, Nominal = a.Nominal });
                }
                FirstValue = ValuteList.FirstOrDefault(check1 => check1.Name == f_name);
                SecondValue = ValuteList.FirstOrDefault(check2 => check2.Name == s_name);
                OnPropertyChanged(nameof(Select_date));
                OnPropertyChanged(nameof(Total));
                return;
            }
            Select_date = date.AddDays(-1);
                     
            
        }
        public double Total
        {
            get
            {
                if (SecondValue == null || FirstValue == null) return 0;
                if (double.TryParse(getValue, out var new_value))
                {
                    return Math.Round(new_value * FirstValue.Value / FirstValue.Nominal / SecondValue.Value / SecondValue.Nominal, 6);
                }
                return 0;
            }
        }
        public void OnPropertyChanged(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
