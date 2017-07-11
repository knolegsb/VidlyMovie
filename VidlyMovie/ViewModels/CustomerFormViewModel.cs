using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyMovie.Models;

namespace VidlyMovie.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}