
namespace Thersuli.MarkupExtensions {
	using System;
	using System.Reflection;
	using System.Windows;
	using System.Windows.Input;
	using System.Windows.Markup;
	using System.Xaml;

	public class InvokeCommandExtension : MarkupExtension {

		public string Command { get; set; }

		public override object ProvideValue(IServiceProvider serviceProvider) {
			try {
				IProvideValueTarget targetProvider = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
				IXamlTypeResolver xamlResolver = serviceProvider.GetService(typeof(IXamlTypeResolver)) as IXamlTypeResolver;
				IRootObjectProvider rootObject = serviceProvider.GetService(typeof(IRootObjectProvider)) as IRootObjectProvider;

				object targetObject = targetProvider.TargetObject;
				EventInfo targetEvent = targetProvider.TargetProperty as EventInfo;

				ParameterInfo[] pars = targetEvent.GetAddMethod().GetParameters();
				Type delegateType = pars[0].ParameterType;

				MethodInfo invoke = delegateType.GetMethod("Invoke");
				pars = invoke.GetParameters();

				//Create the function call
				Type customType = typeof(InvokeCommandExtension);
				var nonGenericMethod = customType.GetMethod("PrivateHandlerGeneric");
				MethodInfo genericMethod = nonGenericMethod.MakeGenericMethod(pars[1].ParameterType);
				Delegate del = null;

				if (rootObject != null) {
					FrameworkElement rootObjFE = rootObject.RootObject as FrameworkElement;

					if (rootObjFE != null) {
						_target = rootObjFE.DataContext;
						//_targetMethod = _target.GetType().GetMethod(Command);
						_command = (ICommand)_target.GetType().GetProperty(Command).GetValue(_target, null);

						if (_target == null)
							return null;
						if (_command == null)
							return null;

						del = Delegate.CreateDelegate(delegateType, this, genericMethod);
						//targetEvent.AddEventHandler(targetObject, del);
					}
				}

				return del;
			} catch (Exception ex) {
				string innerex = ex.InnerException.ToString();
				return null;
			}
		}

		public void PrivateHandlerGeneric<T>(object Sender, T e) {
			/*string name = Sender.GetType().Name;
			_targetMethod.Invoke(_target, new object[] { name });*/
			_command.Execute(e);
		}

		private object _target;
		private ICommand _command;
		//private MethodInfo _targetMethod;
	}
}
