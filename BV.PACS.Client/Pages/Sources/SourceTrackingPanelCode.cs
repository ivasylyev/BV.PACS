using System;
using System.Linq;
using System.Threading.Tasks;
using BV.PACS.Client.Shared.Base;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Models.Parameters;

namespace BV.PACS.Client.Sources
{
    // ReSharper disable once InconsistentNaming
    public class SourceTrackingPanelCode : TrackingPanel<SourceTrackingDto, BV.PACS.Client.I18nText.Text>
    {
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

       
    }
}