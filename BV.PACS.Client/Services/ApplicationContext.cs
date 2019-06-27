namespace BV.PACS.Client.Services
{
    public class ApplicationContext
    {
        public BasePageContext PageContext { get; set; }
        public string PageName { get; set; }

        public ApplicationContext(string pageName, BasePageContext pageContext)
        {
            PageName = pageName;
            PageContext = pageContext;
        }
    }
}