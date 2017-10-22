using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    /// <inheritdoc />
    /// <summary>
    /// SoundManager will manage sound effects and music but for prototype this does nothing.</summary>
	public class SoundManager : MonoBehaviour 
	{
		private Dictionary<string,AudioSource> _efxSource = new Dictionary<string,AudioSource>();                   //Drag a reference to the audio source which will play the sound effects.
		public AudioSource MusicSource;                 //Drag a reference to the audio source which will play the music.
		public float BgmStart;
		public float BgmStop;
		private static SoundManager _instance = null;     //Allows other scripts to call functions from SoundManager.
		private static int _counter = 0;

		private void Awake ()
		{
			//Check if there is already an instance of SoundManager
			if (_instance == null)
			{
				//if not, set it to this.
				_instance = this;
				StartCoroutine(loopSoundFromBeginningThenTheTwoPoints(MusicSource, BgmStart, BgmStop));
			}
			//If instance already exists:
			else if (_instance != this)
				//Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
				Destroy(gameObject);

			//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
			DontDestroyOnLoad (gameObject);
		}


		/**
		 * Overlayable sound clip playing
		 * Returns a string indicating the clip that is playing
		 * Starts at position 0 by default, with max duration in seconds (duration = -1)
		 */
		public string PlaySound(AudioClip clip, bool loop=false, float start=0, float duration=-1)
		{
			//Set the clip of our efxSource audio source to the clip passed in as a parameter.
			var n = (clip.name!="")?clip.name:""+(_counter++);
			if (_efxSource.ContainsKey(n))
			{
				if (_efxSource[n].isPlaying) return n;
				_efxSource[n].Stop();
				_efxSource[n].Play();
				return n;
			}
			var a = gameObject.AddComponent<AudioSource>();
			if (clip.loadState != AudioDataLoadState.Loaded)
				return null;
			a.clip = clip;
			a.loop = loop;
			if (!loop)
			{
				a.Play();
			}
			else
			{
				StartCoroutine(loopSound(a,start,Math.Min(clip.length,start+duration)));
			}
			_efxSource.Add(n,a);
			return n;
		}

		public void SetBgm(AudioClip clip){
			MusicSource.clip = clip;
			MusicSource.loop = true;
			MusicSource.Play ();
		}

		/**
		 * Randomly select one out of an array of audio clips to play
		 * 
		 */
		public string RandomizeSfx (params AudioClip[] clips)
		{
			//Generate a random number between 0 and the length of our array of clips passed in.
			var randomIndex = Random.Range(0, clips.Length);

			//Set the clip to the clip at our randomly chosen index.
			return PlaySound(clips[randomIndex]);
		}

		/**
		 * Stops audio if it's playing
		 * If it's not playing, returns false
		 */
		public bool StopAudioIfPlaying(string clip){
			if (!_efxSource.ContainsKey(clip)) return false;
			_efxSource [clip].Stop ();
			_efxSource.Remove (clip);
			return true;
		}

		public IEnumerator loopSound(AudioSource audioSource, float start, float end)
		{
			while (audioSource!=null)
			{
			audioSource.time = start;
			audioSource.Play();
			yield return new WaitForSeconds(Math.Min(audioSource.clip.length,end) - start);
			}
		}

		public IEnumerator loopSoundFromBeginningThenTheTwoPoints(AudioSource audioSource, float start, float end)
		{
			audioSource.Play();
			yield return new WaitForSeconds(audioSource.clip.length);
			yield return loopSound(audioSource, start, end);
		}
	}
}
