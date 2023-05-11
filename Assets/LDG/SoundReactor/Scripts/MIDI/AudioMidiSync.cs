// Sound Reactor
// Copyright (c) 2018, Little Dreamer Games, All Rights Reserved
// Please visit us at littledreamergames.com

using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace LDG.SoundReactor
{
    public class AudioMidiSync : MonoBehaviour
    {
        #region Fields 

#if UNITY_EDITOR
        public bool debug = false;
        public bool logToConsole = false;
        public UnityEvent onPropertyChanged;
#endif

        private bool audioEnded = false;
        private bool midiEnded = false;

        private int prevSamples;
        private bool audioStarted = false;
        private bool syncImediately = false;
        #endregion

        #region Properties
        public bool AudioStarted
        {
            get
            {
                return audioStarted;
            }
        }

        [SerializeField]
        private AudioSource audioSource;
        public AudioSource AudioSource
        {
            get
            {
                return audioSource;
            }

            set
            {
                if(audioSource != value)
                {
                    audioSource = value;
                }
            }
        }

        [SerializeField]
        private MidiSource midiSource;
        public MidiSource MidiSource
        {
            get
            {
                return midiSource;
            }

            set
            {
                if (midiSource != value)
                {
                    midiSource = value;
                }
            }
        }

        [SerializeField]
        private MidiSource midiSourceDelayed;
        public MidiSource MidiSourceDelayed
        {
            get
            {
                return midiSourceDelayed;
            }

            set
            {
                if (midiSourceDelayed != value)
                {
                    midiSourceDelayed = value;
                }
            }
        }

        [SerializeField]
        private bool playOnAwake;
        public bool PlayOnAwake
        {
            get
            {
                return playOnAwake;
            }

            set
            {
                if (playOnAwake != value)
                {
                    playOnAwake = value;
                }
            }
        }

        [SerializeField]
        private bool loop = false;
        public bool Loop
        {
            get
            {
                return loop;
            }

            set
            {
                if (loop != value)
                {
                    loop = value;
                }
            }
        }

        [SerializeField]
        private float playbackSpeed = 1.0f;
        public float PlaybackSpeed
        {
            get
            {
                return playbackSpeed;
            }

            set
            {
                if (playbackSpeed != value)
                {
                    playbackSpeed = value;
                }
            }
        }

        [SerializeField]
        private float audioStartDelay = 0.0f;
        public float AudioStartDelay
        {
            get
            {
                return audioStartDelay;
            }

            set
            {
                if (audioStartDelay != value)
                {
                    audioStartDelay = value;
                }
            }
        }

        [SerializeField]
        private float startTime = 0;
        public float StartTime
        {
            get
            {
                return startTime;
            }

            set
            {
                if (startTime != value)
                {
                    startTime = value;
                }
            }
        }

        [SerializeField]
        private float syncThreshold = 0.03f;
        public float SyncThreshold
        {
            get
            {
                return syncThreshold;
            }

            set
            {
                if (syncThreshold != value)
                {
                    syncThreshold = value;
                }
            }
        }

        [SerializeField]
        private float audioDelay = 0.2f;
        public float AudioDelay
        {
            get
            {
                return audioDelay;
            }
            set
            {
                if (audioDelay != value)
                {
                    syncImediately = true;
                    audioDelay = value;
                }
            }
        }

        private bool isPlaying = false;
        public bool IsPlaying
        {
            get
            {
                return isPlaying && !EndReached;
            }
        }

        public bool AudioEnded
        {
            get
            {
                return audioEnded;
            }
        }

        public bool MidiEnded
        {
            get
            {
                return midiEnded;
            }
        }

        public bool EndReached
        {
            get
            {
                return (audioEnded && midiEnded);
            }
        }

        private bool isSyncing = false;
        public bool IsSyncing
        {
            get
            {
                return isSyncing;
            }
        }

        private float audioTime = 0.0f;
        public float AudioTime
        {
            get
            {
                return audioTime;
            }
        }
        #endregion

        #region MonoBehaviour
        void Start()
        {
            InitSources();

            if (playOnAwake)
            {
                Play();
            }
        }

        void Update()
        {
            if (!midiSource || !audioSource || !audioSource.clip || !midiSource.clip || isSyncing || !isPlaying) return;

            // sync MIDI with sound
            if (!EndReached)
            {
                // force set playback speed and loop since this class takes control of that.
                audioSource.pitch = playbackSpeed;
                audioSource.loop = false;

                if (midiSourceDelayed)
                {
                    midiSourceDelayed.speed = playbackSpeed;
                    midiSourceDelayed.loop = false;
                }

                midiSource.speed = playbackSpeed;
                midiSource.loop = false;

                // once these are set to true, keep them true. I do this because when the audio reaches the end
                // it jumps back in time for some reason. probably something to do with the audioSource.time
                // not actually being the correct time...according to the document.
                audioEnded = (!audioEnded) ? (audioSource.timeSamples >= audioSource.clip.samples) : audioEnded;

                // catch whether or not time jumps backwards. if it does, the audio reached the end of the track.
                if (prevSamples > audioSource.timeSamples) audioEnded = true;

                // since isPlaying returns true even though the audio has a start delay, we have to manually check
                // to see if the audio has started.
                if (prevSamples != audioSource.timeSamples)
                {
                    if (!audioStarted)
                    {
                        audioStarted = true;
                    }
                }

                // record if the midi has reached the end of the track
                midiEnded = (!midiEnded) ? (midiSource.time >= midiSource.clip.length) : midiEnded;

                // this section adjusts the MIDI speed to match the audio, but only if the audio hasn't ended
                if (!audioEnded)
                {
                    // get current time of the audio source
                    float audioSourceTime = audioSource.Time();

                    // adjusts the audioDelay by the current playbackSpeed
                    float adjustedAudioDelay = audioDelay + audioDelay * (playbackSpeed - 1.0f);

                    if (audioStarted)
                    {
                        audioTime += Time.deltaTime * playbackSpeed;

                        if (Mathf.Abs(audioSourceTime - AudioTime) > syncThreshold * playbackSpeed)
                        {
                            audioTime = audioSourceTime;
                        }
                    }

                    // mute the notes so they don't play if the audio hasn't started playing yet
                    if (midiSourceDelayed)
                    {
                        midiSourceDelayed.mute = (audioSourceTime <= startTime);
                    }

                    // get the difference between audio and MIDI time. a positive number means the audio
                    // is ahead of the MIDI. if the audio hasn't started yet then set to 0.0.
                    float diff = (audioSourceTime <= startTime) ? 0.0f : (audioSourceTime + audioStartDelay - adjustedAudioDelay) - midiSource.time;

                    //Debug.Log(audioTime + ", " + startTime + ", " + diff);
                    

                    // cause the midi to sync imediately. this will happen if the audioDelay has been set.
                    if(syncImediately && audioStarted)
                    {
                        syncImediately = false;

                        // seek to the proper time. seeking doesn't raise events.
                        midiSource.Seek(audioSourceTime + audioStartDelay - adjustedAudioDelay);

                        // seek the delayed midi too if it exists.
                        if (midiSourceDelayed && !midiEnded)
                        {
                            midiSourceDelayed.Seek(audioSourceTime - adjustedAudioDelay);
                        }
                    }
                    
                    if (diff > syncThreshold * playbackSpeed)
                    {
#if UNITY_EDITOR
                        if (logToConsole) Debug.Log(string.Format("advancing MIDI by: {0}, audio time: {1}, delayed midi time {2}, midi time {3}", diff, audioSourceTime - adjustedAudioDelay, midiSourceDelayed.time, midiSource.time));
#endif

                        // if the MIDI is behind the audio, advance the MIDI
                        // setting the time ensures that the MIDI events will still trigger which is what
                        // we want. if we had used Seek, then events would be skipped.
                        midiSource.time = audioSourceTime + audioStartDelay - adjustedAudioDelay;

                        if (midiSourceDelayed && !midiEnded)
                        {
                            midiSourceDelayed.time = audioSourceTime - adjustedAudioDelay;
                        }
                    }

                    if (diff < -syncThreshold * playbackSpeed)
                    {
#if UNITY_EDITOR
                        if (logToConsole) Debug.Log(string.Format("slowing down MIDI by: {0}", diff));
#endif

                        // if the MIDI is ahead of the audio, set the speed of the midi to 0 for this frame.
                        // this will happen once per frame until the midi is within the sync threshold.
                        midiSource.speed = 0.0f;

                        if (midiSourceDelayed)
                        {
                            midiSourceDelayed.speed = 0.0f;
                        }
                    }
                }

                prevSamples = audioSource.timeSamples;
            }

            // replay if loop is set to true and the sequence has ended
            if (loop && EndReached)
            {
                Play();
            }
        }
        #endregion

        #region Public Methods
        public void Pause()
        {
            if (isSyncing) return;
            
            if (audioSource) audioSource.Pause();
            if (midiSource) midiSource.Pause();
            if (midiSourceDelayed) midiSourceDelayed.Pause();
        }

        public void UnPause()
        {
            if (isSyncing) return;

            if (audioSource)
            {
                // audioSource.UnPause does not unpause if PlayDelayed was used to play the audio, instead it starts playing emidiately.
                // because of this the audio has to be stopped and PlayDelayed must be called again by the remaining delay.
                if (midiSource.time - audioStartDelay + audioDelay < 0.0f)
                {
                    audioSource.Stop();
                    audioSource.PlayDelayed(Mathf.Abs(midiSource.time - audioStartDelay + audioDelay));
                }
                else
                {
                    audioSource.UnPause();
                }
            }

            if (midiSource) midiSource.UnPause();
            if (midiSourceDelayed) midiSourceDelayed.UnPause();
        }

        public void Play()
        {
            isPlaying = true;

            if (midiSource.isPaused)
            {
                UnPause();
            }
            else
            {
                // setting this to true will ensure that nothing gets processed in the Update function
                isSyncing = true;

                audioEnded = false;
                midiEnded = false;
                audioStarted = false;

                InitSources();

                if (midiSource && audioSource)
                {
                    // sync the midi with the audio. this has to be a coroutine because the audio doesn't always
                    // start right away, so the coroutine will loop until the audio has started, then it will
                    // play the audio and midi together.
                    StartCoroutine("SyncMidiWithAudio", startTime);
                }
            }
        }

        public void Stop()
        {
            if (audioSource) audioSource.Stop();
            if (midiSource) midiSource.Stop();
            if (midiSourceDelayed) midiSourceDelayed.Stop();

            audioEnded = false;
            midiEnded = false;

            isPlaying = false;
            isSyncing = false;
        }
        #endregion

        #region Private Methods
        private void InitSources()
        {
            if (!audioSource) audioSource = GetComponent<AudioSource>();
            if (!midiSource) midiSource = GetComponent<MidiSource>();

            // disable these because this script utilizes it's own playOnAwake
            if (audioSource) audioSource.playOnAwake = false;
            if (midiSource) midiSource.playOnAwake = false;
            if (midiSourceDelayed) midiSourceDelayed.playOnAwake = false;
        }

        public void ClearClips()
        {
            if(AudioSource)
            {
                AudioSource.clip = null;
            }

            if (MidiSource)
            {
                MidiSource.clip = null;
            }

            if (MidiSourceDelayed)
            {
                MidiSourceDelayed.clip = null;
            }
        }

        IEnumerator PrimeAudio(float startTime)
        {
            // prep the audio source before we officially play it. the audio source has a tendancy
            // to pop or miss samples when it is played for the very first time. to get around that we
            // force play it while muted. then we enumerate until the timeSamples increase,
            // and when it has, we know that the audio file will play from the start like it's supposed to.
            audioSource.Stop();
            audioSource.mute = true;
            audioSource.time = startTime;
            audioSource.Play();

            // yield here until the audio starts to play
            while (audioSource.timeSamples == 0)
            {
#if UNITY_EDITOR
                if (logToConsole) Debug.Log("waiting on audio");
#endif
                yield return null;
            }

            // officially play the audio file.
            audioSource.Stop();
            audioSource.mute = false;
            audioSource.time = startTime;

            // record the previus samples. audio clips do this thing where it jumps back in time
            // after it reaches the end of the audio. this variable is used to help us determine when
            // this happens so we know when NOT to rely on the audioSource.timeSamples.
            prevSamples = audioSource.timeSamples;
        }

        IEnumerator SyncMidiWithAudio(float startTime)
        {
            audioTime = startTime;

            // audio takes a little time to start up, so prime it, that way it'll play right away in the following lines of code
            yield return PrimeAudio(startTime);

            midiSource.Seek(startTime - audioDelay);

            if (midiSourceDelayed)
            {
                midiSourceDelayed.Seek(midiSource.time - audioStartDelay);
            }

            // play the audio and MIDI while also accounting for delay.
            audioSource.PlayDelayed(Mathf.Max(0, audioStartDelay / playbackSpeed));

            midiSource.Play();

            // play delayed midi if it's attached
            if (midiSourceDelayed)
            {
                midiSourceDelayed.Play();
            }

            // reset tracking variables
            audioEnded = false;
            midiEnded = false;

            // allow the Update function to continue processing again.
            isSyncing = false;
        }
        #endregion
    }
}