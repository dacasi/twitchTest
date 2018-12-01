using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private TwitchClient _client;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var credentials = new ConnectionCredentials("twitch_username", "access_token");

            _client = new TwitchClient();
            _client.Initialize(credentials, "channel");

            _client.OnConnected += OnConnected;
            _client.OnJoinedChannel += OnJoinedChannel;
            _client.OnMessageReceived += OnMessageReceived;
            _client.OnWhisperReceived += OnWhisperReceived;
            _client.OnNewSubscriber += OnNewSubscriber;
        }

        private void OnNewSubscriber(object sender, OnNewSubscriberArgs e)
        {
           if (e.Subscriber.SubscriptionPlan == SubscriptionPlan.Prime)
                _client.SendMessage(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers! You just earned 500 points! So kind of you to use your Twitch Prime on this channel!");
            else
                _client.SendMessage(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers! You just earned 500 points!");
        }

        private void OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {
            if(e.WhisperMessage.Username == "my_friend")
                _client.SendWhisper(e.WhisperMessage.Username, "Hey! Whispers are so cool!!");
        }

        private void OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            if (e.ChatMessage.Message.Contains("badword"))
                _client.TimeoutUser(e.ChatMessage.Channel, e.ChatMessage.Username, TimeSpan.FromMinutes(30), "Bad word! 30 minute timeout!");
        }

        private void OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            txtTwitch.AppendText("Hey guys! I am a bot connected via TwitchLib!");
            _client.SendMessage(e.Channel, "Hey guys! I am a bot connected via TwitchLib!");
        }

        private void OnConnected(object sender, OnConnectedArgs e)
        {
            txtTwitch.AppendText($"Connected to {e.AutoJoinChannel}");
        }
    }
}
