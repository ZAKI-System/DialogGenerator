using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DialogGenerator
{
    /// <summary>
    /// アプリケーション外部制御モード
    /// </summary>
    internal class RemoteApp
    {
        /// <summary>
        /// 外部制御開始
        /// </summary>
        public static void StartRemote()
        {
            try
            {
                // Get チェック
                string[] data = ProcessConnectServer.GetData();
                if (data.Length != 4) throw new Exception($"データ数が4ではありません。({data.Length})");
                string message = data[0];
                string title = data[1];
                if (!Enum.IsDefined(typeof(MessageBoxButtons), int.Parse(data[2]))) throw new Exception("button値が有効ではありません。");
                if (!Enum.TryParse(data[2], out MessageBoxButtons button)) throw new Exception("button値を変換できません。");
                if (!Enum.IsDefined(typeof(MessageBoxIcon), int.Parse(data[3]))) throw new Exception("icon値が有効ではありません。");
                if (!Enum.TryParse(data[3], out MessageBoxIcon icon)) throw new Exception("icon値を変換できません。");

                // 表示
                MessageBox.Show(message, title, button, icon);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                //MessageBox.Show(ex.ToString());
            }
        }
    }
}
