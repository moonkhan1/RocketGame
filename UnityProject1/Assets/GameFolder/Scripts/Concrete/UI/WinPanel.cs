using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject1.Managers;


namespace UnityProject1.UI
{
public class WinPanel : MonoBehaviour
{
    public void NextLevelClicked()
    {
        GameManager.Instance.LoadLevelScene(1);
    }

    public void ExitMenuClicked()
    {
        GameManager.Instance.LoadMenuScene();
    }   
}
}