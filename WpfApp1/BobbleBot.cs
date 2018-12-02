using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;

namespace WpfApp1
{
    public class BobbleBot : IDisposable
    {
        private TwitchClient _client;
        private IBobbleBotHandler _handler;

        public BobbleBot(IBobbleBotHandler handler, string username, string accessToken, string channel)
        {
            _handler = handler;
            var credentials = new ConnectionCredentials(username, accessToken);

            try
            {
                _client = new TwitchClient();
                _client.Initialize(credentials, channel);

                _client.OnConnected += OnConnected;
                _client.OnJoinedChannel += OnJoinedChannel;
                _client.OnMessageReceived += OnMessageReceived;
                _client.OnWhisperReceived += OnWhisperReceived;
                _client.OnNewSubscriber += OnNewSubscriber;

                _client.Connect();
            }
            catch(Exception ex)
            {
                _handler.TwitchError(ex);
            }
        }

        private void OnNewSubscriber(object sender, OnNewSubscriberArgs e)
        {
            _handler.TwitchNewSubscriber(e);
        }

        private void OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {
            _handler.TwitchWhisperReceived(e);
        }

        private void OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            _handler.TwitchMessageReceived(e);
        }

        private void OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            _handler.TwitchJoinedChannel(e);
        }

        private void OnConnected(object sender, OnConnectedArgs e)
        {
            _handler.TwitchConnected(e);
        }

        public void Dispose()
        {
            _client.Disconnect();
        }
    }
}
