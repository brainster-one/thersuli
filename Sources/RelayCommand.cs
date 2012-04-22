
namespace Thersuli {
	using System;

	/// <summary>Relay command.</summary>
	public class RelayCommand : Command {
		readonly Action _handler;
		readonly Func<object, bool> _enabled;

		/// <summary>Initializes a new instance of the RelayCommand class.</summary>
		/// <param name="handler"></param>
		/// <param name="enabled"></param>
		public RelayCommand(Action handler, Func<object, bool> enabled = null) {
			_handler = handler;
			_enabled = enabled;
		}

		/// <summary>Command can be executed?</summary>
		/// <param name="parameter">Parameter.</param>
		/// <returns>True - command can be executed.</returns>
		public override bool CanExecute(object parameter) {
			return _enabled == null || _enabled(parameter);
		}

		/// <summary>Executes command.</summary>
		/// <param name="parameter">Commands parameter.</param>
		public override void Execute(object parameter) {
			_handler();
		}
	}

}
