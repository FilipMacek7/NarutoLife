using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace NarutoLife
{
    class Sound
    {

        public bool HasAudio { get { return mediaPlayer.HasAudio; } }

        private MediaPlayer mediaPlayer = new MediaPlayer();

        public void Play(string filename)
        {         
            mediaPlayer.Open(new Uri(@"sounds/" + filename, UriKind.RelativeOrAbsolute));
            mediaPlayer.Play();
        }
        public void SetVolume(int volume)
        {
            mediaPlayer.Volume = volume / 100.0f;
        }

        public void Stop()
        {
            mediaPlayer.Stop();
        }
    }
}
