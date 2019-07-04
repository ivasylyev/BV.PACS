using System;
using System.Linq;
using System.Threading.Tasks;
using BV.PACS.Client.Shared.Base;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Models.Parameters;

namespace BV.PACS.Client.Materials
{
    public class MaterialTrackingPanelCode : TrackingPanel<MaterialTrackingDto>
    {
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

        protected string SourceType
        {
            get => "Not implemented";
            set { }
        }


        protected string MaterialType
        {
            get => TrackingObject.MaterialType;
            set => TrackingObject.MaterialType = value;
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

        public override bool Post()
        {
            ApiTrackingService.PostData(Http, new TrackingPostParameter<MaterialTrackingDto>(TrackingObject, BaseSettings.Language))
                .ContinueWith(x => StateHasChanged());
            return true;
        }
    }
}