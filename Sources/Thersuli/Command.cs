
namespace Thersuli {
	using System;
	using System.Windows.Input;

	/// <summary>Abstract command.</summary>
	public abstract class Command : ICommand {
		/// <summary>Command can be executed?</summary>
		/// <param name="parameter">Parameter.</param>
		/// <returns>True - command can be executed.</returns>
		public virtual bool CanExecute(object parameter) {
			return true;
		}

		/// <summary>Executes command.</summary>
		/// <param name="parameter">Commands parameter.</param>
		public abstract void Execute(object parameter);

		/// <summary>Can execute changed.</summary>
		public event EventHandler CanExecuteChanged;
	}
}
