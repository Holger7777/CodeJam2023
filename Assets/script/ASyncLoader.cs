using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ASyncLoader : MonoBehaviour
{
	[SerializeField] private GameObject loadingScreen;
	[SerializeField] private GameObject mainMenu;
	[SerializeField] private Slider slider;

	    public void GoNextScene(int SceneNum)
    {
		mainMenu.SetActive(false);
		loadingScreen.SetActive(true);
        
		StartCoroutine(LoadLevelAsync(SceneNum));

    }

	IEnumerator LoadLevelAsync(int SceneNum)
	{
		AsyncOperation loadOperation = SceneManager.LoadSceneAsync(SceneNum);
		
		while(!loadOperation.isDone)
		{
			
			float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
			slider.value = progressValue;
			yield return null;
		}
	}

}
