using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityProject1.Managers;

namespace UnityProject1.Controllers{
public class WallControllers : MonoBehaviour
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