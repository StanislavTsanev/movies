using System;

namespace Movies.Domain.Entities
{
    public class BaseEntity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
