using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiShare.Domain.Entities;
using TaxiShare.Domain.Extentions;

namespace TaxiShare.Application.Models.Messages
{
    public class MessageItemVM
    {
        public MessageItemVM(Message messege)
        {
            Id = messege.Id;
            Guid = messege.Guid;
            Text = messege.Text;
            Created = messege.Created;
            IsSystemMessege = messege.IsSystemMessege;
            Creator = messege.Creator != null
                ? new BaseItem<Guid>(messege.Creator.Guid, UserExtentions.GetFullNameOrDefault(messege.Creator.Firstname, messege.Creator.Surname, messege.Creator.PatronymicName))
                : null;
        }
        public long Id { get; set; }
        public Guid Guid { get; set; }
        public string Text { get; set; }
        public BaseItem<Guid>? Creator { get; set; }
        public DateTime Created { get; set; }
        public bool IsSystemMessege { get; set; }
    }
}
