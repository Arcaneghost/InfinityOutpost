using UnityEngine;
using System.Collections;

public class NextButtonScript : MonoBehaviour {


	void Update ()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene ("StoryBoard2");
	}
}
