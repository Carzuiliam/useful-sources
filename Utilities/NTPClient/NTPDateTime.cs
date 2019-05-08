using System;
using System.Net;
using System.Net.Sockets;

namespace Utilities.WindowsNTP
{
    /// <summary>
    /// This class queries the Windows' servers in order to obtain the current date and time.
    /// </summary>
    public class NTPDateTime
    {

        #region Server's URL ----------------------------------------------------------------------

        /// <summary>
        /// The URL of the Windows' time server, used in requests.
        /// </summary>
        private static readonly string TIME_URL = "time.windows.com";

        #endregion

        #region Time Request Methods --------------------------------------------------------------

        /// <summary>
        /// Returns the network time from the Windows's servers.
        /// </summary>
        /// <returns>A DateTime object with the received date and time from Windows' servers.</returns>
        public static DateTime FromWindowsServers()
        {
            return FromServerURL(TIME_URL);
        }

        /// <summary>
        /// Returns the network time from the server that matches the given URL.
        /// </summary>
        /// <param name="_ntpServerUrl">The server URL.</param>
        /// <returns>A DateTime object with the received date and time from the given URL.</returns>
        public static DateTime FromServerURL(string _ntpServerUrl)
        {
            IPAddress[] address = Dns.GetHostEntry(_ntpServerUrl).AddressList;

            if (address == null || address.Length == 0)
            {
                throw new ArgumentException("Cannot resolve IP address for '" + _ntpServerUrl + "'.", "_ntpServerUrl");
            }
            
            IPEndPoint ep = new IPEndPoint(address[0], 123);

            return FromEndPoint(ep);
        }

        /// <summary>
        /// Returns the network time from the given endpoint (IP and port number).
        /// </summary>
        /// <param name="_ipEndPoint">The endpoint (IP and port number).</param>
        /// <returns>A DateTime object with the received date and time from the given endpoint.</returns>
        public static DateTime FromEndPoint(IPEndPoint _ipEndPoint)
        {
            ulong intpart = 0;
            ulong fractpart = 0;

            byte offsetTransmitTime = 40;
            byte[] ntpData = new byte[48];

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            
            ntpData[0] = 0x1B;

            for (int i = 1; i < 48; i++)
            {
                ntpData[i] = 0;
            }               

            s.Connect(_ipEndPoint);
            s.Send(ntpData);
            s.Receive(ntpData);
            s.Close();

            for (int i = 0; i <= 3; i++)
            {
                intpart = 256 * intpart + ntpData[offsetTransmitTime + i];
            }                

            for (int i = 4; i <= 7; i++)
            {
                fractpart = 256 * fractpart + ntpData[offsetTransmitTime + i];
            }

            ulong milliseconds = (intpart * 1000 + (fractpart * 1000) / 0x100000000L);
            
            TimeSpan timeSpan = TimeSpan.FromTicks((long)milliseconds * TimeSpan.TicksPerMillisecond);
            DateTime dateTime = new DateTime(1900, 1, 1);

            dateTime += timeSpan;

            TimeSpan offsetAmount = TimeZoneInfo.Local.GetUtcOffset(dateTime);
            DateTime networkDateTime = (dateTime + offsetAmount);

            return networkDateTime;
        }

        #endregion

    }
}
