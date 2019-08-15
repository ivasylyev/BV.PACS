namespace BV.PACS.WEB.Shared.Models
{
    public static class BaseSettings
    {
        public const int MaxBatchRegistrationSize = 200;

        public const int MaxSize  = 5000;

        public static int CollapseButtonCount { get; set; } = 10;

        public static int PageSize { get; set; } = 10;

        public static string Language { get; set; } = "en";
    }
}