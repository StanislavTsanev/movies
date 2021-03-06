namespace Movies.Application.Common.Models.Mediatr
{
    public class BaseQuery<T> : BaseRequest<T>, IBaseQuery
    {
        public string Include { get;  set; }

        public int? Skip { get; }

        public int? Take { get; }
    }
}
