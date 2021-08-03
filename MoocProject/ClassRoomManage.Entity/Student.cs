using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomManage.Entity
{
    public class Student
    {
        [Required, MaxLength(50)]
        public string Id { get; set; }
        [Required, MaxLength(150)]
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        [ForeignKey("ClassRoom")]
        public string ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }
    }
}
