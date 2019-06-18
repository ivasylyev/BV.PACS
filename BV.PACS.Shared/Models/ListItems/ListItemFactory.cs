using System;

namespace BV.PACS.Shared.Models
{
    public static class ListItemFactory
    {
        public static T CreateEmptyItem<T>(string defValue) where T : new()
        {
            var result = new T();
            if (result is SourceListItem item)
            {
                item.SourceCreationDate = DateTime.Now;
                item.SourceTypeId = defValue;
                item.SourceType = defValue;
                item.SourcePointOfOrigin = defValue;
                item.SourceTemplateName = defValue;
                item.MaterialsAndAliquotsCount = defValue;
                item.SourceNote = defValue;
                item.SourceTemplateId = defValue;
                item.SourceLockingStatusId = defValue;
                item.SourceBarcode = defValue;
                item.MaterialTypes = defValue;
                item.MaterialBarcodes = defValue;
                item.SourceGeoLocationId = defValue;
                item.AliquotBarcodes = defValue;
                item.TestDates = defValue;
                item.TestTypes = defValue;
                item.TestResults = defValue;
                item.TestStatuses = defValue;
            }


            return result;
        }
    }
}