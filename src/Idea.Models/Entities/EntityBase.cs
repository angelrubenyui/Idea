using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Idea.Models.Entities
{

    public abstract class EntityBase
    {
       [Key]
       public Int32 id { get; set; }
       public DateTime DateCreation { get; set; }
       public DateTime DateModification { get; set; }
       public DateTime DateDelete { get; set; }
       public String EntityComments { get; set; }
    }
}
