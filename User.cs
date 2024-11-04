using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabbGym
{
    public class User
    {
        public string Name { get; set; }
        public List<Pass> BookedPasses { get; private set; }  

        public User(string name)
        {
            Name = name;
            BookedPasses = new List<Pass>();
        }

        public bool BookPass(Booking booking, Pass pass)
        {
            if (BookedPasses.Contains(pass))
            {
                return false; 
            }

            if (booking.Book(pass.Workout, pass.Time))
            {
                BookedPasses.Add(pass); 
                return true; 
            }
            return false;
        }

        public bool UnbookPass(Booking booking, Pass pass)
        {
            if (BookedPasses.Remove(pass)) 
            {
                return booking.Unbook(pass.Workout, pass.Time);
            }
            return false;
        }
    }
}
