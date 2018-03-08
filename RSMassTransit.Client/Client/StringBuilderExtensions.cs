﻿/*
    Copyright (C) 2018 Jeffrey Sharp

    Permission to use, copy, modify, and distribute this software for any
    purpose with or without fee is hereby granted, provided that the above
    copyright notice and this permission notice appear in all copies.

    THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
    WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
    MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
    ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
    WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
    ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
    OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace RSMassTransit.Client
{
    internal static class StringBuilderExtensions
    {
        internal static StringBuilder AppendDelimitedList(
            this StringBuilder  builder,
            IEnumerable<string> items,
            string              separator = ", ",
            string              delimiter = "'")
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (items == null)
                return builder;

            using (var e = items.GetEnumerator())
            {
                if (!e.MoveNext())
                    return builder;

                for (;;)
                {
                    builder.Append(delimiter);
                    builder.Append(e.Current);
                    builder.Append(delimiter);

                    if (!e.MoveNext())
                        return builder;

                    builder.Append(separator);
                }
            }
        }
    }
}
