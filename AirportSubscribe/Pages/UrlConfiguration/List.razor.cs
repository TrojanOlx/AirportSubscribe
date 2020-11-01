using AirportSubscribe.Models;
using AntDesign;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AirportSubscribe.Pages.UrlConfiguration
{
    public partial class List : ComponentBase
    {
        private readonly BasicListFormModel _model = new BasicListFormModel();

        private readonly IDictionary<string, ProgressStatus> _pStatus = new Dictionary<string, ProgressStatus>
        {
            {"active", ProgressStatus.Active},
            {"exception", ProgressStatus.Exception},
            {"normal", ProgressStatus.Normal},
            {"success", ProgressStatus.Success}
        };

        private ListItemDataType[] _data = { };



        private void ShowModal()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();


            var str = File.ReadAllText("./wwwroot/data/fake_list.json");


            var list = JsonConvert.DeserializeObject<List<ListItemDataType>>(str);
            _data = list.ToArray();

        }

    }
}
