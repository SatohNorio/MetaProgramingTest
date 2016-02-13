using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

using Ns.Common;
using System.Reflection;
using System.Diagnostics;

namespace MetaProgramingTest
{
	/// <summary>
	/// ViewModel を定義します。
	/// </summary>
	class MainViewModel : ViewModel
	{
		// ------------------------------------------------------------------------------------------------------------
		#region コンストラクタ

		/// <summary>
		/// MetaProgramingTest.MainViewModel クラスの新しいインスタンスを作成します。
		/// </summary>
		public MainViewModel()
		{
		}

		#endregion
		// ------------------------------------------------------------------------------------------------------------

		private ICodeStrategy FStrategy;

		// ------------------------------------------------------------------------------------------------------------
		#region [アクション]-[実行]コマンド

		/// <summary>
		/// 処理を開始するコマンドを管理します。
		/// </summary>
		private ICommand FExecutingActionCommand;

		/// <summary>
		/// 処理を開始するコマンドを取得します。
		/// </summary>
		public ICommand ExecutingActionCommand
		{
			get
			{
				return this.FExecutingActionCommand = this.FExecutingActionCommand ?? new DelegateCommand<TextBox>(this.ExecutingAction, this.CanExecutingAction);
			}
		}

		/// <summary>
		/// 処理を開始するコマンドを実行します。
		/// </summary>
		/// <param name="tb">コマンドパラメータに指定された TextBox を指定します。</param>
		public void ExecutingAction(TextBox tb)
		{
			var st = this.FStrategy;
			if (st != null)
			{
				var src = tb.Text;
				this.ResultCode = st.Execute(src);
			}
		}

		/// <summary>
		/// コマンドを実行可能な状態ならtrueを返します。
		/// </summary>
		/// <param name="tb">コマンドパラメータに指定された TextBox を指定します。</param>
		/// <returns>コマンドが実行可能なら true を返します。</returns>
		public bool CanExecutingAction(TextBox tb)
		{
			return true;
		}

		#endregion
		// ------------------------------------------------------------------------------------------------------------
		// ------------------------------------------------------------------------------------------------------------
		#region StrategyChange コマンド

		/// <summary>
		/// アルゴリズムを切り替えるコマンド を管理します。
		/// </summary>
		private ICommand FStrategyChangeCommand;

		/// <summary>
		/// アルゴリズムを切り替えるコマンド を取得します。
		/// </summary>
		public ICommand StrategyChangeCommand
		{
			get
			{
				return this.FStrategyChangeCommand = this.FStrategyChangeCommand ?? new DelegateCommand<ICodeStrategy>(this.StrategyChanged, this.CanStrategyChanged);
			}
		}

		/// <summary>
		/// アルゴリズムを切り替えるコマンド を実行します。
		/// </summary>
		/// <param name="param">CommandParameter に指定された オブジェクトを指定します。</param>
		public void StrategyChanged(ICodeStrategy param)
		{
			this.FStrategy = param;
		}

		/// <summary>
		/// コマンドを実行可能かどうか判定します。
		/// </summary>
		/// <param name="param">CommandParameter に指定された オブジェクトを指定します。</param>
		/// <returns>コマンドが実行可能なら true を返します。</returns>
		public bool CanStrategyChanged(ICodeStrategy param)
		{
			return true;
		}

		#endregion // StrategyChangeコマンド
		// ------------------------------------------------------------------------------------------------------------
		// ------------------------------------------------------------------------------------------------------------
		#region 出力結果プロパティ

		/// <summary>
		/// 処理結果を管理します。
		/// </summary>
		private string FResultCode;

		/// <summary>
		/// 処理結果を取得または設定します。
		/// </summary>
		public string ResultCode
		{
			get
			{
				return this.FResultCode;
			}
			set
			{
				if (this.FResultCode != value)
				{
					this.FResultCode = value;
					this.OnPropertyChanged("ResultCode");
				}
			}
		}

		#endregion
		// ------------------------------------------------------------------------------------------------------------
		// ------------------------------------------------------------------------------------------------------------
		#region ステータスバー

		/// <summary>
		/// バージョン情報 を取得します。
		/// </summary>
		public string AssemblyVersion
		{
			get
			{
				string rtVersion = "";
				var asm = Assembly.GetEntryAssembly();
				if (asm != null)
				{
					rtVersion = "Ver." + asm.GetName().Version;
				}
				return rtVersion;
			}
		}

		#endregion ステータスバー
		// ------------------------------------------------------------------------------------------------------------
	}
}
