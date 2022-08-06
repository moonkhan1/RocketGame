using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject1.Managers;

namespace UnityProject1.UI
{
public class MenuPanel : MonoBehaviour
{
    public void StartClicked()
    {
        GameManager.Instance.LoadLevelScene(1);
    }

    public void ExitClicked()
    {
        GameManager.Instance.Exit();
    }
   
}
}
