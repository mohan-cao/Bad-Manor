using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Assets.Scripts;

public class SoundMgrTest {

	[Test]
	public void SoundManagerTest()
	{
		//Arrange
		var gameObject = new GameObject();

		// Init a sound manager
		SoundManager smgr = gameObject.AddComponent<SoundManager>();
		smgr.MusicSource = new AudioSource ();
		smgr.ExecAwakeStartUpdate ();

		// Make an audio clip
		AudioClip a = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Resources/piano2.wav");

		//Play audio clip
		string key = smgr.PlaySound (a);
		Assert.AreEqual (key, "test");
	}
	
	[Test]
	public void SoundManagerStopTest()
	{
		//Arrange
		var gameObject = new GameObject();

		// Init a sound manager
		SoundManager smgr = gameObject.AddComponent<SoundManager>();
		smgr.MusicSource = new AudioSource ();
		smgr.ExecAwakeStartUpdate ();

		// Make an audio clip
		AudioClip a = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Resources/piano2.wav");

		//Play audio clip
		string key = smgr.PlaySound (a);
		Assert.AreEqual (key, "test");
		//Try stop audio clip
		bool wasPlaying = smgr.StopAudioIfPlaying ("test");
		Assert.IsTrue (wasPlaying);
	}

}