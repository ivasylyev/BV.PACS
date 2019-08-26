using System;
using System.Linq;
using System.Threading.Tasks;
using BV.PACS.WEB.Client.I18nText;
using BV.PACS.WEB.Client.Shared.Base;
using BV.PACS.WEB.Shared.Models;
using BV.PACS.WEB.Shared.Models.Parameters;

namespace BV.PACS.WEB.Client.Sources
{
    // ReSharper disable once InconsistentNaming
    public class SourceTrackingPanelCode : TrackingPanel<SourceTrackingDto, SourceTrackingPanel>
    {
        protected SourceMaterialTypeLookupItem SourceTypeSelectedItem { get; set; } = new SourceMaterialTypeLookupItem();
        protected SourceMaterialTypeLookupItem[] SourceTypes { get; set; }

        protected TemplateLookupItem Template
        {
            get { return Templates.FirstOrDefault(t => t.Id == TrackingObject.SourceTemplateId); }
            set
            {
                TrackingObject.SourceTemplateId = value.Id;
                TrackingObject.SourceTemplateName = value.Name;
            }
        }

        protected override async Task GetLookups()
        {
            await GetLookups(FormTypes.Source);
        }

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

        protected string SourceTypeId
        {
            get => TrackingObject.SourceTypeId;
            set => TrackingObject.SourceTypeId = value;
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


        protected void SourceTypeCancelled()
        {
            StateHasChanged();
        }

        protected void SourceTypeSelected(SourceMaterialTypeLookupItem selected)
        {
            SourceTypeSelectedItem = selected;

            SourceType = selected?.Name;
            SourceTypeId = selected?.Id;
            Console.WriteLine(SourceType);
            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            SourceTypes = await ApiLookupService.GetSourceMaterialTypesLookup(Http, SourceMaterialTypeLookupParameter.Source);
            SourceTypeSelectedItem = SourceTypes.FirstOrDefault(t => t.Id == SourceTypeId) ?? new SourceMaterialTypeLookupItem();
            StateHasChanged();
        }
    }
}