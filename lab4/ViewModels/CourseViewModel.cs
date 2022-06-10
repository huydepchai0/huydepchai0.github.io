using lab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab4.ViewModels
{
    public class CourseViewModel
    {
        [Required]
        public string Place { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public byte Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public DateTime GetDatatime()
        {
            return DateTime.Parse(string.Format("{0}{1}", Date, Time));
        }
    }
}
