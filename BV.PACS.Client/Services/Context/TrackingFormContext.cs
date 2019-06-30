namespace BV.PACS.Client.Services.Context
{
    public class TrackingFormContext: IPageContext
    {
        public int Id { get; set; }

        public TrackingFormContext(int id)
        {
            Id = id;
        }
    }
}