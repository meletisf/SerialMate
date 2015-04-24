using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerialMate
{
    class consoleHelper
    {
        //Sets the console background color
        private Boolean setConsoleBGColor(Color selColor) //selColor = selected color
        {
            if (console.BackColor != selColor)
            {
                console.BackColor = selColor;
                Properties.Settings.Default.bg_color = selColor;
                Properties.Settings.Default.Save();
                return true;
            }
            return false;
        }

        //Sets the console foreground color
        private Boolean setConsoleFGColor(Color selColor) //selColor = selected color
        {
            if (console.BackColor != selColor)
            {
                console.ForeColor = selColor;
                Properties.Settings.Default.font_color = selColor;
                Properties.Settings.Default.Save();
                return true;
            }
            return false;
        }

        //Sets the console font size
        private Boolean setConsoleFSize(int selSize) //selSize = selected size
        {
            if (console.Font.Size != selSize)
            {
                console.Font = new Font("", selSize);
                Properties.Settings.Default.font_size = selSize;
                Properties.Settings.Default.Save();
                return true;
            }
            return false;
        }
    }
}
