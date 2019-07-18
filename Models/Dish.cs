using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Models
{
        public class Dish
    {
        [Key]
        public int DishId {get;set;}
        public int ChefId {get;set;}
        
        [Required (ErrorMessage="Please enter a name for your dish.")]
        [Display(Name="Dish:")]
        public string NameDish {get;set;}

        [Required (ErrorMessage="Please enter your name")]
        [Display(Name="Chef's Name:")]
        [MinLength(3)]
        public string Chef {get;set;}

        [Required]
        [Range(1,5)]
        [Display(Name="Tastiness:")]
        public int Tastiness {get;set;}

        [Required]
        [Range(1,10000,ErrorMessage=("Must be more than 0 calories"))]
        [Display(Name="Calories:")]
        public int Calories {get;set;}

        [MinLength(10, ErrorMessage="Minimum 10 characters")]
        [MaxLength(200, ErrorMessage="Maximum 200 characters")]
        [Display(Name="Description:")]
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
    
}