﻿using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GigHub.Repositories
{
    public class GigRepository : IGigRepository
    {
        private readonly ApplicationDbContext _context;
        public GigRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Gig> GetGigsUserAttending(string userId)
        {
            return _context.Attendances
                    .Where(a => a.AttendeeId == userId)
                    .Select(a => a.Gig)
                    .Include(g => g.Artist)
                    .Include(g => g.Genre)
                    .ToList();
        }

        public Gig GetGig(int id)
        {
            return _context.Gigs
                    .Include(g => g.Artist)
                    .Include(g => g.Genre)
                    .SingleOrDefault(g => g.Id == id);
        }

        public IEnumerable<Gig> GetUpcomingGigsByArtist(string artistId)
        {
            return _context.Gigs
                    .Where(g => g.ArtistId == artistId && g.DateTime > DateTime.Now && !g.IsCanceled)
                    .Include(g => g.Genre)
                    .ToList();
        }

        public IEnumerable<Gig> GetUpcomingGigs()
        {
            return _context.Gigs
                    .Where(g => g.DateTime > DateTime.Now && !g.IsCanceled)
                    .Include(g => g.Genre)
                    .Include(g => g.Artist)
                    .ToList();
        }

        public Gig GetGigWithAttendees(int gigId)
        {
            return _context.Gigs
                    .Include(g => g.Attendances.Select(a => a.Attendee))
                    .SingleOrDefault(g => g.Id == gigId);
        }

        public Gig GetGigWithArtistAndGenre(int id)
        {
            return _context.Gigs
                    .Include(g => g.Artist)
                    .Include(g => g.Genre)
                    .SingleOrDefault(g => g.Id == id);
        }

        public void Add(Gig gig)
        {
            _context.Gigs.Add(gig);
        }
    }
}