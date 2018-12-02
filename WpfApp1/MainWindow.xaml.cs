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
    public partial class MainWindow : Window, IBobbleBotHandler
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        public void TwitchConnected(OnConnectedArgs e)
        {
            AppendText($"Connected to Channel: {e.AutoJoinChannel}");
        }

        public void TwitchJoinedChannel(OnJoinedChannelArgs e)
        {
            AppendText($"Joined Channel: {e.Channel}");
        }

        public void TwitchMessageReceived(OnMessageReceivedArgs e)
        {
            AppendText($"Message Received: {e.ChatMessage.Message}");
        }

        public void TwitchNewSubscriber(OnNewSubscriberArgs e)
        {
            AppendText($"New Subscriber {e.Subscriber.UserId}"); 
        }

        public void TwitchWhisperReceived(OnWhisperReceivedArgs e)
        {
            AppendText($"Wisper Received: {e.WhisperMessage.Message}");
        }

        public void TwitchError(Exception ex)
        {
            AppendText($"ERROR" + Environment.NewLine + ex.ToString());
        }

        private void AppendText(string text)
        {
            var msg = $"{DateTime.Now.ToString("HH:mm:ss")}: {text}" + Environment.NewLine;
            txtTwitch.AppendText(msg);
        }


    }
}
