namespace BV.PACS.WEB.Shared.Models
{
    public static class BaseSettings
    {
        public static int CollapseButtonCount { get; set; } = 10;

        public static int PageSize { get; set; } = 10;

        public static int MaxSize { get; set; } = 5000;

        public static int MaxBatchRegistrationSize { get; set; } = 200;

        public static string Language { get; set; } = "en";
    }
}