using System;
using Core.Domain.Profiles;
using Core.DomainUnits;

namespace Core.Domain.News
{
    public class NewsCheck
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User WhoChecked { get; set; }

        public DateTime WhenChecked { get; set; }

        public RolesUnits.ApprovalStatus Status { get; set; }
    }
}
