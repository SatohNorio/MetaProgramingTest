using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaProgramingTest
{
    /// <summary>
    /// Behavior クラス を自動生成するアルゴリズムを定義します。
    /// </summary>
    class BehaviorCodeStrategy : ICodeStrategy
    {
        /// <summary>
        /// コードの自動生成処理を行います。
        /// </summary>
        /// <param name="src">自動生成のもとになるデータを指定します。</param>
        /// <returns>自動生成されたコードを返します。</returns>
        public string Execute(string src)
        {
            var sb = new StringBuilder(20000);
            var lines = src.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in lines)
            {
                var args = s.Split(',');
                var r = WriteCommandPropertyBlock(args);
                sb.Append(r);
            }
            return sb.ToString();
        }

        /// <summary>
        /// コマンドプロパティのコードを作成します。
        /// </summary>
        /// <param name="args">コードの作成に必要なパラメータを指定します。</param>
        /// <returns>作成したコードを返します。</returns>
        private string WriteCommandPropertyBlock(string[] args)
        {
            var nmSpace = "fuga";
            var name = "hoge";
            var comment = "○○";
            var type = "object";
            var nmEvent = "hoged";
            var commentEvent = "○○";
            if (0 < args.Length && !String.IsNullOrEmpty(args[0]))
            {
                nmSpace = args[0];
            }
            if (1 < args.Length && !String.IsNullOrEmpty(args[1]))
            {
                name = args[1];
            }
            if (2 < args.Length && !String.IsNullOrEmpty(args[2]))
            {
                comment = args[2];
            }
            if (3 < args.Length && !String.IsNullOrEmpty(args[3]))
            {
                type = args[3];
            }
            if (4 < args.Length && !String.IsNullOrEmpty(args[4]))
            {
                nmEvent = args[4];
            }
            if (5 < args.Length && !String.IsNullOrEmpty(args[5]))
            {
                commentEvent = args[5];
            }

            var sb = new StringBuilder(2000);
            sb.Append("// ================================================================================================================\r\n");
            sb.Append("#region ");
            sb.Append(name);
            sb.Append("\r\n");
            sb.Append("\r\n");
            sb.Append("/// <summary>\r\n");
            sb.Append("/// ");
            sb.Append(comment);
            sb.Append("\r\n");
            sb.Append("/// </summary>\r\n");
            sb.Append("public class ");
            sb.Append(name);
            sb.Append(" : Behavior<");
            sb.Append(type);
            sb.Append(">\r\n");
            sb.Append("{\r\n");
            sb.Append("    // ------------------------------------------------------------------------------------------------------------\r\n");
            sb.Append("    #region コンストラクタ\r\n");
            sb.Append("\r\n");
            sb.Append("    /// <summary>\r\n");
            sb.Append("    /// ");
            sb.Append(nmSpace);
            sb.Append(".");
            sb.Append(name);
            sb.Append(" クラスの新しいインスタンスを作成します。\r\n");
            sb.Append("    /// </summary>\r\n");
            sb.Append("    public ");
            sb.Append(name);
            sb.Append("()\r\n");
            sb.Append("    {\r\n");
            sb.Append("    }\r\n");
            sb.Append("\r\n");
            sb.Append("    #endregion コンストラクタ\r\n");
            sb.Append("    // ------------------------------------------------------------------------------------------------------------\r\n");
            sb.Append("\r\n");
            sb.Append("    /// <summary>\r\n");
            sb.Append("    /// 要素にアタッチされた時に実行する処理を定義します。\r\n");
            sb.Append("    /// </summary>\r\n");
            sb.Append("    protected override void OnAttached()\r\n");
            sb.Append("    {\r\n");
            sb.Append("        base.OnAttached();\r\n");
            sb.Append("        this.AssociatedObject.");
            sb.Append(nmEvent);
            sb.Append(" += AssociatedObject");
            sb.Append(nmEvent);
            sb.Append(";\r\n");
            sb.Append("    }\r\n");
            sb.Append("\r\n");
            sb.Append("    /// <summary>\r\n");
            sb.Append("    /// 要素からデタッチされる時に実行する処理を定義します。\r\n");
            sb.Append("    /// </summary>\r\n");
            sb.Append("    protected override void OnDetaching()\r\n");
            sb.Append("    {\r\n");
            sb.Append("        base.OnDetaching();\r\n");
            sb.Append("        this.AssociatedObject.");
            sb.Append(nmEvent);
            sb.Append(" -= AssociatedObject");
            sb.Append(nmEvent);
            sb.Append(";\r\n");
            sb.Append("    }\r\n");
            sb.Append("\r\n");
            sb.Append("    /// <summary>\r\n");
            sb.Append("    /// ");
            sb.Append(commentEvent);
            sb.Append(" のイベントを処理します。\r\n");
            sb.Append("    /// </summary>\r\n");
            sb.Append("    /// <param name=\"sender\">イベントを送信したオブジェクトを指定します。</param>\r\n");
            sb.Append("    /// <param name=\"e\">イベント引数を指定します。</param>\r\n");
            sb.Append("    private void AssociatedObject");
            sb.Append(nmEvent);
            sb.Append("(object sender, EventArgs e)\r\n");
            sb.Append("    {\r\n");
            sb.Append("    }\r\n");
            sb.Append("}\r\n");
            sb.Append("\r\n");
            sb.Append("#endregion\r\n");
            sb.Append("// ================================================================================================================\r\n");
            return sb.ToString();
        }
    }
}

