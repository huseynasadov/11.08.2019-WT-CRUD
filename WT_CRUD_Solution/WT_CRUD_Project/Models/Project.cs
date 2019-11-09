using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WT_CRUD_Project.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Kategoriya boş qoyula bilməz"),Display(Name="Kateqoriya")]
        public int ProjectCategoryId { get; set; }
        [Required(ErrorMessage ="Proyekt adı boş ola bilməz"),MinLength(2,ErrorMessage ="Proyekt adı 2-50 uzunluqda ola bilər"),MaxLength(50, ErrorMessage = "Proyekt adı 3-50 uzunluqda ola bilər"),Display(Name ="Ad")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Proyekin yaranma vaxtı boş ola bilməz"), Column(TypeName ="date"), Display(Name = "Yaranma vaxtı")]
        public DateTime PublishDate { get; set; }
        [Required(ErrorMessage = "Proyek haqqında məlumat boş ola bilməz"), Column(TypeName = "ntext"), Display(Name = "Məlumat")]
        public string Desc { get; set; }
        public ProjectCategory ProjectCategory { get; set; }
    }
}