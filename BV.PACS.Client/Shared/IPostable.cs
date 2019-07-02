namespace BV.PACS.Client.Shared
{
    public interface IPostable
    {
        bool HasChanges { get; }
        bool Post();

    }
}