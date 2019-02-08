using BaseballCommander.Application.Users.Models;

namespace BaseballCommander.Application.NotificationService
{
    public interface INotificationService
    {
        void SendMessage(string message, UserModel userModel);
    }
}