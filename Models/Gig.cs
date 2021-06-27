using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GigHub.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public bool IsCanceled { get; private set; }

        public ApplicationUser Artist { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public ICollection<Attendance> Attendances { get; private set; }

        public Gig()
        {
            Attendances = new Collection<Attendance>();
        }

        public void Modify(DateTime dateTime, string venue, Byte genre)
        {
            var notification = new Notification(this, NotificationType.GigUpdated);

            Venue = venue;
            GenreId = genre;
            DateTime = dateTime;
        }

        public void Cancel()
        {
            IsCanceled = !IsCanceled;

            var notification = new Notification(this, NotificationType.GigCanceled);

            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }



        }
    }
}