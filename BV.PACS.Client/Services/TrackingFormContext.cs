﻿namespace BV.PACS.Client.Services
{
    public class TrackingFormContext: IPageContext
    {
        public int Id { get; set; }

        public TrackingFormContext(int id)
        {
            Id = id;
        }
    }
}