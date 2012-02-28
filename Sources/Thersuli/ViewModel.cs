
namespace Thersuli {
	using System.ComponentModel;

	/// <summary>Abstract view model.</summary>
	public abstract class ViewModel : INotifyPropertyChanged {
		/// <summary>Raise property changed.</summary>
		/// <param name="propertyName">Property name.</param>
		protected void OnPropertyChanged(string propertyName) {
			var evnt = PropertyChanged;
			if (evnt != null) evnt(this, new PropertyChangedEventArgs(propertyName));
		}

		/// <summary>Property changed.</summary>
		public event PropertyChangedEventHandler PropertyChanged;
	}
}
