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
    void FixedUpdate()
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
            transform.GetChild(0).GetChild(4).gameObject.SetActive(true);
            isAccelerating = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        isAccelerating = false;
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}
