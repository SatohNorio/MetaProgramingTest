using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaProgramingTest
{
	/// <summary>
	/// DelegateCommand コマンドプロパティを自動生成するアルゴリズムを定義します。
	/// </summary>
	class CommandCodeStrategy : ICodeStrategy
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
			var name = "hoge";
			var comment = "○○";
			var type = "object";
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
				type = args[2];
			}

			var sb = new StringBuilder(2000);
			sb.Append("// ------------------------------------------------------------------------------------------------------------\r\n");
			sb.Append("#region ");
			sb.Append(name);
			sb.Append(" コマンド\r\n");
			sb.Append("\r\n");
			sb.Append("/// <summary>\r\n");
			sb.Append("/// ");
			sb.Append(comment);
			sb.Append(" を管理します。\r\n");
			sb.Append("/// </summary>\r\n");
			sb.Append("private ICommand F");
			sb.Append(name);
			sb.Append("Command;\r\n");
			sb.Append("\r\n");
			sb.Append("/// <summary>\r\n");
			sb.Append("/// ");
			sb.Append(comment);
			sb.Append(" を取得します。\r\n");
			sb.Append("/// </summary>\r\n");
			sb.Append("public ICommand ");
			sb.Append(name);
			sb.Append("Command\r\n");
			sb.Append("{\r\n");
			sb.Append("    get\r\n");
			sb.Append("    {\r\n");
			sb.Append("        return this.F");
			sb.Append(name);
			sb.Append("Command = this.F");
			sb.Append(name);
			sb.Append("Command ?? new DelegateCommand");
			if (this.UseParameter)
			{
				sb.Append("<");
				sb.Append(type);
				sb.Append(">");
			}
			sb.Append("(this.");
			sb.Append(name);
			switch (this.AppendingSuffix)
			{
				case SuffixType.Standard:
					sb.Append("ed");
					break;
				case SuffixType.Simple:
					sb.Append("d");
					break;
			}
			sb.Append(", this.Can");
			sb.Append(name);
			switch (this.AppendingSuffix)
			{
				case SuffixType.Standard:
					sb.Append("ed");
					break;
				case SuffixType.Simple:
					sb.Append("d");
					break;
			}
			sb.Append(");\r\n");
			sb.Append("    }\r\n");
			sb.Append("}\r\n");
			sb.Append("\r\n");
			sb.Append("/// <summary>\r\n");
			sb.Append("/// ");
			sb.Append(comment);
			sb.Append(" を実行します。\r\n");
			sb.Append("/// </summary>\r\n");
			if (this.UseParameter)
			{
				sb.Append("/// <param name=\"param\">CommandParameter に指定された オブジェクトを指定します。</param>\r\n");
			}
			sb.Append("public void ");
			sb.Append(name);
			switch (this.AppendingSuffix)
			{
				case SuffixType.Standard:
					sb.Append("ed");
					break;
				case SuffixType.Simple:
					sb.Append("d");
					break;
			}
			sb.Append("(");
			if (this.UseParameter)
			{
				sb.Append(type);
				sb.Append(" param");
			}
			sb.Append(")\r\n");
			sb.Append("{\r\n");
			sb.Append("}\r\n");
			sb.Append("\r\n");
			sb.Append("/// <summary>\r\n");
			sb.Append("/// コマンドを実行可能かどうか判定します。\r\n");
			sb.Append("/// </summary>\r\n");
			if (this.UseParameter)
			{
				sb.Append("/// <param name=\"param\">CommandParameter に指定された オブジェクトを指定します。</param>\r\n");
			}
			sb.Append("/// <returns>コマンドが実行可能なら true を返します。</returns>\r\n");
			sb.Append("public bool Can");
			sb.Append(name);
			switch (this.AppendingSuffix)
			{
				case SuffixType.Standard:
					sb.Append("ed");
					break;
				case SuffixType.Simple:
					sb.Append("d");
					break;
			}
			sb.Append("(");
			if (this.UseParameter)
			{
				sb.Append(type);
				sb.Append(" param");
			}
			sb.Append(")\r\n");
			sb.Append("{\r\n");
			sb.Append("    return true;\r\n");
			sb.Append("}\r\n");
			sb.Append("\r\n");
			sb.Append("#endregion // ");
			sb.Append(name);
			sb.Append("コマンド\r\n");
			sb.Append("// ------------------------------------------------------------------------------------------------------------\r\n");
			return sb.ToString();
		}

		// ------------------------------------------------------------------------------------------------------------
		#region UseParameter プロパティ

		/// <summary>
		/// パラメータを使用するかどうか を管理します。
		/// </summary>
		private bool FUseParameter;

		/// <summary>
		/// パラメータを使用するかどうか を取得または設定します。
		/// </summary>
		public bool UseParameter
		{
			get
			{
				return this.FUseParameter;
			}
			set
			{
				if (this.FUseParameter != value)
				{
					this.FUseParameter = value;
				}
			}
		}

		#endregion // UseParameter プロパティ
		// ------------------------------------------------------------------------------------------------------------
		// ------------------------------------------------------------------------------------------------------------
		#region AppendingSuffix プロパティ

		/// <summary>
		/// メソッド名の後ろに付加する文字の種別 を管理します。
		/// </summary>
		private SuffixType FAppendingSuffix;

		/// <summary>
		/// メソッド名の後ろに付加する文字の種別 を取得または設定します。
		/// </summary>
		public SuffixType AppendingSuffix
		{
			get
			{
				return this.FAppendingSuffix;
			}
			set
			{
				if (this.FAppendingSuffix != value)
				{
					this.FAppendingSuffix = value;
				}
			}
		}

		#endregion // SuffixType プロパティ
		// ------------------------------------------------------------------------------------------------------------
	}

	/// <summary>
	/// メソッドの後ろに付加するサフィックスの種別を定義します。
	/// </summary>
	public enum SuffixType
	{
		/// <summary>
		/// サフィックスを付加せず、名前をそのまま使用します。
		/// </summary>
		Exsactly,

		/// <summary>
		/// 名前の後ろに"ed"を付加します。
		/// </summary>
		Standard,

		/// <summary>
		/// 名前の後ろに"d"を付加します。
		/// </summary>
		Simple
	}
}
