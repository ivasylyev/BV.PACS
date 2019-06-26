using System;
using BV.PACS.Shared.Models;
namespace BV.PACS.Client.Shared
{
    public static class CatalogDtoFactory
    {
        public static T CreateEmptyItem<T>(string defValue) where T : new()
        {
            var result = new T();
            if (result is SourceCatalogDto s)
            {
                s.SourceCreationDate = DateTime.Now;
                s.SourceTypeId = defValue;
                s.SourceType = defValue;
                s.SourcePointOfOrigin = defValue;
                s.SourceTemplateName = defValue;
                s.MaterialsAndAliquotsCount = defValue;
                s.SourceNote = defValue;
                s.SourceTemplateId = defValue;
                s.SourceLockingStatusId = defValue;
                s.SourceBarcode = defValue;
                s.MaterialTypes = defValue;
                s.MaterialBarcodes = defValue;
                s.SourceGeoLocationId = defValue;
                s.AliquotBarcodes = defValue;
                s.TestDates = defValue;
                s.TestTypes = defValue;
                s.TestResults = defValue;
                s.TestStatuses = defValue;
            }
            else if (result is MaterialCatalogDto m)
            {
                m.MaterialRegistrationDate = DateTime.Now;
                m.MaterialTypeId = defValue;
                m.MaterialType = defValue;
                m.MaterialLockingStatusId = defValue;
                m.MaterialBarcode = defValue;
                m.SourceName = defValue;
                m.MaterialTemplateName = defValue;
                m.MaterialNote = defValue;
                m.MaterialTemplateId = defValue;
                m.AliquotsCount = defValue;
                m.SourceBarcode = defValue;
                m.MaterialOwnerName = defValue;
                m.Aliquots = defValue;
                m.MaterialPointOfOrigin = defValue;
            }
            else if (result is AliquotCatalogDto a)
            {
                a.AliquotCreationDate = DateTime.Now;
                a.AliquotBarcode = defValue;
                a.MaterialType = defValue;
                a.FreezerSubdivisionBarcode = defValue;
                a.MaterialBarcode = defValue;
                a.AliquotStatusId = defValue;
                a.MaterialId = defValue;
                a.AliquotLockingStatusId = defValue;
                a.VolumeString = defValue;
                a.WeightString = defValue;
                a.SourceBarcode = defValue;
                a.AliquotNote = defValue;
                a.SpotPosition = defValue;
                a.DerivativeType = defValue;
                a.AliquotTemplateName = defValue;
                a.LocationPath = defValue;
                a.AliquotTemplateId = defValue;
                a.AliquotStatus = defValue;
            }

            if (result is TestCatalogDto t)
            {
                t.TestDate = DateTime.Now;
                t.TestTypeId = defValue;

                t.TestResultId = defValue;
                t.TestRegistrationDate = DateTime.Now;
                t.TestStatusId = defValue;
                t.AliquotId = defValue;
                t.AliquotBarcode = defValue;
                t.MaterialTypeId = defValue;
                t.MaterialBarcode = defValue;
                t.SourceBarcode = defValue;
                t.TestTemplateId = defValue;
                t.SourceType = defValue;
                t.MaterialType = defValue;
                t.TestType = defValue;
                t.TestResult = defValue;
                t.TestStatus = defValue;
                t.TestTemplateName = defValue;
                t.LocationPath = defValue;

                t.TestLockingStatusId = defValue;
                t.TestBarcode = defValue;
            }

            return result;
        }
    }
}