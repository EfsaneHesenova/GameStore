﻿namespace GameStoreMVC.Models.Base
{
    public class BaseAuditableEntity: BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        
    }
}
