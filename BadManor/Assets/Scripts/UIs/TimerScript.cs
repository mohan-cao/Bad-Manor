using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// TimerScript is what handles the ticking timer in the game.</summary>
[Serializable()]  
public class TimerScript : MonoBehaviour
{

	/// <summary>
	/// The text field to update with current used time.</summary>
	public Text counterText;
	/// <summary>
	/// Time passed in minutes and seconds.</summary>
	public float seconds, minutes;
	
	/// <summary>
	/// On loading of GameMap the text field is grabbed.</summary>
	void Start ()
	{
		counterText = GetComponent<Text>() as Text; 
	}
	
	/// <summary>
	/// Every frame the text field in the game interface is updated with time take.</summary>
	void Update ()
	{
		minutes = (int) (Time.time / 60f);
		seconds= (int)(Time.time % 60f);
		counterText.text = "Playing for : " + minutes.ToString("00") + ":" + seconds.ToString("00");
	}
}
