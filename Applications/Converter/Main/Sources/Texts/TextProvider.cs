/* ------------------------------------------------------------------------- */
//
// Copyright (c) 2010 CubeSoft, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
/* ------------------------------------------------------------------------- */
namespace Cube.Globalization;

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

public class TextGroup : Dictionary<string, string> { }

public abstract class TextProvider
{
    protected TextProvider(TextGroup src) => Default = src;

    protected TextGroup Default { get; }

    protected TextGroup Current { get => _current; }

    protected string Get([CallerMemberName] string name = null)
    {
        if (Current is not null && Current.TryGetValue(name, out var s0)) return s0;
        if (Default is not null && Default.TryGetValue(name, out var s1)) return s1;
        return name;
    }

    protected void Reset(Language src)
    {
        var dest = GetGroup(src);
        _ = Interlocked.Exchange(ref _current, dest);
    }

    protected abstract TextGroup GetGroup(Language src);

    private TextGroup _current;
}
