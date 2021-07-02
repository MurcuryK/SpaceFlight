using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] GameObject cam;

    // Move object using accelerometer
    float speed = 10.0f;
    public float playerSpeed = 0.5f;

    private void Start()
    {

    }


    void Update()
    {
        Vector3 dir = Vector3.zero;

        // we assume that device is held parallel to the ground
        // and Home button is in the right hand

        dir.y = -Input.acceleration.y;
        dir.x = Input.acceleration.x;
        dir.z += playerSpeed;

        // clamp acceleration vector to unit sphere
        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        // Make it move 10 meters per second instead of 10 meters per frame...
        dir *= Time.deltaTime;

        // Move object
        transform.Translate(dir * speed);

        cam.transform.Translate(0, 0, dir.z * speed);
    }
}
