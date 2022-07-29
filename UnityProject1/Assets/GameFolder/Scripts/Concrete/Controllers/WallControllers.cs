using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityProject1.Controllers{
public class WallControllers : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        PlayerController player = other.collider.GetComponent<PlayerController>();

        // Divar ile toqqusan obyekt bos olmazsa(yeni player olarsa) oyunu yeniden baslat
        if(player != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
}
}