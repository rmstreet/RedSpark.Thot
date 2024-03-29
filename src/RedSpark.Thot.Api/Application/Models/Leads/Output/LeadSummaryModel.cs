﻿using System;

namespace RedSpark.Thot.Api.Application.Models.Lead.Output
{
    public class LeadSummaryModel 
    {        
        public int Id { get; set; }
        public string Title { get; set; }
        public string CreatedBy { get; set; }
        public string Status { get; set; }
        public bool IsFollowing { get; set; }
        public int FollowerAmount { get; set; }
        public int ComentAmount { get; set; }
        public DateTime UpdateDate { get; set; }       
    }
}
