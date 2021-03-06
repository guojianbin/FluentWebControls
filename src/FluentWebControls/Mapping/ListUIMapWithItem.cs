//  * **************************************************************************
//  * Copyright (c) McCreary, Veselka, Bragg & Allen, P.C.
//  * This source code is subject to terms and conditions of the MIT License.
//  * A copy of the license can be found in the License.txt file
//  * at the root of this distribution. 
//  * By using this source code in any fashion, you are agreeing to be bound by 
//  * the terms of the MIT License.
//  * You must not remove this notice from this software.
//  * **************************************************************************

using System;
using System.Collections.Generic;

namespace FluentWebControls.Mapping
{
	public abstract class ListUIMapWithItem<TItem, TDomain, TModel> : ListUIMap<TDomain, TModel>
		where TItem : class, new()
	{
		protected ListUIMapWithItem(TItem item, IEnumerable<TDomain> items)
			: base(items)
		{
			Item = item.ToNonNull();
		}

		public TItem Item { get; private set; }
	}
}