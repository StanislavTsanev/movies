namespace Movies.API.Models.BindingModels
{
    public class BaseQueryBindingModel
    {
        public string Include { get; set; }

        public int? Take { get; set; }

        public int? Skip { get; set; }
    }
}
