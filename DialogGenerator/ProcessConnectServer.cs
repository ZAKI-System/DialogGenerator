using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DialogGenerator
{
    /// <summary>
    /// プロセス接続サーバー
    /// </summary>
    internal class ProcessConnectServer
    {
        /// <summary>
        /// サーバーとしてデータを受け取り、配列で返す
        /// </summary>
        /// <returns>受け取ったデータの配列</returns>
        public static string[] GetData()
        {
            using (var server = new NamedPipeServerStream(Process.GetCurrentProcess().ProcessName))
            {
                // 接続待機
                bool connected = server.WaitForConnectionAsync().Wait(5000);
                if (connected)
                {
                    var dataList = new List<string>();
                    while (server.IsConnected)
                    {
                        // データ読み取り
                        string data = ReadData(server);
                        if (data != null)
                        {
                            dataList.Add(data);
                        }
                    }

                    return dataList.ToArray();
                }

                return new string[0];
            }
        }

        /// <summary>
        /// Pipeからデータを読み取り
        /// </summary>
        /// <param name="pipeServer">PipeServerStream</param>
        /// <returns>読み取ったデータ、またはnull</returns>
        private static string ReadData(NamedPipeServerStream pipeServer)
        {
            byte[] lenBuffer = new byte[4];
            int readCount = pipeServer.Read(lenBuffer, 0, 4);
            if (readCount == 0) return null;

            byte[] dataBuffer = new byte[BitConverter.ToInt32(lenBuffer, 0)];
            pipeServer.Read(dataBuffer, 0, dataBuffer.Length);

            return Encoding.UTF8.GetString(dataBuffer);
        }
    }
}
