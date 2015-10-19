using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskReceiver.Plugin;

namespace TaskReceiver.Plugins.Nuernberger.MediaPlayer
{
    class WindowsMediaPlayer : IMediaPlayer
    {
        public string PluginName { get { return "WMP Control"; } }

        public string CommandTrigger { get { return "/music"; } }

        public void Execute(List<Tuple<string, string>> param)
        {
            switch (param[0].Item1)
            {
                case "playpause":
                {
                    PlayPause();
                    break;
                }
                case "stop":
                {
                    Stop();
                    break;
                }
                case "next":
                {
                    NextTitle();
                    break;
                }
                case "prev":
                {
                    PreviouseTitle();
                    break;
                }
                case "louder":
                {
                    IncreaseVolume();
                    break;
                }
                case "quieter":
                {
                    DecreaseVolume();
                    break;
                }
            }
        }

        public Int32 iHandle { get; set; }

        public WindowsMediaPlayer()
        {
            iHandle = Win32.FindWindow("WMPlayerApp", "Windows Media Player");
        }

        public void PlayPause()
        {
            Win32.SendMessage(iHandle, Win32.WM_COMMAND, 0x00004978, 0x00000000);
        }

        public void Stop()
        {
            Win32.SendMessage(iHandle, Win32.WM_COMMAND, 0x00004979, 0x00000000);
        }

        public void IncreaseVolume()
        {
            Win32.SendMessage(iHandle, Win32.WM_COMMAND, 0x0001497F, 0x00000000);
        }

        public void DecreaseVolume()
        {
            Win32.SendMessage(iHandle, Win32.WM_COMMAND, 0x00014980, 0x00000000);
        }

        public void SetVolume(int volume)
        {
            throw new NotImplementedException();
        }

        public void NextTitle()
        {
            Win32.SendMessage(iHandle, Win32.WM_COMMAND, 0x0001497B, 0x00000000);
        }

        public void PreviouseTitle()
        {
            Win32.SendMessage(iHandle, Win32.WM_COMMAND, 0x0001497A, 0x00000000);
        }
    }
}
