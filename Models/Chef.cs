using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId {get;set;}

        [Required (ErrorMessage="Please enter your name")]
        [Display(Name="First Name:")]
        public string ChefFirstName {get;set;}

        [Required (ErrorMessage="Please enter your name")]
        [Display(Name="Last Name:")]
        public string ChefLastName {get;set;}
        [Required (ErrorMessage="Please enter your Age")]
        [Range (18,200, ErrorMessage="You must be 18 years or older")]
        public int Age {get;set;}
        public List<Dish> CreatedDishes { get; set; }

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}