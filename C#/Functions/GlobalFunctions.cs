using System;
using System.Drawing;

namespace YourNameSpace
{
	public static class GlobalFunctions 
	{
		// Compresses an image to a certain size. CompressSize is used to determine by how much the image should be compressed
		// eg, if CompressSize = 2 then the resulting image will be half the size as the original.
		// Useful for resizing images to thumbnail/picturebox size and reducing memory used by project.
		public static Bitmap CompressImage(string ImageFilePath, int CompressSize)
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

        // Hides the scrollbars on a scrollable control (Panel can be swapped for a different control).
		// NOTE: Only works when the controls AutoScroll property is set to false.
		public static void HideScrollBars(Panel panel)
		{
			panel.VerticalScroll.Maximum = 0;
			panel.AutoScroll = false;
			panel.HorizontalScroll.Visible = false;
			panel.AutoScroll = true;
		}
	}
}