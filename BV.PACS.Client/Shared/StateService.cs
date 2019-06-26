using System.Collections.Generic;

namespace BV.PACS.Client.Shared
{
    public class StateService
    {
        private Stack<PageState> States { get; } = new Stack<PageState>();

        public PageState CurrentPageState =>
            States.Count == 0
                ? null
                : States.Peek();
    }
}