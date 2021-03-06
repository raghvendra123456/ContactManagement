using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }

        [Column(TypeName = "varchar(250)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "varchar(250)")]
        [Required]
        public string MobileNo { get; set; }

        [Column(TypeName = "varchar(250)")]
        [Required]
        public string Designation { get; set; }
        [Column(TypeName = "varchar(250)")]
        [Required]
        public string Country { get; set; }
        [Column(TypeName = "varchar(250)")]
        [Required]
        public string Gender { get; set; }        
        public string Image { get; set; }
       
    }    
}
