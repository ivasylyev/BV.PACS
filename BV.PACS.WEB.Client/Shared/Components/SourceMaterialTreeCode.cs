using System.Collections;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BV.PACS.WEB.Client.I18nText;
using BV.PACS.WEB.Client.Services.Api;
using BV.PACS.WEB.Client.Shared.Base;
using BV.PACS.WEB.Shared.Models;
using BV.PACS.WEB.Shared.Models.Parameters;
using BV.PACS.WEB.Shared.Utils;
using DevExpress.Blazor;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.WEB.Client.Shared.Components
{
    public class SourceMaterialTreeCode : TranslatablePanel<Text>
    {
        [Inject]
        protected LookupService ApiService { get; set; }

        [Inject]
        protected HttpClient Http { get; set; }

        public SourceMaterialTypeLookupItem SelectedItem { get; set; } = new SourceMaterialTypeLookupItem();
        public SourceMaterialTypeLookupItem[] SourceTypes { get; set; }

        protected IEnumerable GetParentNodes()
        {
            return SourceTypes.Where(s => s.ParentId.IsNullOrEmpty());
        }

        protected IEnumerable GetNodeChildren(object dataItem)
        {
            if (dataItem is SourceMaterialTypeLookupItem lookupItem)
            {
                return SourceTypes.Where(s => s.ParentId == lookupItem.Id);
            }

            return null;
        }

        protected string GetNodeText(object dataItem)
        {
            if (dataItem is SourceMaterialTypeLookupItem lookupItem)
            {
                return lookupItem.Name;
            }

            return "";
        }


        protected void SourceTypeCancelled()
        {
            StateHasChanged();
        }

        protected void SourceTypeSelected()
        {
            StateHasChanged();
        }

        protected void SelectionChanged(TreeViewNodeEventArgs e)
        {
            SelectedItem = e.NodeInfo.DataItem as SourceMaterialTypeLookupItem;
            //    InvokeAsync(StateHasChanged);
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            SourceTypes = await ApiService.GetSourceMaterialTypesLookup(Http, SourceMaterialTypeLookupParameter.Source);
        }
    }
}