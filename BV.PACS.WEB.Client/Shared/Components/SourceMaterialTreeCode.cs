using System;
using System.Collections;
using System.Linq;
using System.Net.Http;
using BV.PACS.WEB.Client.I18nText;
using BV.PACS.WEB.Client.Services.Api;
using BV.PACS.WEB.Client.Shared.Base;
using BV.PACS.WEB.Shared.Models;
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

        [Parameter]
        public Action OnCancel { get; set; }

        [Parameter]
        public Action<SourceMaterialTypeLookupItem> OnSelect { get; set; }


        [Parameter]
        public SourceMaterialTypeLookupItem SelectedItem { get; set; } = new SourceMaterialTypeLookupItem();

        [Parameter]
        public SourceMaterialTypeLookupItem[] Data { get; set; }

        protected IEnumerable GetParentNodes()
        {
            return Data.Where(s => s.ParentId.IsNullOrEmpty());
        }

        protected IEnumerable GetNodeChildren(object dataItem)
        {
            if (dataItem is SourceMaterialTypeLookupItem lookupItem)
            {
                return Data.Where(s => s.ParentId == lookupItem.Id);
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


        protected void Cancelled()
        {
            OnCancel?.Invoke();
            InvokeAsync(StateHasChanged);
        }

        protected void Selected()
        {
            OnSelect?.Invoke(SelectedItem);
            InvokeAsync(StateHasChanged);
        }

        protected void SelectionChanged(TreeViewNodeEventArgs e)
        {
            SelectedItem = e.NodeInfo.DataItem as SourceMaterialTypeLookupItem;
        }
    }
}