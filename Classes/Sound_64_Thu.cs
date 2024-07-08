using System.Media;

namespace DoodleJump.Classes
{
    public class Sound_64_Thu
    {
        private bool offSound_64_Thu = false;

        private SoundPlayer eSound1_64_Thu = new SoundPlayer(Properties.Resources.jump);
        private SoundPlayer eSound2_64_Thu = new SoundPlayer(Properties.Resources.spring);
        private SoundPlayer eSound3_64_Thu = new SoundPlayer(Properties.Resources.jetpack);
        private SoundPlayer eSound4_64_Thu = new SoundPlayer(Properties.Resources.basic_throw);


        public bool OffSound_64_Thu
        {
            get { return offSound_64_Thu; }
            set { offSound_64_Thu = value; }
        }

        public SoundPlayer ESound1_64_Thu
        {
            get { return eSound1_64_Thu; }
        }
        public SoundPlayer ESound2_64_Thu
        {
            get { return eSound2_64_Thu; }
        }
        public SoundPlayer ESound3_64_Thu
        {
            get { return eSound3_64_Thu; }
        }
        public SoundPlayer ESound4_64_Thu
        {
            get { return eSound4_64_Thu; }
        }
    }
}
