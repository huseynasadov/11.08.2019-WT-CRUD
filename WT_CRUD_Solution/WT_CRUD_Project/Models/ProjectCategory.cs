using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WT_CRUD_Project.Models
{
    public class ProjectCategory
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Kateqoriya adı boş ola bilməz"), MinLength(2, ErrorMessage = "Kateqoriya adı 2-50 uzunluqda ola bilər"),MaxLength(50, ErrorMessage = "Kateqoriya adı 2-50 uzunluqda ola bilər"), Display(Name = "Ad")]
        public string Name { get; set; }
        public List<Project> Projects { get; set; }
    }
}