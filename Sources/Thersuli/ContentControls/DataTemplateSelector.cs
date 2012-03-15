
namespace Thersuli.ContentControls {
	using System.Windows;
	using System.Windows.Controls;

	public abstract class DataTemplateSelector : ContentControl {
		public abstract DataTemplate SelectTemplate(object item, DependencyObject container);

		// Summary: 
		//     This method overrides the base class OnContentChanged method  
		//     and updates the ContentTemplate with the selected DataTemplate. 
		// 
		// Parameters: 
		//   oldContent: 
		//     The old value of the System.Windows.Controls.ContentControl.Content property. 
		// 
		//   newContent: 
		//     The new value of the System.Windows.Controls.ContentControl.Content property. 
		protected override void OnContentChanged(object oldContent, object newContent) {
			base.OnContentChanged(oldContent, newContent);
			ContentTemplate = SelectTemplate(newContent, this);
		} 
	}
}
