using System;
using System.Linq.Expressions;

using MvbaCore;

namespace FluentWebControls
{
	public static class CommandGridColumn
	{
		[Obsolete("use .For(x=>x.ToString(), x=>x.ForQueryStringName, (Controller c)=>c.ForActionName)")]
		public static CommandColumn<T> For<T>(Expression<Func<T, int>> getItemIdAndValue, string action) where T : class
		{
			var func = getItemIdAndValue.Compile();
			return new CommandColumn<T>(item => func(item).ToString(), Reflection.GetPropertyName(getItemIdAndValue).ToCamelCase(), action);
		}

		[Obsolete("use .For(x=>x.Value, x=>x.ForQueryStringName, (Controller c)=>c.ForActionName)")]
		public static CommandColumn<T> For<T>(Expression<Func<T, string>> getItemIdAndValue, string action) where T : class
		{
			var func = getItemIdAndValue.Compile();
			return new CommandColumn<T>(func, Reflection.GetPropertyName(getItemIdAndValue).ToCamelCase(), action);
		}

		public static CommandColumn<T> For<T, TController>(Func<T, string> getValue, Expression<Func<TController, object>> targetControllerAction) where T : class
		{
			return new CommandColumn<T>(getValue, "", Reflection.GetMethodName(targetControllerAction));
		}

		public static CommandColumn<T> For<T, TController>(Func<T, string> getValue, Expression<Func<T, object>> forQueryStringId, Expression<Func<TController, object>> targetControllerAction) where T : class
		{
			return new CommandColumn<T>(getValue, Reflection.GetPropertyName(forQueryStringId).ToCamelCase(), Reflection.GetMethodName(targetControllerAction));
		}
	}
}