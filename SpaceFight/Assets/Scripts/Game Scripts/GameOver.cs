using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");

       if(other.gameObject.tag == "Obstacle")
        {
            Debug.Log("Obstacle");
            SceneManager.LoadScene("GameOver");
        }
    }
}
