using JobBoard.Models;
using System.Xml.Linq;

namespace JobBoard.Helpers
{
	public static class FileManager
	{
		public static string SaveFile(string root,string filename,IFormFile image)
		{
			string name = image.FileName;
			name = (name.Length > 64) ? name.Substring(name.Length - 64, 64) : name;
			name = Guid.NewGuid().ToString() + name;
			string savePath = Path.Combine(root, filename, name);
			using (FileStream fileStream = new FileStream(savePath, FileMode.Create))
			{
				image.CopyTo(fileStream);
			}
			return name;
		}


		public static void DeleteFile(string root, string filename,string image)
		{
			string deletepath = Path.Combine(root, filename, image);
			if (System.IO.File.Exists(deletepath))
			{
				System.IO.File.Delete(deletepath);
			}
		}
	
		
	}
}
