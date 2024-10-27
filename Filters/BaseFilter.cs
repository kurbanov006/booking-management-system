public record BaseFilter
{
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
    public BaseFilter()
    {
        this.PageNumber = 1;
        this.PageSize = 10;
    }
    public BaseFilter(int pageNumber, int pageSize)
    {
        this.PageNumber = pageNumber <= 0 ? 1 : pageNumber;
        this.PageSize = pageSize <= 0 ? 10 : pageSize;
    }
}