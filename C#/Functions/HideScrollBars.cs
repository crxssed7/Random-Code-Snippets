using System;
using System.Windows.Forms;

namespace RWFCS
{
	public class RWFCS 
	{
		// Hides the scrollbars on a scrollable control (Panel can be swapped for a different control).
		// NOTE: Only works when the controls AutoScroll property is set to false.
		public void HideScrollBars(Panel panel)
		{
			panel.VerticalScroll.Maximum = 0;
			panel.AutoScroll = false;
			panel.HorizontalScroll.Visible = false;
			panel.AutoScroll = true;
		}
	}
}