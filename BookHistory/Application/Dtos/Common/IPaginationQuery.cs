namespace BookHistory.Application.Dtos.Common
{
    public interface IPaginationQuery
    {
        public int Page { get; init; }
        public int PageSize { get; init; }
    }
}
