﻿//Released under the MIT License.
//
//Copyright (c) 2015 Ntreev Soft co., Ltd.
//
//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
//documentation files (the "Software"), to deal in the Software without restriction, including without limitation the 
//rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit 
//persons to whom the Software is furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all copies or substantial portions of the 
//Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE 
//WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR 
//COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR 
//OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ntreev.Library.Psd.Readers.LayerResources
{
    [ResourceID("shmd")]
    class shmdResource : LazyResourceDataReader, IResourceBlock
    {
        public shmdResource(PsdReader reader, long length)
            : base(reader, length)
        {
        }

        public string ID
        {
            get
            {
                var attrs = typeof(shmdResource).GetCustomAttributes(typeof(ResourceIDAttribute), true);
                ResourceIDAttribute attr = attrs.First() as ResourceIDAttribute;
                return attr.ID;
            }
        }

        protected override void ReadData(PsdReader reader, object userData)
        {
            int count = reader.ReadInt32();

            List<StructureDescriptor> dss = new List<StructureDescriptor>();

            for (int i = 0; i < count; i++)
            {
                string s = reader.ReadAscii(4);
                string k = reader.ReadAscii(4);
                var c = reader.ReadByte();
                var p = reader.ReadBytes(3);
                var l = reader.ReadInt32();
                var p2 = reader.Position;
                var ds = new StructureDescriptor(reader);
                dss.Add(ds);
                reader.Position = p2 + l;
            }

            //props["Items"] = dss;
        }
    }
}
