using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UnityProject1.Managers
{
    public class GameManager : MonoBehaviour
    {
        public event System.Action OnGameOver;
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
    }
}

