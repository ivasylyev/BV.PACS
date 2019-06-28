namespace BV.PACS.Client.Services
{
    public class ApplicationContext
    {
        public IPageContext PageContext { get; set; }
        public string PageName { get; set; }

        public ApplicationContext(string pageName)
        {
            PageName = pageName;
        }
        public ApplicationContext(string pageName, IPageContext pageContext)
        {
            PageName = pageName;
            PageContext = pageContext;
        }
    }
}