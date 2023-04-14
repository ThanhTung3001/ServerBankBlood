namespace Models.PaginationList;

public class PaginationListQuery
{
    public string Keyword { get; init; } = "";

    public int PageNumber { get; init; } = 1;

    public int PageSize { get; init; } = 20;

}


