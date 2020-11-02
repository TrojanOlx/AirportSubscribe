using AirportSubscribe.Models;
using AntDesign;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static AirportSubscribe.Servers.Urls.AddAirportUrl;

namespace AirportSubscribe.Pages.UrlConfiguration
{
    public partial class List : ComponentBase
    {

        [Inject]
        private  IMediator _mediator { get; set; }


        private readonly BasicListFormModel _model = new BasicListFormModel();

        private readonly IDictionary<string, ProgressStatus> _pStatus = new Dictionary<string, ProgressStatus>
        {
            {"active", ProgressStatus.Active},
            {"exception", ProgressStatus.Exception},
            {"normal", ProgressStatus.Normal},
            {"success", ProgressStatus.Success}
        };

        private ListItemDataType[] _data = { };


        private AddAipportUrlCommand aipportUrlCommand = new AddAipportUrlCommand();

        
        public List()
        {

        }

        private async Task OnFinish(EditContext editContext)
        {
            await _mediator.Send(aipportUrlCommand);
            Console.WriteLine($"Success:{JsonConvert.SerializeObject(aipportUrlCommand)}");
        }

        private void OnFinishFailed(EditContext editContext)
        {
            Console.WriteLine($"Failed:{JsonConvert.SerializeObject(aipportUrlCommand)}");
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
