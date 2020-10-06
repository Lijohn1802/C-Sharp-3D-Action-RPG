using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelToLoad = "MainLevel";

	public SceneFader sceneFader;

	public void Play ()
	{
		sceneFader.FadeTo(levelToLoad);
		FindObjectOfType<AudioManager>().PlayPlayerSoundNotOne("ButtonClick");
		FindObjectOfType<AudioManager>().StopPlayerSound("MainMenuMusic");
		FindObjectOfType<AudioManager>().PlayPlayerSound("LevelSelectMusic");
	}

	public void Quit ()
	{
		FindObjectOfType<AudioManager>().PlayPlayerSoundNotOne("ButtonClick");
		Debug.Log("Exciting...");
		Application.Quit();
	}

}
