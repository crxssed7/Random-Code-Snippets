using System;
using System.Drawing;

namespace RWFCS
{
	public class RWFCS 
	{
		// Compresses an image to a certain size. CompressSize is used to determine by how much the image should be compressed
		// eg, if CompressSize = 2 then the resulting image will be half the size as the original.
		// Useful for resizing images to thumbnail/picturebox size and reducing memory used by project.
		public Bitmap CompressImage(string ImageFilePath, int CompressSize)
		{
			using (Image img = Image.FromFile(ImageFilePath))
			{
				Bitmap bmp = new Bitmap(img.Width / CompressSize, img.Height / CompressSize);
				using (Graphics g = Graphics.FromImage(bmp))
				{
					g.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height));
				}
				return bmp;
			}
		}
	}
}