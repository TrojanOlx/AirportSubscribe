using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AirportSubscribe.Models
{
    public class UrlModel
    {
        [Key]
        public int Id { get; set; }
        public string UrlName { get; set; }
        public string UrlString { get; set; }
        public UrlTypeEnum UrlType { get; set; }
    }
    public enum UrlTypeEnum
    {
        SSR = 1,
        V2ray = 2
    }
}
