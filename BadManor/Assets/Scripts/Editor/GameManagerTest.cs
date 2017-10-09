using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using NUnit.Framework;
using Assets.Scripts;

public class GameManagerTest {

	[Test]
	public void GameManagerStateTest(){
		var gameObj = new GameObject ();
		gameObj.AddComponentAndInit<GameManager> ();
		var gameManager = gameObj.GetComponent<GameManager> ();
		Assert.AreEqual (GameManager.GameState.TUTORIAL_1, gameManager.currentState ());
		gameManager.newState (GameManager.GameState.TUTORIAL_2);
		Assert.AreEqual (GameManager.GameState.TUTORIAL_2, gameManager.currentState ());
	}

	[Test]
	public void GameManagerStateTestInvalid(){
		var gameObj = new GameObject ();
		gameObj.AddComponentAndInit<GameManager> ();
		var gameManager = gameObj.GetComponent<GameManager> ();
		Assert.AreEqual (GameManager.GameState.TUTORIAL_1, gameManager.currentState ());
		gameManager.newState (GameManager.GameState.ACCUSE);
		Assert.AreEqual (GameManager.GameState.TUTORIAL_1, gameManager.currentState ());
	}

}
