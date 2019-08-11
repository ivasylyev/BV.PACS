using System;
using System.Linq;
using System.Threading.Tasks;
using BV.PACS.WEB.Client.I18nText;
using BV.PACS.WEB.Client.Shared.Base;
using BV.PACS.WEB.Shared.Models;

namespace BV.PACS.WEB.Client.Aliquots
{
    public class AliquotTrackingPanelCode : TrackingPanel<AliquotTrackingDto, Text>
    {
        protected TemplateLookupItem Template
        {
            get { return Templates.FirstOrDefault(t => t.Id == TrackingObject.AliquotTemplateId); }
            set
            {
                TrackingObject.AliquotTemplateId = value.Id;
                TrackingObject.AliquotTemplateName = value.Name;
            }
        }

        protected override async Task GetLookups()
        {
            await GetLookups(FormTypes.Aliquot);
        }

        protected string AliquotBarcode
        {
            get => TrackingObject.AliquotBarcode;
            set => TrackingObject.AliquotBarcode = value;
        }


        protected string MaterialType
        {
            get => TrackingObject.MaterialType;
            set => TrackingObject.MaterialType = value;
        }


        protected int? Passage
        {
            get => TrackingObject.Passage;
            set => TrackingObject.Passage = value;
        }

        protected DateTime AliquotCreationDate
        {
            get => TrackingObject.AliquotCreationDate;
            set => TrackingObject.AliquotCreationDate = value;
        }


        protected string MaterialBarcode
        {
            get => TrackingObject.MaterialBarcode;
            set => TrackingObject.MaterialBarcode = value;
        }

        protected string AliquotParentBarcode
        {
            get => TrackingObject.AliquotParentBarcode;
            set => TrackingObject.AliquotParentBarcode = value;
        }

        protected string AliquotStatus
        {
            get => TrackingObject.AliquotStatus;
            set => TrackingObject.AliquotStatus = value;
        }

        protected string AliquotNote
        {
            get => TrackingObject.AliquotNote;
            set => TrackingObject.AliquotNote = value;
        }

        protected decimal Volume
        {
            get => TrackingObject.Volume;
            set => TrackingObject.Volume = value;
        }

        protected string VolumeUnitName
        {
            get => TrackingObject.VolumeUnitName;
            set => TrackingObject.VolumeUnitName = value;
        }

        protected decimal Weight
        {
            get => TrackingObject.Weight;
            set => TrackingObject.Weight = value;
        }

        protected string WeightUnitName
        {
            get => TrackingObject.WeightUnitName;
            set => TrackingObject.WeightUnitName = value;
        }

        protected string LocationPath
        {
            get => TrackingObject.LocationPath;
            set => TrackingObject.LocationPath = value;
        }

        protected string DerivativeType
        {
            get => TrackingObject.DerivativeType;
            set => TrackingObject.DerivativeType = value;
        }
    }
}