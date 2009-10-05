using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FluentWebControls.Extensions
{
	public static class ComboSelectDataExtensions
	{
		public static ComboSelectData CssClass(this ComboSelectData comboSelectData, string cssClass)
		{
			comboSelectData.CssClass = cssClass;
			return comboSelectData;
		}

		public static ComboSelectData WithLabel(this ComboSelectData comboSelectData, LabelData label)
		{
			comboSelectData.Label = label;
			return comboSelectData;
		}

		public static ComboSelectData WithSelectedValues<T>(this ComboSelectData comboSelectData, IList<T> items, Expression<Func<T, int>> getIdValue) where T : class
		{
			if (items != null)
			{
				foreach (T item in items)
				{
					comboSelectData.SelectedValues.Add(getIdValue.Compile()(item).ToString());
				}
			}
			return comboSelectData;
		}

		public static ComboSelectData WithSelectedValues<T>(this ComboSelectData comboSelectData, IEnumerable<T> items, Expression<Func<T, int>> getIdValue) where T : class
		{
			if (items != null)
			{
				foreach (T item in items)
				{
					comboSelectData.SelectedValues.Add(getIdValue.Compile()(item).ToString());
				}
			}
			return comboSelectData;
		}

		public static ComboSelectData WithSelectedValues(this ComboSelectData comboSelectData, IEnumerable<int> items)
		{
			if (items != null)
			{
				foreach (int item in items)
				{
					comboSelectData.SelectedValues.Add(item.ToString());
				}
			}
			return comboSelectData;
		}

		public static ComboSelectData WithSize(this ComboSelectData comboSelectData, int size)
		{
			comboSelectData.Size = size;
			return comboSelectData;
		}
	}
}