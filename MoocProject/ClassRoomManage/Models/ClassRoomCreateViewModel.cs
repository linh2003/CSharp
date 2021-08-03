using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRoomManage.Models
{
    public class ClassRoomCreateViewModel
    {
        [Required(ErrorMessage = "ID ClassRoom is required"), MaxLength(50)]
        public string Id { get; set; }
        [Required(ErrorMessage = "Name ClassRoom is required"), MaxLength(200)]
        public string NameClassRoom { get; set; }
        public string DescribeClassRoom { get; set; }
    }
}
