using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts
{
    /// <summary>
    /// SoundManager will manage sound effects and music but for prototype this does nothing.</summary>
	public class SoundManager : MonoBehaviour 
	{
		private Dictionary<string,AudioSource> efxSource = new Dictionary<string,AudioSource>();                   //Drag a reference to the audio source which will play the sound effects.
		public AudioSource musicSource;                 //Drag a reference to the audio source which will play the music.
		public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.
		private static int counter = 0;

		void Awake ()
		{
			//Check if there is already an instance of SoundManager
			if (instance == null)
				//if not, set it to this.
				instance = this;
			//If instance already exists:
			else if (instance != this)
				//Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
				Destroy (gameObject);

			//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
			DontDestroyOnLoad (gameObject);
		}


		/**
		 * Overlayable sound clip playing
		 * Returns a string indicating the clip that is playing
		 */
		public string PlaySound(AudioClip clip, bool loop=false)
		{
			//Set the clip of our efxSource audio source to the clip passed in as a parameter.
			string n = (clip.name!=null&&clip.name!="")?clip.name:""+(counter++);
			AudioSource a = new AudioSource ();
			if (clip == null||clip.loadState != AudioDataLoadState.Loaded)
				return null;
			a.clip = clip;
			a.loop = loop;
			a.Play ();
			efxSource.Add(n,a);
			return n;
		}

		public void SetBGM(AudioClip clip){
			musicSource.clip = clip;
			musicSource.loop = true;
			musicSource.Play ();
		}

		/**
		 * Randomly select one out of an array of audio clips to play
		 * 
		 */
		public string RandomizeSfx (params AudioClip[] clips)
		{
			//Generate a random number between 0 and the length of our array of clips passed in.
			int randomIndex = Random.Range(0, clips.Length);

			//Set the clip to the clip at our randomly chosen index.
			return PlaySound(clips[randomIndex]);
		}

		/**
		 * Stops audio if it's playing
		 * If it's not playing, returns false
		 */
		public bool StopAudioIfPlaying(string clip){
			if (efxSource.ContainsKey (clip)) {
				efxSource [clip].Stop ();
				efxSource.Remove (clip);
				return true;
			}
			return false;
		}
	}
}
