using System;
using System.Collections.Generic;

namespace RedSpark.Thot.Api.Application.Models.Leads.Output
{
    public class ComentModel
    {
        public string CreatedBy { get; set; }
        public string Job { get; set; }
        public DateTime CreateDate { get; set; }
        public List<ComentModel> Answers { get; set; }
    }
}
