using System;
using System.Drawing;

namespace YourNameSpace
{
	public static class GlobalFunctions 
	{

		#region WinForms

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

		// Recolours all white pixels in an image to another specified colour, can be useful if you need to change multiple 
		// assets for theming app.
		// Can be easily edited so that its more customizable.
		public static Bitmap Recolour(string imageLocation, Color newColour)
        	{
        	    	using (Image originalImage = Image.FromFile(imageLocation))
        	    	{
        	    	    	Bitmap newImage = new Bitmap(originalImage);
			
        	    	    	for (int i = 0; i < originalImage.Height; i++)
        	    	    	{
        	    	    	    	for (int j = 0; j < originalImage.Width; j++)
        	    	    	    	{
        	    	    	    	    	if (newImage.GetPixel(j, i).R > 250 && newImage.GetPixel(j, i).G > 250 && newImage.GetPixel(j, i).B > 250)
        	    	    	    	    	{
        	    	    	    	    	    	newImage.SetPixel(j, i, newColour);
        	    	    	    	    	}
        	    	    	    	}
        	    	    	}
        	    	    	return newImage;
        	    	}
        	}
		
		// Algorithm utilises the SizeMode.CenterImage property on a PictureBox, so it accurately works out the proportion the 
		// image must be in order to not be squished.
        	// It also utilises the ResizeImage function (see below).
        	public static Bitmap CropImageCenter(string imageLocation, int amountDigitsToRound, PictureBox pictureBox1)
        	{
        	    	using (Image image = Image.FromFile(imageLocation))
        	    	{
        	    	    	// If the Width of the image is bigger than the height, then we know the sides will be cut off
        	    	    	if (pictureBox1.Width > image.Height)
        	    	    	{
        	    	    	    	// The algorithm works by making the height of the final image the same as the height of the PictureBox (this is different for width, see else statement), 
        	    	    	    	// but we first need to find out what the final width will be so the image doesn't come out as squished.
        	    	    	    	// This formula determines the number we need to multiply by to get an unstretched image
        	    	    	    	double multiplier = Math.Round((double)(pictureBox1.Height) / image.Height, amountDigitsToRound);
				
        	    	    	    	int newHeight = pictureBox1.Height;
        	    	    	    	// Apply that multiplier to the width to get the final width of the image
        	    	    	    	double newWidth = image.Width * multiplier;
				
        	    	    	    	return ResizeImage(image, Convert.ToInt32(Math.Round(newWidth, 0)), newHeight);
        	    	    	}
        	    	    	else
        	    	    	{
        	    	    	    	// Same as above, however the top and bottom will be cut instead, so we do the calucaltion around width instead.
        	    	    	    	double multiplier = Math.Round((double)(pictureBox1.Width) / image.Width, amountDigitsToRound);
				
        	    	    	    	double newHeight = image.Height * multiplier;
        	    	    	    	int newWidth = pictureBox1.Width;
				
        	    	    	    	return ResizeImage(image, newWidth, Convert.ToInt32(Math.Round(newHeight, 0)));
        	    	    	}
        	    	}
        	}

       		// Resizes an image with the given height and width.
       		// Courtesy of Nordic16 (https://github.com/nordic16)
       		public static Bitmap ResizeImage(Image img, int width, int height)
       		{
       		    	var destImage = new Bitmap(width, height);
		
       		    	using (Graphics graphics = Graphics.FromImage(destImage))
       		    	{
       		    	    	using (var wMode = new ImageAttributes())
       		    	    	{
       		    	    	    	var rect = new Rectangle(0, 0, width, height);
       		    	    	    	wMode.SetWrapMode(WrapMode.TileFlipXY);
       		    	    	    	graphics.DrawImage(img, rect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, wMode);
       		    	    	}
       		    	}
		
       		    	return destImage;
       		}
		
		// Switches a Panels content to a different UserControl. Handy if your app uses a paging system
		// Courtesy of Nordic16 (https://github.com/nordic16)
		public static void SwitchTo<T>(Panel Content, object[] args = null) where T : UserControl
        	{
        	    	Control topControl = Content.Controls[0];
	
			//Creates a new UserControl from T. 
			UserControl control = (UserControl)Activator.CreateInstance(typeof(T), args ?? new object[] { });
			control.Dock = DockStyle.Fill;
	
        	    	// If the window on the top is different:
        	    	if (topControl.GetType() != control.GetType())
        	    	{
        	   	     foreach (Control x in topControl.Controls) { x.Dispose(); }
        	   	     topControl.Dispose();
		
        	  	     Content.Controls.Clear();
        	  	     Content.Controls.Add(control);
        	   	}
        	}

		#endregion
	}
}
