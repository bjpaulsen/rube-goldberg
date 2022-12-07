using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    [SerializeField] private CameraFollow camera;
    [SerializeField] private Transform newFollow;

    public void OnTriggerEnter()
    {
        camera.SwitchTo(newFollow);
    }
}
