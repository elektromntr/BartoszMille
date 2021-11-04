using System;

namespace Repository.Model
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Product(string Name, string Description)
        {
            this.Name = Name;
            this.Description = Description;
            Creation = System.DateTime.Now;
            Edit = System.DateTime.Now;
            Id = Guid.NewGuid();
        }
    }
}
