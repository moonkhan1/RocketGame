using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityProject1.Managers;
using UnityProject1.Controllers;

namespace UnityProject1.UI
{
public class GameOverObject : MonoBehaviour
{
    [SerializeField] GameObject _gameOverPanel;

    private void Awake() {
        if(_gameOverPanel.activeSelf)
        {
            _gameOverPanel.SetActive(false);
        }
    }

    private void OnEnable() {
        GameManager.Instance.OnGameOver += HandleGameOver;
    }
    private void OnDisable() {
        GameManager.Instance.OnGameOver -= HandleGameOver;
    }

    private void HandleGameOver()
    {
        if(!_gameOverPanel.activeSelf)
        {
            _gameOverPanel.SetActive(true);
        }
    }
}
}
