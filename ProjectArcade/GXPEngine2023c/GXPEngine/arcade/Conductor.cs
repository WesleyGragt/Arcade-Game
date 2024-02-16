using GXPEngine;

namespace arcade
{
    internal class Conductor : GameObject
    {
        SoundChannel song = new Sound("music/Crystalline.mp3", true, false).Play();
        
        public float bpm = 70;
        public float crotchet;
        public float songposition;
        public float offset = 0.2f;
        public float pitch = 1.0f;
        public float lastbeat;

        float startTime;
        void Start()
        {
            lastbeat = 0f;
            startTime = Time.time;
            crotchet = 60 / bpm;
        }

        void Update()
        {
            float elapsedTime = Time.time - startTime;
            songposition = (elapsedTime * pitch) - offset;
        }
    }
}
