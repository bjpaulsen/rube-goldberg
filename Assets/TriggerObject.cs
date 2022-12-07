using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    [SerializeField] private CameraFollow camera;
    [SerializeField] private Transform newFollow;
    [SerializeField] private float newFOV = 30;
    [SerializeField] private bool onlyTriggerOnce = true;

    [SerializeField] private List<Transform> ignoreTargets;

    private bool triggeredBefore = false;

    public void OnTriggerEnter(Collider other)
    {
        if (ignoreTargets.Contains(other.transform))
        {
            return;
        }

        if (onlyTriggerOnce && triggeredBefore)
            return;
        
        camera.SwitchTo(newFollow, newFOV);
    }
}
