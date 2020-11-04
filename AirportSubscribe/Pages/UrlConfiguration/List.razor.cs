using AirportSubscribe.Models;
using AirportSubscribe.Models.Dto;
using AirportSubscribe.Models.UrlModels;
using AirportSubscribe.Models.UrlModels.Dto;
using AirportSubscribe.Servers.Urls;
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
        private IMediator _mediator { get; set; }

        [Inject]
        MessageService _message { get; set; }

        private Form<AddAipportUrlCommand> form = new Form<AddAipportUrlCommand>();


        private readonly IDictionary<string, ProgressStatus> _pStatus = new Dictionary<string, ProgressStatus>
        {
            {"active", ProgressStatus.Active},
            {"exception", ProgressStatus.Exception},
            {"normal", ProgressStatus.Normal},
            {"success", ProgressStatus.Success}
        };

        //private ListItemDataType[] _data = { };


        private AddAipportUrlCommand aipportUrlCommand = new AddAipportUrlCommand();


        private static ProgressStatus GetSpeedStatus(decimal speed) => speed switch
        {
            _ when speed >= 0 && speed < 100 => ProgressStatus.Exception,
            _ when speed >= 100 && speed < 1000 => ProgressStatus.Active,
            _ when speed >= 1000 && speed < 3000 => ProgressStatus.Normal,
            _ when speed > 3000 => ProgressStatus.Success,
            _ => ProgressStatus.Exception
        };

        private static int GetSpeedPercent(decimal speed) => speed > 3000 ? 100 : (int)(speed / 3000 * 100);

        private PageListOutDto<UrlModelOutDto> _model = new PageListOutDto<UrlModelOutDto>();

        private async Task OnFinish(EditContext editContext)
        {
            if (await _mediator.Send(aipportUrlCommand))
            {
                _model = await _mediator.Send(new GetAirportUrlList.GetAirportUrlListQuery());
                isShowAdd = false;
                form.Reset();
            }
        }

        private void OnFinishFailed(EditContext editContext)
        {
            Console.WriteLine($"Failed:{JsonConvert.SerializeObject(aipportUrlCommand)}");
        }


        private async Task OnEdit(UrlModelOutDto item)
        {
            _message.Info("Edit Success" + item.Id);
            Console.WriteLine("Edit");
        }


        private async Task OnDelete(UrlModelOutDto item)
        {
            if (await _mediator.Send(new RemoveAirportUrl.RemoveAirportUrlCommand(item.Id)))
            {
                _model = await _mediator.Send(new GetAirportUrlList.GetAirportUrlListQuery());
                _message.Info("Delete Success" + item.Id);
            }
            else
            {
                _message.Error("Delete Error");
            }
            
            Console.WriteLine("delete");
        }




        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _model = await _mediator.Send(new GetAirportUrlList.GetAirportUrlListQuery());
        }


    }
}
