using System.Net.Sockets;
using System.Threading;

namespace QuestEyes_Server
{
    public static class OSC_CommunicationFramework
    {
        public static void LoadOSCCommunication()
        {
            foreach (OSC_SoftwareControlSystem.OSCSetting setting in OSC_SoftwareControlSystem.OSCSettings)
            {
                if (setting.State == "1") //if setting is enabled
                {
                    string settingName = setting.Name;
                    string settingPort = setting.Port;

                    if (settingName == "VRC") //if VRC is enabled...
                    {
                        VRCHAT_OSC.InitVRCConnection();
                    }
                    if (settingName == "Custom") //if custom is enabled...
                    {
                        CUSTOM_OSC.InitCustomConnection(int.Parse(settingPort));
                    }
                    else
                    {
                        //setting is not recognised, ignore.
                    }
                }
            }
        }
    }

    public static class VRCHAT_OSC
    {
        private static readonly Socket VRCSender = new(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private static readonly Socket VRCReceiver = new(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private static readonly Thread receiveVRCBackground;
        private static readonly CancellationToken VRCCancellationToken;

        public static void InitVRCConnection()
        {
            //todo




        }

        private static void ReceiveVRC()
        {
            //todo



        }

        public static void SendVRC(byte[] data)
        {
            VRCSender.Send(data, data.Length, SocketFlags.None);
        }
    }

    public static class CUSTOM_OSC
    {
        private static readonly Socket CustomSender = new(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        public static void InitCustomConnection(int sendPort)
        {
            //todo



        }

        public static void SendCustom(byte[] data)
        {
            //check if the port has changed since last send




            CustomSender.Send(data, data.Length, SocketFlags.None);
        }
    }
}
