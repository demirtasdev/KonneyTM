﻿using KonneyTM.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KonneyTM.Models
{
    public class PersonViewModel
    {   
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number cannot be empty.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone number must be 11 characters long. (Ex. 07956852154)")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone number. (Ex. 07956852154)")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email address cannot be empty.")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        public void SaveAsPerson()
        {
            var db = new KonneyContext();

            var person = new Person
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                PhoneNumber = this.PhoneNumber,
                Email = this.Email
            };

            db.People.Add(person);
            db.SaveChanges();
        }

        public void SubmitChanges()
        {
            var db = new KonneyContext();

            var person = db.People.First(p => p.ID == this.ID);

            person.FirstName = this.FirstName;
            person.LastName = this.LastName;
            person.Email = this.Email;
            person.PhoneNumber = this.PhoneNumber;

            db.SaveChanges();
        }
        
        public static PersonViewModel ConvertPerson(Person person)
        {
            var personVM = new PersonViewModel
            {
                ID = person.ID,
                FirstName = person.FirstName,
                LastName = person.LastName,
                PhoneNumber = person.PhoneNumber,
                Email = person.Email
            };

            return personVM;
        }
    }
}