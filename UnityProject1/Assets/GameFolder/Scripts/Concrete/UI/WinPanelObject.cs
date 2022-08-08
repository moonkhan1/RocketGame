using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject1.Managers;

namespace UnityProject1.UI{
public class WinPanelObject : MonoBehaviour
{
    [SerializeField] GameObject _winConditionPanel;
    // Start is called before the first frame update
    private void Awake() {
        if(_winConditionPanel.activeSelf){
            _winConditionPanel.SetActive(false);
        }
    }
    private void OnEnable() {
        GameManager.Instance.OnMissionSuccess += HandleOnMissionSuccesed;
    }

    private void OnDisable() {
        GameManager.Instance.OnMissionSuccess -= HandleOnMissionSuccesed;
    }

    private void HandleOnMissionSuccesed()
    {
        if(!_winConditionPanel.activeSelf)
        {
            _winConditionPanel.SetActive(true);
        }
    }

}
}
