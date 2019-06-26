using System.Collections.Generic;
using BV.PACS.Client.Shared;

namespace BV.PACS.Client.Services
{
    public class StateService
    {
        public readonly Stack<PageState> _states = new Stack<PageState>();

        public PageState CurrentPageState =>
            _states.Count == 0
                ? null
                : _states.Peek();

        public void OpenNewPage(string pageName, int context)
        {
            PageState state = new PageState(pageName, context);
            _states.Push(state);
        }
        public void ClosePage(DialogResult result)
        {
            if (_states.Count != 0)
            {
                _states.Pop();
            }
        }
    }
}