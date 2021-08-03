using ClassRoomManage.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRoomManage.Models
{
    public class StudentCreateViewModel
    {
        [Required(ErrorMessage = "ID Student is required"), MaxLength(50)]
        public string Id { get; set; }
        [Required(ErrorMessage = "ID Student is required"), MaxLength(150)]
        public string Name { get; set; }
        [DataType(DataType.Date), Display(Name = "Date Of Birth")]
        public DateTime Birthday { get; set; }
        public string ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }
    }
}
