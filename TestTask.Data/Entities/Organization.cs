﻿namespace TestTask.Data.Entities;

public class Organization
{
    public int ID { get; set; }
    public string FullName { get; set; }
    public string ShortName { get; set; }

    public int ActivityAreaId { get; set; }
    public ActivityArea ActivityArea { get; set; }

}