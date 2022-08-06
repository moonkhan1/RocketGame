using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace UnityProject1.Managers
{
    public class GameManager : MonoBehaviour
    {
        public event System.Action OnGameOver; // Player divarlara deyerse oyuncu kontrolu kesilir
        public event System.Action OnMissionSuccess; // Player finish platformasina deyrese oyuncu kontrolu kesilir

        // static olmaq butun yaradilacaq GameManager instanceleri ucun eyni olmaq demekdi
        public static GameManager Instance { get; private set; }
        private void Awake() 
        {
            SingletonThisGameObject();
        }
        private void SingletonThisGameObject()
        {
            if(Instance == null){
                // Buradaki ilk yaradilan GameManager obyektini buradaki THIS e menimsedirik
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                // Eger Eyni sehende bir GameObjectden birden cox yaradilmasina icaze vermesin
                Destroy(this.gameObject);
            }
        }

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
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + levelIndex);
         }

         public void LoadMenuScene()
         {
            StartCoroutine(LoadMenuSceneAsync());
         }
         private IEnumerator LoadMenuSceneAsync()
         {
            yield return SceneManager.LoadSceneAsync("Menu");

         }

         public void Exit()
         {
            Debug.Log("Exit Process on triggered");
            Application.Quit();
         }
    }
}

