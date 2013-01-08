﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentWebControls.Extensions;

namespace FluentWebControls
{
	public class CheckBoxListData : ValidatableWebControlBase
	{
		private readonly IEnumerable<KeyValuePair<string, string>> _items;

		public CheckBoxListData(IEnumerable<KeyValuePair<string, string>> items)
		{
			_items = items;
			SelectedValues = new List<string>();
			CssClass = new List<string>();
		}

		public List<string> SelectedValues { get; private set; }
		public List<string> CssClass { get; set; }
		public LabelData Label { get; set; }
		public string TabIndex { get; set; }

		public override string ToString()
		{
			var sb = new StringBuilder();
			if (Label != null)
			{
				sb.Append(Label);
			}
			if (PropertyMetaData != null && PropertyMetaData.IsRequired)
			{
				sb.Append("<em>*</em>");
			}
			var id = ((IWebControl)this).Id;
			var idPrefix = ((IWebControl)this).IdPrefix;
			var namePrefix = ((IWebControl)this).NamePrefix;
			foreach (var item in _items)
			{
				var isChecked = SelectedValues.Any(value => item.Value != null && item.Value.Equals(value));
				var checkbox = new CheckBoxData(isChecked)
					.WithValue(item.Value)
					.WithId(id)
					.WithNamePrefix(namePrefix)
					.WithIdPrefix(idPrefix)
					.WithClass(CssClass.Join(" "));

				sb.Append("<div>");
				sb.Append(checkbox);
				sb.Append(item.Key);
				sb.Append("</div>");
			}
			return sb.ToString();
		}

	}
}