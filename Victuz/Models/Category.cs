﻿namespace Victuz.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Activity>? Activities { get; set; }
    }
}
