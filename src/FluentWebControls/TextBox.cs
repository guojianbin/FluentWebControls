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
using System.Linq.Expressions;

using FluentWebControls.Extensions;

namespace FluentWebControls
{
	public static class TextBox
	{
		public static TextBoxData For<T, K>(T source, Func<T, string> getValue, Expression<Func<T, K>> forId)
		{
			var textBoxData = new TextBoxData(getValue(source))
				.WithId(forId);
			return textBoxData;
		}

		public static TextBoxData For<T>(T source, Expression<Func<T, string>> forValueAndId)
		{
			var getValue = forValueAndId.Compile();
			return For(source, getValue, forValueAndId);
		}
	}
}