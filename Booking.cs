using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabbGym
{
    public class Booking
    {
        public List<Pass> PassLista { get; private set; }

        public Booking()
        {
            PassLista = new List<Pass>();
        }

        public void AddPass(Pass pass)
        {
            PassLista.Add(pass);
        }

        public bool Book(string workout, DateTime time)
        {
            Pass pass = PassLista.FirstOrDefault(p => p.Workout == workout && p.Time == time);
            return pass?.BookPass() ?? false;
        }

        public bool Unbook(string workout, DateTime time)
        {
            Pass pass = PassLista.FirstOrDefault(p => p.Workout == workout && p.Time == time);
            return pass?.CancelBooking() ?? false;
        }
    }
}
