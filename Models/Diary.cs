using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Diary
    {
        public int ID { get; set; }
        public DiaryType DiaryType { get; set; }
        [Required]
        public string Subject { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateTimeBegin { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateTimeEnd { get; set; }
        public string Place { get; set; }
    }
}
