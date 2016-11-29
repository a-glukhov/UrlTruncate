using System;

namespace UrlTruncate.WebApi.Models
{
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    public class InputModel
    {
        [Required]
        [DataType(DataType.Url)]
        [Url]
        public String Url { get; set; }
    }
}