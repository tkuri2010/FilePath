using System;
using System.IO;

namespace Tkuri2010.Filepath.Xmp
{
    class Program
    {
        static void Main(string[] args)
        {
			var inputPath = (1 <= args.Length)
					? args[0]
					: Directory.GetCurrentDirectory();

			var filepath = Filepath.Parse(inputPath);
			Console.WriteLine($"input path = {filepath}");

			Console.WriteLine("=======================================================");
			Console.WriteLine($"     prefix : {filepath.Prefix}");
			Console.WriteLine($"is absolute?: {filepath.Absolute}");

			for (var i = 0; i < filepath.Items.Length; i++)
			{
				Console.WriteLine($"     item {i} : {filepath.Items[i]}");
			}

			Console.WriteLine("=======================================================");
			Console.WriteLine($"  last item : {filepath.LastItem}");
			Console.WriteLine($"    has ext?: {filepath.HasExtension}");
			Console.WriteLine($"  last item without ext: {filepath.LastItemWithoutExtension}");
			Console.WriteLine($"  extension : {filepath.Extension}");
        }
    }
}
