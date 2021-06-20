namespace Events
{
    public class MusicVolumeEvent
    {
        public readonly float volume;

        public MusicVolumeEvent(float volume)
        {
            this.volume = volume;
        }
    }
}