using System;
using System.Collections.Generic;

namespace WalkinAPI.Models;

public class Prefetch
{
    public IEnumerable<JobRole>? Roles { get; set; }
    public IEnumerable<Technology>? Technologies { get; set; }
    public IEnumerable<College>? Colleges { get; set; }
    public IEnumerable<Branch>? Streams { get; set; }
    public IEnumerable<Qualification>? Qualifications { get; set; }

}