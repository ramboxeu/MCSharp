using System;
using System.Collections.Generic;
using System.IO;

namespace MCSharp.Source
{
    static class SourceFiles
    {
        static private HashSet<SourceFile> sources = new HashSet<SourceFile>();

        public static HashSet<SourceFile> GetSourceFiles() {
            return sources;
        }

        public static void AddSourceFile(SourceFile file) {
            sources.Add(file);
        }

        public static SourceFile GetSourceFile(SourceFile file) {
            SourceFile f;
            if (sources.TryGetValue(file, out f)) return f;
            else return null;
        }

        public static void GatherSourceFiles(string rootPath) {
            List<string> dirs = new List<string>(Directory.GetDirectories(rootPath));

            if (dirs.Count <= 0)
            {
                foreach (string path in Directory.GetFiles(Directory.GetCurrentDirectory()))
                {
                    if (Path.GetExtension(path) == ".mcs")
                    {
                        AddSourceFile(new SourceFile(
                            Path.GetFileNameWithoutExtension(path),
                            path
                        ));
                    }
                }
            }
            else
            {
                dirs.Add(rootPath);
                foreach (string dir in dirs)
                {
                    foreach (string path in Directory.GetFiles(dir))
                    {
                        if (Path.GetExtension(path) == ".mcs")
                        {
                            AddSourceFile(new SourceFile(
                                Path.GetFileNameWithoutExtension(path),
                                path
                            ));
                        }
                    }
                }
            }
        }
    }
}
