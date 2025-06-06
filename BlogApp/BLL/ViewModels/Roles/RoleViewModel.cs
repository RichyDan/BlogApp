﻿using System.ComponentModel.DataAnnotations;

namespace BlogApp.BLL.ViewModels.Roles
{
    public class RoleViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}
