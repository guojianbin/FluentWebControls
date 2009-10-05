using System.Collections.Generic;
using FluentWebControls.Extensions;
using FluentWebControls.Interfaces;

namespace FluentWebControls
{
	public class ScrollableGrid
	{
		public static GridData<TReturn> For<TReturn>(IPagedList<TReturn> pagedList, IPagedListParameters pagedListParameters, string controllerName, string actionName)
		{
			IEnumerable<TReturn> items = pagedList
				.OrderBy(pagedListParameters.SortField, pagedListParameters.SortDirection)
				.ToList();
			return new GridData<TReturn>(pagedListParameters, controllerName, actionName, items, pagedList.Total());
		}

		public static GridData<TReturn> For<TReturn>(IPagedList<string, TReturn> pagedList, IPagedListParameters pagedListParameters, string controllerName, string actionName, string filter)
		{
			IEnumerable<TReturn> items = pagedList
				.OrderBy(pagedListParameters.SortField, pagedListParameters.SortDirection)
				.ToList(filter);
			return new GridData<TReturn>(pagedListParameters, controllerName, actionName, items, pagedList.Total(filter));
		}

		public static GridData<TReturn> For<TReturn>(IPagedList<int?, TReturn> pagedList, IPagedListParameters pagedListParameters, string controllerName, string actionName, int? filter)
		{
			IEnumerable<TReturn> items = pagedList
				.OrderBy(pagedListParameters.SortField, pagedListParameters.SortDirection)
				.ToList(filter);
			return new GridData<TReturn>(pagedListParameters, controllerName, actionName, items, pagedList.Total(filter));
		}

		public static GridData<TReturn> For<TReturn>(IPagedList<int?, int?, TReturn> pagedList, IPagedListParameters pagedListParameters, string controllerName, string actionName, int? filter1, int? filter2)
		{
			IEnumerable<TReturn> items = pagedList
				.OrderBy(pagedListParameters.SortField, pagedListParameters.SortDirection)
				.ToList(filter1, filter2);
			return new GridData<TReturn>(pagedListParameters, controllerName, actionName, items, pagedList.Total(filter1, filter2));
		}

		public static GridData<TReturn> For<TReturn>(IPagedList<int?, int?, int?, TReturn> pagedList, IPagedListParameters pagedListParameters, string controllerName, string actionName, int? filter1, int? filter2, int? filter3)
		{
			IEnumerable<TReturn> items = pagedList
				.OrderBy(pagedListParameters.SortField, pagedListParameters.SortDirection)
				.ToList(filter1, filter2, filter3);
			return new GridData<TReturn>(pagedListParameters, controllerName, actionName, items, pagedList.Total(filter1, filter2, filter3));
		}
	}
}