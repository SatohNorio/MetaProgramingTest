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
	class PropertyCodeStrategy : ICodeStrategy
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
			List<string> propList = new List<string>(lines);
			string name = "△△";

			if (this.UsePropertyGroup && 0 < lines.Length && 0 < lines[0].Length)
			{
				name = lines[0];
			}

			if (this.UsePropertyGroup)
			{
				sb.Append("// ------------------------------------------------------------------------------------------------------------\r\n");
				sb.Append("#region ");
				sb.Append(name);
				sb.Append("\r\n");

				propList.RemoveAt(0);
			}

			foreach (var s in propList)
			{
				var args = s.Split(',');
				var r = WritePropertyBlock(args);
				sb.Append(r);
			}

			if (this.UsePropertyGroup)
			{
				sb.Append("\r\n");
				sb.Append("#endregion ");
				sb.Append(name);
				sb.Append("\r\n");
				sb.Append("// ------------------------------------------------------------------------------------------------------------\r\n");
			}
			return sb.ToString();
		}

		/// <summary>
		/// プロパティのコードを作成します。
		/// </summary>
		/// <param name="args">コードの作成に必要なパラメータを指定します。</param>
		/// <returns>作成したコードを返します。</returns>
		private string WritePropertyBlock(params string[] args)
		{
			var name = "hoge";
			var comment = "○○";
			var commentSub = "";
			var type = "int";
			var nmClass = "Hoge";
			if (0 < args.Length && !String.IsNullOrEmpty(args[0]))
			{
				name = args[0];
			}
			if (1 < args.Length && !String.IsNullOrEmpty(args[1]))
			{
				comment = args[1];
			}
			if (2 < args.Length && !String.IsNullOrEmpty(args[2]))
			{
				commentSub = args[2];
			}
			if (3 < args.Length && !String.IsNullOrEmpty(args[3]))
			{
				type = args[3];
			}
			if (4 < args.Length && !String.IsNullOrEmpty(args[4]))
			{
				nmClass = args[4];
			}

			var sb = new StringBuilder(2000);
			if (!this.UsePropertyGroup)
			{
				sb.Append("// ------------------------------------------------------------------------------------------------------------\r\n");
				sb.Append("#region ");
				sb.Append(name);
				sb.Append(" プロパティ");
				if (this.IsDependencyProperty)
				{
					sb.Append("（依存関係プロパティ）");
				}
				sb.Append("\r\n");
			}
			sb.Append("\r\n");
			if (!this.IsOmmittingCode&&!this.IsDependencyProperty)
			{
				sb.Append("/// <summary>\r\n");
				sb.Append("/// ");
				sb.Append(comment);
				sb.Append(" を管理します。\r\n");
				sb.Append("/// </summary>\r\n");
				sb.Append("private ");
				sb.Append(type);
				sb.Append(" F");
				sb.Append(name);
				sb.Append(";\r\n");
				sb.Append("\r\n");
			}
			sb.Append("/// <summary>\r\n");
			sb.Append("/// ");
			sb.Append(comment);
			sb.Append(" を取得");
			if (!this.IsReadOnly)
			{
				sb.Append("または設定");
			}
			sb.Append("します。\r\n");
			if (!String.IsNullOrEmpty(commentSub))
			{
				sb.Append("/// ");
				sb.Append(commentSub);
				sb.Append(" \r\n");
			}
			sb.Append("/// </summary>\r\n");
			if (this.UseDataMember)
			{
				sb.Append("[DataMember]\r\n");
			}
			sb.Append("public ");
			sb.Append(type);
			sb.Append(" ");
			sb.Append(name);
			if (this.IsOmmittingCode)
			{
				sb.Append("{ get; ");
				if (!this.IsReadOnly)
				{
					sb.Append("set; ");
				}
				sb.Append("}\r\n");
			}
			else if (this.IsDependencyProperty)
			{
				sb.Append("{\r\n");
				sb.Append("get{ return (");
				sb.Append(type);
				sb.Append(")GetValue(");
				sb.Append(name);
				sb.Append("Property); }\r\n");
				sb.Append("set{ SetValue( ");
				sb.Append(name);
				sb.Append("Property, value); }\r\n");
				sb.Append("}\r\n");
				sb.Append("\r\n");
				sb.Append("/// <summary>\r\n");
				sb.Append("/// ");
				sb.Append(comment);
				sb.Append(" を管理する依存関係プロパティ\r\n");
				sb.Append("/// </summary>\r\n");
				sb.Append("public static readonly DependencyProperty ");
				sb.Append(name);
				sb.Append("Property =\r\n");
				sb.Append("    DependencyProperty.Register(\"");
				sb.Append(name);
				sb.Append("\", typeof(");
				sb.Append(type);
				sb.Append("), typeof(");
				sb.Append(nmClass);
				sb.Append("), new PropertyMetadata(null));\r\n");
			}
			else
			{
				sb.Append("\r\n");
				sb.Append("{\r\n");
				sb.Append("    get\r\n");
				sb.Append("    {\r\n");
				sb.Append("        return this.F");
				sb.Append(name);
				sb.Append(";\r\n");
				sb.Append("    }\r\n");
				if (!this.IsReadOnly)
				{
					sb.Append("    set\r\n");
					sb.Append("    {\r\n");
					sb.Append("        if (this.F");
					sb.Append(name);
					sb.Append(" != value)\r\n");
					sb.Append("        {\r\n");
					sb.Append("            this.F");
					sb.Append(name);
					sb.Append(" = value;\r\n");
					if (this.UseOnPropertyChanged)
					{
						sb.Append("            this.OnPropertyChanged(\"");
						sb.Append(name);
						sb.Append("\");\r\n");
					}
					sb.Append("        }\r\n");
					sb.Append("    }\r\n");
				}
				sb.Append("}\r\n");
			}
			if (!this.UsePropertyGroup)
			{
				sb.Append("\r\n");
				sb.Append("#endregion ");
				sb.Append(name);
				sb.Append(" プロパティ\r\n");
				sb.Append("// ------------------------------------------------------------------------------------------------------------\r\n");
			}
			return sb.ToString();
		}

		// ------------------------------------------------------------------------------------------------------------
		#region オプション

		/// <summary>
		/// 読み取り専用状態 を取得または設定します。
		/// </summary>
		public bool IsReadOnly { get; set; }

		/// <summary>
		/// OnPropertyChanged イベントを使用するかどうか を取得または設定します。
		/// </summary>
		public bool UseOnPropertyChanged { get; set; }

		/// <summary>
		/// region の使用方法 を取得または設定します。
		/// region の中に複数プロパティを定義する場合は true を指定します。 
		/// </summary>
		public bool UsePropertyGroup { get; set; }

		/// <summary>
		/// プロパティに [DataMember] 属性を付加するかどうかの状態 を取得または設定します。
		/// </summary>
		public bool UseDataMember { get; set; }

		/// <summary>
		/// get set のコード部分の省略可能状態 を取得または設定します。
		/// </summary>
		public bool IsOmmittingCode { get; set; }

		/// <summary>
		/// 依存関係プロパティかどうか を取得または設定します。
		/// </summary>
		public bool IsDependencyProperty { get; set; }

		#endregion // オプション
		// ------------------------------------------------------------------------------------------------------------
	}
}
