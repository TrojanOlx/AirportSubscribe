using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AirportSubscribe.Models.UrlModels
{
    public class UrlModel
    {
        [Key]
        public int Id { get; set; }
        public string UrlName { get; set; }
        public string UrlString { get; set; }
        public UrlTypeEnum UrlType { get; set; }
        public DateTimeOffset CreateTime { get; set; }
        public string CreateUser { get; set; }
        public DateTimeOffset LastUpdateTime { get; set; }
        public string LastUpdateUser { get; set; }
    }
}
