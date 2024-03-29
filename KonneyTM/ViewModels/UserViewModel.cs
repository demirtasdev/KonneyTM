﻿using KonneyTM.DAL;
using KonneyTM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonneyTM.ViewModels
{
    public class UserViewModel
    {
        public string ID { get; set; }
        public List<PersonViewModel> People { get; set; }
        public List<VenueViewModel> Venues { get; set; }
        public List<EventViewModel> Events { get; set; }

        public void Fill(KonneyContext db, string userID)
        {
            this.ID = userID;
            this.Events = Event.GetAllAsViewModelList(db, userID);
            this.People = Person.GetAllAsViewModelList(db, userID);
            this.Venues = Venue.GetAllAsViewModelList(db, userID);
        }
    }
}