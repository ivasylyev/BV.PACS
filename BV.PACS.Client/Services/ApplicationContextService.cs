using System.Collections.Generic;
using BV.PACS.Client.Shared;

namespace BV.PACS.Client.Services
{
    public class ApplicationContextService
    {
        public readonly Stack<ApplicationContext> _contexts = new Stack<ApplicationContext>();

        public ApplicationContext CurrentApplicationContext =>
            _contexts.Count == 0
                ? null
                : _contexts.Peek();

        public void Clear()
        {
            _contexts.Clear();
        }

        public void OpenTrackingPage(string pageName, int id)
        {
            ApplicationContext state = new ApplicationContext(pageName, new TrackingFormContext(id));
            _contexts.Push(state);
        }
        public void OpenCatalogPage(string pageName)
        {
            ApplicationContext state = new ApplicationContext(pageName);
            _contexts.Push(state);
        }
        public void ClosePage(DialogResult result)
        {
            if (_contexts.Count != 0)
            {
                _contexts.Pop();
            }
        }
    }
}