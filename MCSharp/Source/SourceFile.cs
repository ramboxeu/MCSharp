using System;
using System.Collections.Generic;
using System.Text;

namespace MCSharp.Source
{
    class SourceFile
    {
        public string Name;
        public string Path;

        public SourceFile(string name, string path) {
            Name = name;
            Path = path;
        }
    }
}
