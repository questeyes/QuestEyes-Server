using System.Net.Sockets;
using System.Threading;

namespace QuestEyes_Server
{
    class OSC_CommunicationFramework
    {
        public static void UponOpenInitialize()
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

    class VRCHAT_OSC
    {
        private static Socket VRCSender = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private static Socket VRCReceiver = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private static Thread receiveVRCBackground;
        private static CancellationToken VRCCancellationToken;

        public static void InitVRCConnection()
        {
            //todo




        }

        private static void ReceiveVRC()
        {
            //todo



        }

        public void SendVRC(byte[] data)
        {
            VRCSender.Send(data, data.Length, SocketFlags.None);
        }
    }

    class CUSTOM_OSC
    {
        private static Socket CustomSender = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        public static void InitCustomConnection(int sendPort)
        {
        }

        public void SendCustom(byte[] data)
        {
            //check if the port has changed since last send




            CustomSender.Send(data, data.Length, SocketFlags.None);
        }
    }
}
