using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace currency_converter
{
    public class Model
    {
        //public async void abc() {
        //    var a = await "https://www.cbr-xml-daily.ru/daily_json.js".GetJsonAsync<Root>();
        //}
        public class Root
        {
            public DateTime Date { get; set; }
            public DateTime PreviousDate { get; set; }
            public string PreviousURL { get; set; }
            public DateTime Timestamp { get; set; }
            public Dictionary <string, Cash> Valute { get; set; }
        }
        public class Cash
        {
            public string ID { get; set; }
            public string NumCode { get; set; }
            public string CharCode { get; set; }
            public int Nominal { get; set; }
            public string Name { get; set; }
            public double Value { get; set; }
            public double Previous { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }

        public class Valute
        {
            public Cash AUD { get; set; }
            public Cash AZN { get; set; }
            public Cash GBP { get; set; }
            public Cash AMD { get; set; }
            public Cash BYN { get; set; }
            public Cash BGN { get; set; }
            public Cash BRL { get; set; }
            public Cash HUF { get; set; }
            public Cash VND { get; set; }
            public Cash HKD { get; set; }
            public Cash GEL { get; set; }
            public Cash DKK { get; set; }
            public Cash AED { get; set; }
            public Cash USD { get; set; }
            public Cash EUR { get; set; }
            public Cash EGP { get; set; }
            public Cash INR { get; set; }
            public Cash IDR { get; set; }
            public Cash KZT { get; set; }
            public Cash CAD { get; set; }
            public Cash QAR { get; set; }
            public Cash KGS { get; set; }
            public Cash CNY { get; set; }
            public Cash MDL { get; set; }
            public Cash NZD { get; set; }
            public Cash NOK { get; set; }
            public Cash PLN { get; set; }
            public Cash RON { get; set; }
            public Cash XDR { get; set; }
            public Cash SGD { get; set; }
            public Cash TJS { get; set; }
            public Cash THB { get; set; }
            public Cash TRY { get; set; }
            public Cash TMT { get; set; }
            public Cash UZS { get; set; }
            public Cash UAH { get; set; }
            public Cash CZK { get; set; }
            public Cash SEK { get; set; }
            public Cash CHF { get; set; }
            public Cash RSD { get; set; }
            public Cash ZAR { get; set; }
            public Cash KRW { get; set; }
            public Cash JPY { get; set; }
        }
    }
    
}
