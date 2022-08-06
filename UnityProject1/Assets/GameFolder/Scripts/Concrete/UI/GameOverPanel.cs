using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject1.Managers;

namespace UnityProject1.UI
{
    
public class GameOverPanel : MonoBehaviour
{
    public void TryAgainClicked()
    {
        GameManager.Instance.LoadLevelScene();
    }

    public void ExitMenuClicked()
    {
        GameManager.Instance.LoadMenuScene();
    }    
}
}
