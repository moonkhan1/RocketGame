// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;
using UnityProject1.Managers;
using UnityProject1.Controllers;

namespace UnityProject1.Abstracts.Controllers{
public abstract class WallControllers : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        PlayerController player = other.collider.GetComponent<PlayerController>();

        // Divar ile toqqusan obyekt bos olmazsa(yeni player olarsa) oyun Game over dir
        if(player != null && player.CanMove)
        {
            GameManager.Instance.GameOver();
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
}
}