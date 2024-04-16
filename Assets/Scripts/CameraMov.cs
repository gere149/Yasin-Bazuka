using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
<<<<<<< Updated upstream

public float speed = 3f;

void FixedUpdate()
    {


        transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);

=======

    public float speed = 3f;

    void FixedUpdate()
    {


        transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);

>>>>>>> Stashed changes
    }

}

