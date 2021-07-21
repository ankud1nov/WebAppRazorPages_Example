using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Diary
    {
        public int ID { get; set; }
        [ForeignKey("DairyType")]
        public int DiaryTypeId { get; set; }
        public string Subject { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateTimeBegin { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateTimeEnd { get; set; }
        public string Place { get; set; }
    }    
}
