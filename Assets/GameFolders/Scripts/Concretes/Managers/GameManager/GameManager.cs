﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float delayTime = 1;
    [SerializeField] int score;
    public static GameManager Instance { get;private set; }
    public event System.Action<bool> OnSceneChanged;
    public event System.Action<int> OnScoreChanged;

    private void Awake()
    {
        SingletonThisGameObject();
    }

    private void SingletonThisGameObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void LoadScene(int levelIndex=0)
    {
        StartCoroutine(LoadSceneAsync(levelIndex));
    }

    private IEnumerator LoadSceneAsync(int levelIndex)
    {
        yield return new WaitForSeconds(delayTime);

        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        yield return SceneManager.UnloadSceneAsync(buildIndex);

        SceneManager.LoadSceneAsync(buildIndex + levelIndex, LoadSceneMode.Additive).completed += (AsyncOperation obj) =>
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(buildIndex + levelIndex));
        };

        OnSceneChanged?.Invoke(false);
    }

    public void ExitGame()
    {
        Debug.Log("Exit clicked");
        Application.Quit();
    }

    public void LoadMenuAndUi(float delayLoadingTime)
    {
        StartCoroutine(LoadMenuAndUiAsync(delayLoadingTime));
    }
    private IEnumerator LoadMenuAndUiAsync(float delayLoadingTime)
    {
        yield return new WaitForSeconds(delayLoadingTime);
        yield return SceneManager.LoadSceneAsync("Menu");
        yield return SceneManager.LoadSceneAsync("Ui",LoadSceneMode.Additive);

        OnSceneChanged?.Invoke(true);
    }

    public void IncreaseScore(int score)
    {
        this.score += score;
        OnScoreChanged?.Invoke(this.score);
    }

}
