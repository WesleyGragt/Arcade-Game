using GXPEngine;

namespace arcade
{
    public class Conductor : GameObject
    {
        //music/Crystalline.mp3
        //music/drums.wav
        public Conductor()
        {
            SoundChannel song = new Sound("music/drums.wav", true, false).Play();
        }

        public float bpm = 70;
        public float crotchet;
        public float songposition;
        public float offset = 0.2f;
        public float pitch = 1.0f;
        public float lastbeat;
        int start = 0;

        float startTime;

        public void Update()
        {
            if (start == 0)
            {
                lastbeat = 0f;
                startTime = Time.time;
                crotchet = 60 / bpm;
                start++;
            }
            float elapsedTime = Time.time - startTime;
            songposition = (elapsedTime * pitch) - offset;
        }
    }
}
