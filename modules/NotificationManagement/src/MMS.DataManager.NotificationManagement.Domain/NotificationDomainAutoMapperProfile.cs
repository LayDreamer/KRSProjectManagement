using MMS.DataManager.NotificationManagement.Notifications.Dtos;

namespace MMS.DataManager.NotificationManagement
{
    public class NotificationDomainAutoMapperProfile:Profile
    {
        public NotificationDomainAutoMapperProfile()
        {
            CreateMap<Notification, NotificationEto>();
            CreateMap<Notification, NotificationDto>();
            CreateMap<NotificationSubscription, NotificationSubscriptionDto>();
        }
    }
}