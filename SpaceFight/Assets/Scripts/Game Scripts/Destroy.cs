using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");

        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
