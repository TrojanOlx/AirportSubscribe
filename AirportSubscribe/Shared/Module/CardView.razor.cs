using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.SmartEnum;

namespace AirportSubscribe.Shared.Module
{
    public partial class CardView
    {


        public class CardModel
        {
            public string S { get; set; }

        }


        public sealed class CardHeaderColor : SmartEnum<CardHeaderColor, string>
        {
            public static readonly CardHeaderColor Warning = new(nameof(Warning), "card-header-warning");
            public static readonly CardHeaderColor Success = new(nameof(Success), "card-header-success");
            public static readonly CardHeaderColor Danger = new(nameof(Danger), "card-header-danger");
            public static readonly CardHeaderColor Info = new(nameof(Info), "card-header-info");
            public static readonly CardHeaderColor Primary = new(nameof(Primary), "card-header-primary");
            public static readonly CardHeaderColor Rose = new(nameof(Rose), "card-header-rose");

            public CardHeaderColor(string name, string value) : base(name, value)
            {
            }
        }


    }
}
