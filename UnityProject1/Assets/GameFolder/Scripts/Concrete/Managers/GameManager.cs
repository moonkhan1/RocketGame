using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityProject1.Abstracts.Utilities;


namespace UnityProject1.Managers
{
    public class GameManager : SingletonThisObject<GameManager>
    {
        public event System.Action OnGameOver; // Player divarlara deyerse oyuncu kontrolu kesilir
        public event System.Action OnMissionSuccess; // Player finish platformasina deyrese oyuncu kontrolu kesilir

    private void Awake() 
    {
        SingletonThisGameObject(this);
        // SoundManager.Instance.PlayMusic(2);
    }

// SingletonThisObject in abstract classini ayrica yaratdigimiz ucun buna ehtiyac qalmir 
        // private void SingletonThisGameObject()
        // {
        //     if(Instance == null){
        //         // Buradaki ilk yaradilan GameManager obyektini buradaki THIS e menimsedirik
        //         Instance = this;
        //         DontDestroyOnLoad(this.gameObject);
        //     }
        //     else
        //     {
        //         // Eger Eyni sehnede bir GameObjectden birden cox yaradilmasina icaze vermesin
        //         Destroy(this.gameObject);
        //     }
        // }

        public void GameOver()
        {
            // Oyun Game Over olmayibsa Game Over ise dussun
            OnGameOver?.Invoke();
        }
        public void MissionSuccess()
        {
            // Oyun Game Over olmayibsa Game Over ise dussun
            OnMissionSuccess?.Invoke();
        }

        // Async metodlar normal metodlardan ferqli calisir, yeni daxilindeki proses bitmeden ondan sonraki her hansi bir metod calismaga baslaya biler

         public void LoadLevelScene(int levelIndex = 0)
         {
            StartCoroutine(LoadLevelSceneAsync(levelIndex));
         }
         private IEnumerator LoadLevelSceneAsync(int levelIndex)
         {
            SoundManager.Instance.StopMusic(2);
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + levelIndex);
            SoundManager.Instance.PlayMusic(1);
         }

         public void LoadMenuScene()
         {
            StartCoroutine(LoadMenuSceneAsync());
         }
         private IEnumerator LoadMenuSceneAsync()
         {
            SoundManager.Instance.StopMusic(1);
            yield return SceneManager.LoadSceneAsync("Menu");
            SoundManager.Instance.PlayMusic(2);

         }

         public void Exit()
         {
            Debug.Log("Exit Process on triggered");
            Application.Quit();
         }
    }
}

