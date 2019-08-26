using System;
using System.Linq;
using System.Threading.Tasks;
using BV.PACS.WEB.Client.I18nText;
using BV.PACS.WEB.Client.Shared.Base;
using BV.PACS.WEB.Shared.Models;
using BV.PACS.WEB.Shared.Models.Parameters;

namespace BV.PACS.WEB.Client.Materials
{
    public class MaterialTrackingPanelCode : TrackingPanel<MaterialTrackingDto, MaterialTrackingPanel>
    {
        protected SourceMaterialTypeLookupItem MaterialTypeSelectedItem { get; set; } = new SourceMaterialTypeLookupItem();
        protected SourceMaterialTypeLookupItem[] MaterialTypes { get; set; }

        protected TemplateLookupItem Template
        {
            get { return Templates.FirstOrDefault(t => t.Id == TrackingObject.MaterialTemplateId); }
            set
            {
                TrackingObject.MaterialTemplateId = value.Id;
                TrackingObject.MaterialTemplateName = value.Name;
            }
        }

        protected override async Task GetLookups()
        {
            await GetLookups(FormTypes.Material);
        }

        protected string MaterialBarcode
        {
            get => TrackingObject.MaterialBarcode;
            set => TrackingObject.MaterialBarcode = value;
        }


        protected string SourceBarcode
        {
            get => TrackingObject.SourceBarcode;
            set => TrackingObject.SourceBarcode = value;
        }


        protected string MaterialType
        {
            get => TrackingObject.MaterialType;
            set => TrackingObject.MaterialType = value;
        }

        protected string MaterialTypeId
        {
            get => TrackingObject.MaterialTypeId;
            set => TrackingObject.MaterialTypeId = value;
        }


        protected string MaterialOwnerName
        {
            get => TrackingObject.MaterialOwnerName;
            set => TrackingObject.MaterialOwnerName = value;
        }

        protected string ParentMaterialBarcode
        {
            get => TrackingObject.ParentMaterialBarcode;
            set => TrackingObject.ParentMaterialBarcode = value;
        }


        protected DateTime MaterialRegistrationDate
        {
            get => TrackingObject.MaterialRegistrationDate;
            set => TrackingObject.MaterialRegistrationDate = value;
        }

        protected string MaterialNote
        {
            get => TrackingObject.MaterialNote;
            set => TrackingObject.MaterialNote = value;
        }

        protected string MaterialPointOfOrigin
        {
            get => TrackingObject.MaterialPointOfOrigin;
            set => TrackingObject.MaterialPointOfOrigin = value;
        }


        protected void MaterialTypeCancelled()
        {
            StateHasChanged();
        }

        protected void MaterialTypeSelected(SourceMaterialTypeLookupItem selected)
        {
            MaterialTypeSelectedItem = selected;

            MaterialType = selected?.Name;
            MaterialTypeId = selected?.Id;
            Console.WriteLine(MaterialType);
            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            MaterialTypes = await ApiLookupService.GetSourceMaterialTypesLookup(Http, SourceMaterialTypeLookupParameter.Material);
            MaterialTypeSelectedItem = MaterialTypes.FirstOrDefault(t => t.Id == MaterialTypeId) ?? new SourceMaterialTypeLookupItem();
            StateHasChanged();
        }
    }
}