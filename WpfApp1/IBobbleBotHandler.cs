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
        void OnError(Exception ex);

        void OnNewSubscriber(object sender, OnNewSubscriberArgs e);

        void OnWhisperReceived(object sender, OnWhisperReceivedArgs e);

        void OnMessageReceived(object sender, OnMessageReceivedArgs e);

        void OnJoinedChannel(object sender, OnJoinedChannelArgs e);

        void OnConnected(object sender, OnConnectedArgs e);
    }
}
