using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;
using System.Media;
using System.Diagnostics;

namespace Ghost
{
    class musica
    {
        public void musicafondo()
        {
            ConsoleKey consolekey = new ConsoleKey();
            WindowsMediaPlayer wplayer;
            wplayer = new WindowsMediaPlayer();
            wplayer.URL = @"musica2.mp3";

            if (consolekey == ConsoleKey.F5)
            {
                wplayer.controls.play();
            }
           
            
        }
    }
}
