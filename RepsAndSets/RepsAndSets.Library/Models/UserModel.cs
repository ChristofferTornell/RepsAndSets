using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepsAndSets.Library.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public List<WorkoutModel> Workouts = new List<WorkoutModel>();
    }
}
