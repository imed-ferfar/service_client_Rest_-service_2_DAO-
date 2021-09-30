using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServeurDaos_Rest.Models
{
    [DataContract]
    public class Demande
    {
        [DataMember(Name = "host")]
        public string Host { get; set; }
        [DataMember(Name = "user")]
        public string User { get; set; }
        [DataMember(Name = "timeStamp")]
        public DateTime TimeStamp { get; set; }
        [DataMember(Name = "time")]
        public string Time { get; set; }
        [DataMember(Name = "year")]
        public int Year { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }


    }
}