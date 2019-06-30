using System.Collections.Generic;
using BV.PACS.Client.Shared;

namespace BV.PACS.Client.Services.Context
{
    public class ApplicationContextService
    {
        public readonly LinkedList<ApplicationContext> _contexts = new LinkedList<ApplicationContext>();

        public ApplicationContext CurrentApplicationContext =>
            _contexts.Count == 0
                ? null
                : _contexts.Last.Value;

        public void Clear()
        {
            _contexts.Clear();
        }

        public void OpenTrackingPage(string pageName, int id)
        {
            ApplicationContext context = new ApplicationContext(pageName, new TrackingFormContext(id));
            _contexts.AddLast(context);
        }
        public void OpenNewCatalogPage(string pageName)
        {
            ApplicationContext context = new ApplicationContext(pageName);
            _contexts.AddLast(context);
        }
        public void OpenLastOrNewCatalogPage(string pageName)
        {
            ApplicationContext context = null;
            if (_contexts.Count > 0)
            {
                var last = _contexts.Last;
                while (last != null && last.Value.PageName != pageName)
                {
                    last = last.Previous;
                }

                if (last !=null && last.Value.PageName == pageName)
                {
                    context = last.Value;
                    _contexts.Remove(context);
                    _contexts.AddLast(context);
                }
            }

            if (context == null)
            {
                context = new ApplicationContext(pageName);
                _contexts.AddLast(context);
            }
        }
        public void ClosePage(DialogResult result)
        {
            if (_contexts.Count != 0)
            {
                _contexts.RemoveLast();
            }
        }
    }
}