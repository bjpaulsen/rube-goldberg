using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float accelerationSpeed;

    private bool isAccelerating = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAccelerating)
        {
            this.GetComponent<Rigidbody>().AddForce(transform.right * accelerationSpeed, ForceMode.Acceleration);
            //isAccelerating = false;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "ground")
        {
            isAccelerating = true;
        }
    }
}
