namespace Application.Common;

public class PaginationModelBase
{
    public int CurrentPage { get; set; }
    public int PageCount { get; set; }
    public int PageSize { get; set; }
    public int RowCount { get; set; }

    public int FirstRowOnPage
    {

        get { return (CurrentPage - 1) * PageSize + 1; }
    }

    public int LastRowOnPage
    {
        get { return Math.Min(CurrentPage * PageSize, RowCount); }
    }
}

public class PaginationModel<T> : PaginationModelBase where T : class
{
    public IList<T> Results { get; set; }

    public PaginationModel()
    {
        Results = new List<T>();
    }
}