using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using Core.Utilities;
using Manager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneManager : PersistentSingleton<SceneManager>
{
    public Scene[] scenes;
    private static string UI_SCENE = "UIScene";
    private static string TEST_SCENE = "TestScene";
    private static string TITLE_SCREEN_SCENE;

    public GameObject loadingScreen;
    public ProgressBarController progressBar;

    public List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    public float totalSceneLoadProgress;
    public float totalInitializationProgress;
    private void Awake()
    {
        // if (!UnityEngine.SceneManagement.SceneManager.GetSceneByName(UI_SCENE).isLoaded)
        // {
        //     UnityEngine.SceneManagement.SceneManager.LoadScene(UI_SCENE, LoadSceneMode.Additive);
        // }
        if (!UnityEngine.SceneManagement.SceneManager.GetSceneByName(TEST_SCENE).isLoaded)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(TEST_SCENE, LoadSceneMode.Additive);
        }
    }

    public void LoadGame()
    {
        loadingScreen.gameObject.SetActive(true);
        
        scenesLoading.Add(UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(TITLE_SCREEN_SCENE));
        scenesLoading.Add(UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(TEST_SCENE));

        StartCoroutine(GetSceneLoadProgress());
        StartCoroutine(GetTotalProgress());
    }

    public IEnumerator GetSceneLoadProgress()
    {
        for (int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                foreach (AsyncOperation operation in scenesLoading)
                {
                    totalSceneLoadProgress += operation.progress;
                }

                totalSceneLoadProgress = (totalSceneLoadProgress / scenesLoading.Count) * 100f;

                progressBar.Current = Mathf.RoundToInt(totalSceneLoadProgress);
                
                yield return null;
            }
        }
    }

    public IEnumerator GetTotalProgress()
    {
        float totalProgress = 0;

        while (InitializationManager.instance == null || !InitializationManager.instance.IsDoneInitializing())
        {
            if (InitializationManager.instance == null)
            {
                totalInitializationProgress = 0;
            }
            else
            {
                totalInitializationProgress =
                    Mathf.RoundToInt(InitializationManager.instance.InitializationProgress * 100f);
            }
            
            totalProgress = Mathf.Round((totalSceneLoadProgress + totalInitializationProgress) / 2f);

            progressBar.Current = Mathf.RoundToInt(totalProgress);

            yield return null;
        }
        
        loadingScreen.gameObject.SetActive(false);
    }
}
