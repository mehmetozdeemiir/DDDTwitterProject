using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Application.Models.VMs
{
    public class FollowListVM
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public List<int> Follows { get; set; }

    }
}
