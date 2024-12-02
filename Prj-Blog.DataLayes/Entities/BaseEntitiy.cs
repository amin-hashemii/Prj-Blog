using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Blog.DataLayes.Entities
{
    public class BaseEntitiy
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }=DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
