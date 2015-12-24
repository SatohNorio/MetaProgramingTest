using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaProgramingTest
{
	/// <summary>
	/// プロパティを自動生成するアルゴリズムを定義します。
	/// </summary>
	class DisposeCodeStrategy : ICodeStrategy
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
				var r = WriteDispose(args);
				sb.Append(r);
			}
			return sb.ToString();
		}

		/// <summary>
		/// プロパティのコードを作成します。
		/// </summary>
		/// <param name="args">コードの作成に必要なパラメータを指定します。</param>
		/// <returns>作成したコードを返します。</returns>
		private string WriteDispose(string[] args)
		{
			var name = "hoge";
			if (0 < args.Length && !String.IsNullOrEmpty(args[0]))
			{
				name = args[0];
			}

			var sb = new StringBuilder(2000);
			sb.Append("// ------------------------------------------------------------------------------------------------------------\r\n");
			sb.Append("#region IDisposable Support\r\n");
			sb.Append("\r\n");
			sb.Append("/// <summary>\r\n");
			sb.Append("/// リソースが既に解放されていればtrueを保持します。\r\n");
			sb.Append("/// </summary>\r\n");
			sb.Append("/// <remarks>\r\n");
			sb.Append("/// 重複して解放処理が行われないようにするために使用します。\r\n");
			sb.Append("/// </remarks>\r\n");
			sb.Append("private bool disposedValue = false;\r\n");
			sb.Append("\r\n");
			sb.Append("/// <summary>\r\n");
			sb.Append("/// オブジェクトの破棄処理\r\n");
			sb.Append("/// </summary>\r\n");
			sb.Append("/// <param name=\"disposing\">マネージオブジェクトを破棄する場合はtrueを指定します。</param>\r\n");
			sb.Append("protected virtual void Dispose(bool disposing)\r\n");
			sb.Append("{\r\n");
			sb.Append("    if (!disposedValue)\r\n");
			sb.Append("    {\r\n");
			sb.Append("        if (disposing)\r\n");
			sb.Append("        {\r\n");
			sb.Append("        }\r\n");
			sb.Append("\r\n");
			sb.Append("        disposedValue = true;\r\n");
			sb.Append("    }\r\n");
			sb.Append("}\r\n");
			sb.Append("\r\n");
			sb.Append("/// <summary>\r\n");
			sb.Append("/// ファイナライザ\r\n");
			sb.Append("/// </summary>\r\n");
			sb.Append("/// <remarks>\r\n");
			sb.Append("/// アンマネージリソースを解放します。\r\n");
			sb.Append("/// </remarks>\r\n");
			sb.Append("~");
			sb.Append(name);
			sb.Append("()\r\n");
			sb.Append("{\r\n");
			sb.Append("    // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。\r\n");
			sb.Append("    Dispose(false);\r\n");
			sb.Append("}\r\n");
			sb.Append("\r\n");
			sb.Append("// このコードは、破棄可能なパターンを正しく実装できるように追加されました。\r\n");
			sb.Append("/// <summary>\r\n");
			sb.Append("/// オブジェクトの終了処理を行います。\r\n");
			sb.Append("/// </summary>\r\n");
			sb.Append("/// <remarks>\r\n");
			sb.Append("/// このコードは、破棄可能なパターンを正しく実装できるように追加されました。\r\n");
			sb.Append("/// </remarks>\r\n");
			sb.Append("public void Dispose()\r\n");
			sb.Append("{\r\n");
			sb.Append("    // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。\r\n");
			sb.Append("    Dispose(true);\r\n");
			sb.Append("\r\n");
			sb.Append("    // 終了処理を行ったのでファイナライザはもう呼ばない。\r\n");
			sb.Append("    GC.SuppressFinalize(this);\r\n");
			sb.Append("}\r\n");
			sb.Append("\r\n");
			sb.Append("#endregion // Dispose\r\n");
			sb.Append("// ------------------------------------------------------------------------------------------------------------\r\n");
			return sb.ToString();
		}
	}
}
