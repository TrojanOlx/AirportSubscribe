using System;

namespace AirportSubscribe.Models.UrlModels.Dto
{
    public class UrlModelOutDto
    {
        public int Id { get; set; }
        public string UrlName { get; set; }
        public string UrlString { get; set; }
        public UrlTypeEnum UrlType { get; set; }
        public string IconUrl { get; set; }
        /// <summary>
        /// 速率
        /// </summary>
        public decimal Speed { get; set; }
        public DateTimeOffset CreateTime { get; set; }
        public string CreateUser { get; set; }
        public DateTimeOffset LastUpdateTime { get; set; }
        public string LastUpdateUser { get; set; }
        
    }
}
