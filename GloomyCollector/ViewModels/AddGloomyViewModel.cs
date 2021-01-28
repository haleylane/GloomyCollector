using System;
using System.ComponentModel.DataAnnotations;

namespace GloomyCollector.ViewModels
{
    namespace GloomyCollector.ViewModels
    {
        public class AddGloomyViewModel
        {
            public string SerialNumber { get; set; }

            [Required(ErrorMessage = "Name is required.")]
            public string Name { get; set; }

            public string Year { get; set; }

            public string ImageData { get; set; }
        }
    }
}