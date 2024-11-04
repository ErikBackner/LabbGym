using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabbGym
{
    public class Pass
    {
        public string Workout { get; set; }
        public DateTime Time { get; set; }
        public int MaxParticipants { get; set; }
        public int CurrentParticipants { get; set; }

        public bool IsFull => CurrentParticipants >= MaxParticipants;

        public Pass(string workout, DateTime time, int maxParticipants)
        {
            Workout = workout;
            Time = time;
            MaxParticipants = maxParticipants;
            CurrentParticipants = 0;
        }

        public bool BookPass()
        {
            if (!IsFull)
            {
                CurrentParticipants++;
                return true;
            }
            return false;
        }

        public bool CancelBooking()
        {
            if (CurrentParticipants > 0)
            {
                CurrentParticipants--;
                return true;
            }
            return false;
        }
    }
}
