using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomManage.Entity
{
    public class ClassRoom
    {
        [Required, MaxLength(50)]
        public string Id { get; set; }
        [Required, MaxLength(200)]
        public string NameClassRoom { get; set; }
        public string DescribeClassRoom { get; set; }
    }
}
