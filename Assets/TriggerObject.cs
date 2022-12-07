using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    [SerializeField] private CameraFollow camera;
    [SerializeField] private Transform newFollow;
    [SerializeField] private float newFOV = 30;
    [SerializeField] private bool onlyTriggerOnce = true;

    private bool triggeredBefore = false;

    public void OnTriggerEnter()
    {
        if (onlyTriggerOnce && triggeredBefore)
            return;
        
        camera.SwitchTo(newFollow, newFOV);
    }
}
