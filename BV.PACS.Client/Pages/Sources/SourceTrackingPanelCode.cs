using System;
using System.Linq;
using BV.PACS.Client.Shared.Base;
using BV.PACS.Shared.Models;

namespace BV.PACS.Client.Sources
{
    // ReSharper disable once InconsistentNaming
    public class SourceTrackingPanelCode : TrackingPanel<SourceTrackingDto>
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