﻿namespace BLL.ViewModels.Category
{
    public class CategoryUpdateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageBase64 { get; set; }
        public int Priority { get; set; }
        public string Description { get; set; }
    }
}
