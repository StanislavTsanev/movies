namespace Movies.Application.Common.Models.Mediatr
{
    public interface IBaseQuery
    {
        string Include { get; set; }

        int? Skip { get; }

        int? Take { get; }
    }
}
