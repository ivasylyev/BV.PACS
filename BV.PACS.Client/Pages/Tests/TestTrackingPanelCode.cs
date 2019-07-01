using System;
using System.Linq;
using BV.PACS.Client.Shared.Base;
using BV.PACS.Shared.Models;

namespace BV.PACS.Client.Tests
{
    public class TestTrackingPanelCode : TrackingPanel<TestTrackingDto>
    {
        protected TemplateLookupItem Template
        {
            get { return Templates.FirstOrDefault(t => t.Id == TrackingObject.TestTemplateId); }
            set
            {
                TrackingObject.TestTemplateId = value.Id;
                TrackingObject.TestTemplateName = value.Name;
            }
        }

        protected string TestBarcode
        {
            get => TrackingObject.TestBarcode;
            set => TrackingObject.TestBarcode = value;
        }

        protected DateTime TestRegistrationDate
        {
            get => TrackingObject.TestRegistrationDate;
            set => TrackingObject.TestRegistrationDate = value;
        }

        protected DateTime TestDate
        {
            get => TrackingObject.TestDate;
            set => TrackingObject.TestDate = value;
        }

        protected string TestType
        {
            get => TrackingObject.TestType;
            set => TrackingObject.TestType = value;
        }

        protected string TestResult
        {
            get => TrackingObject.TestResult;
            set => TrackingObject.TestResult = value;
        }

        protected string TestStatus
        {
            get => TrackingObject.TestStatus;
            set => TrackingObject.TestStatus = value;
        }

        protected string TestNote
        {
            get => TrackingObject.TestNote;
            set => TrackingObject.TestNote = value;
        }

        protected string SourceBarcode
        {
            get => TrackingObject.SourceBarcode;
            set => TrackingObject.SourceBarcode = value;
        }

        protected string MaterialBarcode
        {
            get => TrackingObject.MaterialBarcode;
            set => TrackingObject.MaterialBarcode = value;
        }

        protected string AliquotBarcode
        {
            get => TrackingObject.AliquotBarcode;
            set => TrackingObject.AliquotBarcode = value;
        }
    }
}