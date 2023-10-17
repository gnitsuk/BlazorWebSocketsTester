using WebSocketSharp;
using WebSocketSharp.Server;

namespace BlazorTest.Data
{
    public class WebSocketTestService
    {
        private WebSocketServer? m_WSServer = null;

        public void StartServer()
        {
            if (m_WSServer == null)
            {
                m_WSServer = new WebSocketServer(3333, false);
                //m_WSServer = new WebSocketServer(3333, true);
                m_WSServer.AddWebSocketService<Laputa>("/" + "Laputa");

                m_WSServer.Start();
            }
        }

        public string QueryServer()
        {
            string szResult = "Server is NULL";

            if (m_WSServer != null)
            {
                szResult = m_WSServer.Address.ToString();
            }

            return szResult;
        }
    }

    public class Laputa : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Send("Elvis Lives!");
        }
    }
}
