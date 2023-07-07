namespace StateNumberManagement.Domain
{
    public class SearchParameters
    {
        public OrderBy SortOrder { get; set; }
        public string? SearchString { get; set; }
        public int PageIndex { get; set; }

        public enum OrderBy
        {
            AphabeticalByNumber,
            DateAcending,
            DateDescending
        }
    }
}
