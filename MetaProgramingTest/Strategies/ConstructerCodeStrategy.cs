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
	class ConstructerCodeStrategy : ICodeStrategy
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
				var r = WriteConstructer(args);
				sb.Append(r);
			}
			return sb.ToString();
		}

		/// <summary>
		/// プロパティのコードを作成します。
		/// </summary>
		/// <param name="args">コードの作成に必要なパラメータを指定します。</param>
		/// <returns>作成したコードを返します。</returns>
		private string WriteConstructer(string[] args)
		{
			var ns = "fuga";
			var name = "hoge";
			if (0 < args.Length && !String.IsNullOrEmpty(args[0]))
			{
				ns = args[0];
			}
			if (1 < args.Length && !String.IsNullOrEmpty(args[1]))
			{
				name = args[1];
			}

			var sb = new StringBuilder(2000);
			sb.Append("// ------------------------------------------------------------------------------------------------------------\r\n");
			sb.Append("#region コンストラクタ\r\n");
			sb.Append("\r\n");
			sb.Append("/// <summary>\r\n");
			sb.Append("/// ");
			sb.Append(ns);
			sb.Append(".");
			sb.Append(name);
			sb.Append(" クラスの新しいインスタンスを作成します。\r\n");
			sb.Append("/// </summary>\r\n");
			sb.Append("public ");
			sb.Append(name);
			sb.Append("()\r\n");
			sb.Append("{\r\n");
			sb.Append("}\r\n");
			sb.Append("\r\n");
			sb.Append("#endregion // コンストラクタ\r\n");
			sb.Append("// ------------------------------------------------------------------------------------------------------------\r\n");
			return sb.ToString();
		}
	}
}
