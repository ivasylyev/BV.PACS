using System.Collections.Generic;
using BV.PACS.WEB.Client.Shared;

namespace BV.PACS.WEB.Client.Services.Context
{
    public class ApplicationContextService
    {
        public LinkedList<ApplicationContext> Contexts { get; } = new LinkedList<ApplicationContext>();

        public ApplicationContext CurrentApplicationContext =>
            Contexts.Count == 0
                ? null
                : Contexts.Last.Value;

        public void Clear()
        {
            Contexts.Clear();
        }

        public void OpenBatchRegistrationPage(string pageName)
        {
            ApplicationContext context = new ApplicationContext(pageName, new BatchRegistrationContext());
            Contexts.AddLast(context);
        }
        public void OpenTrackingPage(string pageName, int id)
        {
            ApplicationContext context = new ApplicationContext(pageName, new TrackingFormContext(id));
            Contexts.AddLast(context);
        }
        public void OpenNewCatalogPage(string pageName)
        {
            ApplicationContext context = new ApplicationContext(pageName);
            Contexts.AddLast(context);
        }
        public void OpenLastOrNewCatalogPage(string pageName)
        {
            ApplicationContext context = null;
            if (Contexts.Count > 0)
            {
                var last = Contexts.Last;
                while (last != null && last.Value.PageName != pageName)
                {
                    last = last.Previous;
                }

                if (last !=null && last.Value.PageName == pageName)
                {
                    context = last.Value;
                    Contexts.Remove(context);
                    Contexts.AddLast(context);
                }
            }

            if (context == null)
            {
                context = new ApplicationContext(pageName);
                Contexts.AddLast(context);
            }
        }
        public void ClosePage(DialogResult result)
        {
            if (Contexts.Count != 0)
            {
                Contexts.RemoveLast();
            }
        }
    }
}