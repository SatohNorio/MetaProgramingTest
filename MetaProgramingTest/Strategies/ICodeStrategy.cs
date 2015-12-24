using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaProgramingTest
{
	/// <summary>
	/// コードを自動作成する機能を提供するインターフェースを定義します。
	/// </summary>
	interface ICodeStrategy
	{
		/// <summary>
		/// コードの自動生成処理を行います。
		/// </summary>
		/// <param name="src">自動生成のもとになるデータを指定します。</param>
		/// <returns>自動生成されたコードを返します。</returns>
		string Execute(string src);
	}
}
