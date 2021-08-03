using ClassRoomManage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRoomManage.Models
{
    public class StudentIndexViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }
    }
}
