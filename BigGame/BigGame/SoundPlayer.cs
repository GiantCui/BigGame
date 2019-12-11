using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.DirectX.DirectSound;

namespace BigGame
{
    class SoundPlayer
    {   
        public static Device secDev = new Device();//设备对象 
        public static Form1 form;
        public static SecondaryBuffer secBuffer_run;
        static bool is_run = false;
        public static void play_BGM()
        {
            //播放背景音乐
            SecondaryBuffer secBuffer;
            secBuffer = new SecondaryBuffer(Properties.Resources.play_BGM, SoundPlayer.secDev);//创建辅助缓冲区
            secBuffer.Volume = -1000;
            secBuffer.Play(0, BufferPlayFlags.Looping);//设置缓冲区为默认播放 
        }

        public static void bang_BGM()
        {
            //开枪音效
            SecondaryBuffer secBuffer;
            secBuffer = new SecondaryBuffer(Properties.Resources.bang_1, SoundPlayer.secDev);//创建辅助缓冲区
            secBuffer.Volume = 0;
            secBuffer.Play(0, BufferPlayFlags.Default);//设置缓冲区为默认播放 
        }

        public static void run_BGM()
        {
            if (!is_run)
            {
                //跑步音效
                secBuffer_run = new SecondaryBuffer(Properties.Resources.run_bgm, SoundPlayer.secDev);//创建辅助缓冲区
                secBuffer_run.Volume = 0;
                secBuffer_run.Play(0, BufferPlayFlags.Default);//设置缓冲区为默认播放 
                is_run = true;
            }   
        }

        public static void stop_run()
        {
            is_run = false;
            secBuffer_run.Stop();
        }
    }
}
