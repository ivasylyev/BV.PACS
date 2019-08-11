namespace BV.PACS.WEB.Client.Shared
{
    public interface IPostable
    {
        bool HasChanges { get; }
        bool Post();
    }
}