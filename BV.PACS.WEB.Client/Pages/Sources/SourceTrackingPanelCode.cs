using System;
using System.Linq;
using System.Threading.Tasks;
using BV.PACS.WEB.Client.I18nText;
using BV.PACS.WEB.Client.Shared.Base;
using BV.PACS.WEB.Shared.Models;

namespace BV.PACS.WEB.Client.Sources
{
    // ReSharper disable once InconsistentNaming
    public class SourceTrackingPanelCode : TrackingPanel<SourceTrackingDto, SourceTrackingPanel>
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