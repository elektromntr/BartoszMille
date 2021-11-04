using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime Creation { get; set; }
        public DateTime Edit { get; set; }
    }
}
