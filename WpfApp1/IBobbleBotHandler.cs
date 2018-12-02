using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client.Events;

namespace WpfApp1
{
    public interface IBobbleBotHandler
    {
        void TwitchError(Exception ex);

        void TwitchNewSubscriber(OnNewSubscriberArgs e);

        void TwitchWhisperReceived(OnWhisperReceivedArgs e);

        void TwitchMessageReceived(OnMessageReceivedArgs e);

        void TwitchJoinedChannel(OnJoinedChannelArgs e);

        void TwitchConnected(OnConnectedArgs e);
    }
}
