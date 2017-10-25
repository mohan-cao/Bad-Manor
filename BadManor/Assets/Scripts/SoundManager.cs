using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    /// <inheritdoc />
    /// <summary>
    /// SoundManager manages sound effects and music</summary>
    [Serializable()]
    public class SoundManager : MonoBehaviour
    {
        private Dictionary<string, AudioSource> _efxSource = new Dictionary<string, AudioSource>()
            ; //Drag a reference to the audio source which will play the sound effects.

        public AudioSource MusicSource; //Drag a reference to the audio source which will play the music.
        public float BgmStart;
        public float BgmStop;
        private static SoundManager _instance = null; //Allows other scripts to call functions from SoundManager.
        private static int _counter = 0;
        [Range(0f, 1f)] public float BgmVolume = 0.05f;
        [Range(0f, 1f)] public float SoundVolume = 1;

        /// <summary>
        /// Unity hook called when object is instantiated.
        /// This method uses the singleton pattern.
        /// </summary>
        private void Awake()
        {
            //Check if there is already an instance of SoundManager
            if (_instance == null)
            {
                //if not, set it to this.
                _instance = this;
                MusicSource.volume = BgmVolume;
                StartCoroutine(loopSoundFromBeginningThenTheTwoPoints(MusicSource, BgmStart, BgmStop));
            }
            //If instance already exists:
            else if (_instance != this)
                //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
                Destroy(gameObject);

            //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// Overlayable sound clip playing.
        /// Returns a string indicating the clip that is playing
        /// Starts at position 0 by default, with max duration in seconds (duration = -1)
        /// </summary>
        /// <param name="clip">AudioClip to play</param>
        /// <param name="loop">Loop track (=false)</param>
        /// <param name="start">Start time</param>
        /// <param name="duration">Duration (=-1, until end)</param>
        /// <returns>name of sound clip</returns>
        public string PlaySound(AudioClip clip, bool loop = false, float start = 0, float duration = -1)
        {
            //Set the clip of our efxSource audio source to the clip passed in as a parameter.
            var n = (clip.name != "") ? clip.name : "" + (_counter++);
            if (_efxSource.ContainsKey(n))
            {
                if (_efxSource[n].isPlaying) return n;
                _efxSource[n].volume = SoundVolume;
                _efxSource[n].Stop();
                _efxSource[n].Play();
                return n;
            }
            var a = gameObject.AddComponent<AudioSource>();
            if (clip.loadState != AudioDataLoadState.Loaded)
                return null;
            a.volume = SoundVolume;
            a.clip = clip;
            a.loop = loop;
            if (!loop)
            {
                a.Play();
            }
            else
            {
                StartCoroutine(loopSound(a, start, Math.Min(clip.length, start + duration)));
            }
            _efxSource.Add(n, a);
            return n;
        }

        /// <summary>
        /// Sets background music to new AudioClip
        /// </summary>
        /// <param name="clip">AudioClip to replace current BGM</param>
        public void SetBgm(AudioClip clip)
        {
            if (MusicSource != null)
            {
                Destroy(MusicSource);
            }
            MusicSource = gameObject.AddComponent<AudioSource>();
            MusicSource.volume = BgmVolume;
            MusicSource.clip = clip;
            MusicSource.loop = true;
            MusicSource.Play();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clips"></param>
        /// <returns></returns>
        public string RandomizeSfx(params AudioClip[] clips)
        {
            //Generate a random number between 0 and the length of our array of clips passed in.
            var randomIndex = Random.Range(0, clips.Length);

            //Set the clip to the clip at our randomly chosen index.
            return PlaySound(clips[randomIndex]);
        }

        /// <summary>
        /// Stops audio if it's playing
        /// </summary>
        /// <param name="clip"></param>
        /// <returns>true if it's playing, false if it can't find audioclip.</returns>
        public bool StopAudioIfPlaying(string clip)
        {
            if (!_efxSource.ContainsKey(clip)) return false;
            _efxSource[clip].Stop();
            Destroy(_efxSource[clip]);
            _efxSource.Remove(clip);
            return true;
        }

        /// <summary>
        /// Loop a sound.
        /// </summary>
        /// <param name="audioSource">AudioSource to loop</param>
        /// <param name="start">Start point of loop</param>
        /// <param name="end">End point of loop</param>
        /// <returns>Yieldable generator</returns>
        public IEnumerator loopSound(AudioSource audioSource, float start, float end)
        {
            while (audioSource != null)
            {
                audioSource.time = start;
                audioSource.Play();
                yield return new WaitForSeconds(Math.Min(audioSource.clip.length, end) - start);
            }
        }

        /// <summary>
        /// Extends loopSound() with looping of sound from the beginning, then repeatedly from the two points.
        /// </summary>
        /// <param name="audioSource">AudioSource to be looped</param>
        /// <param name="start">Start point of loop</param>
        /// <param name="end">End point of loop</param>
        /// <returns>Yieldable generator</returns>
        public IEnumerator loopSoundFromBeginningThenTheTwoPoints(AudioSource audioSource, float start, float end)
        {
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
            yield return loopSound(audioSource, start, end);
        }

        /// <summary>
        /// Sets background music volume
        /// </summary>
        /// <param name="volume"></param>
        public void setBgmVolume(float volume)
        {
            BgmVolume = volume;
            MusicSource.volume = volume;
        }

        /// <summary>
        /// Sets all SFX volume
        /// </summary>
        /// <param name="volume"></param>
        public void setSoundVolume(float volume)
        {
            SoundVolume = volume;
            foreach (AudioSource audio in _efxSource.Values)
            {
                audio.volume = volume;
            }
        }
    }
}