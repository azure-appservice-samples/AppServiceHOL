using Microsoft.Azure.Mobile.Server;

namespace mobileHOLService.DataObjects
{
    public class TodoItem : EntityData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }

        public string PhoneNumber { get; set; }

        public bool Processed { get; set; }
    }
}