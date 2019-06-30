using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BV.PACS.Client.Services.Api;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Models.Parameters;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.Client.Sources
{
    // ReSharper disable once InconsistentNaming
    public class SourceTrackingPanelCode : ComponentBase

    {
        [Parameter]
        protected int Id { get; set; }

        [Inject]
        protected HttpClient Http { get; set; }

        [Inject]
        protected LookupService ApiLookupService { get; set; }

        protected string SourceBarcode
        {
            get => TrackingObject.SourceBarcode;
            set => TrackingObject.SourceBarcode = value;
        }

        protected DateTime SourceRegistrationDate
        {
            get => TrackingObject.SourceRegistrationDate;
            set => TrackingObject.SourceRegistrationDate = value;
        }

        protected string SourceType
        {
            get => TrackingObject.SourceType;
            set => TrackingObject.SourceType = value;
        }

        protected TemplateLookupItem[] Templates { get; set; }

        protected TemplateLookupItem Template
        {
            get { return Templates.FirstOrDefault(t => t.Id == TrackingObject.SourceTemplateId); }
            set
            {
                TrackingObject.SourceTemplateId = value.Id;
                TrackingObject.SourceTemplateName = value.Name;
            }
        }


        protected string SourceNote
        {
            get => TrackingObject.SourceNote;
            set => TrackingObject.SourceNote = value;
        }

        protected string SourcePointOfOrigin
        {
            get => TrackingObject.SourcePointOfOrigin;
            set => TrackingObject.SourcePointOfOrigin = value;
        }


        protected SourceTrackingDto TrackingObject { get; set; }

        protected override async Task OnInitAsync()
        {
            await GetData(new TrackingParameter(Id, BaseSettings.Language));
            await GetLookups();
        }

        private async Task GetLookups()
        {
            Templates = await ApiLookupService.GetTemplatesLookup(Http, FormTypes.Source);
        }

        private async Task GetData(TrackingParameter parameter)
        {
            var attr = typeof(SourceTrackingDto).GetCustomAttributes(typeof(DataUrlAttribute), false).FirstOrDefault();
            if (attr is DataUrlAttribute urlAttribute)
            {
                TrackingObject = await Http.PostJsonAsync<SourceTrackingDto>(urlAttribute.Url, parameter);
            }
        }
    }
}