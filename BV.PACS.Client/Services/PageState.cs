namespace BV.PACS.Client.Services
{
    public class PageState
    {
        public int Context { get; set; }
        public string PageName { get; set; }

        public PageState(string pageName, int context)
        {
            PageName = pageName;
            Context = context;
        }
    }
}