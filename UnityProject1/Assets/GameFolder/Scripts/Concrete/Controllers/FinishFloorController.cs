using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityProject1.Managers;

namespace UnityProject1.Controllers{
public class FinishFloorController : MonoBehaviour
{
    [SerializeField] GameObject _finishLights;
    [SerializeField] GameObject _finishFireWorks;

    private void OnCollisionEnter(Collision other) 
    {
        PlayerController player = other.collider.GetComponent<PlayerController>();  

        if(player == null || !player.CanMove) return;

        //Eger obyekt(player) platformaya yuxaridan deyerse qalib olur
        if(other.GetContact(0).normal.y == -1)
        {
            // Fireworksler ve Isiqlar yanir
            // Debug.Log("asdas");
            _finishFireWorks.gameObject.SetActive(true);
            _finishLights.gameObject.SetActive(true);
            GameManager.Instance.MissionSuccess();
        }
        else
        {
            // Eger player platformanin sagina,soluna, asagisina deyerese Game Over olur
           GameManager.Instance.GameOver();
        }
        
    }

}
}
