using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SailBoatRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        float closestDistance = float.MaxValue;
        GameObject closestObject = null;
        foreach(WindZone zone in GameObject.FindObjectsOfType<WindZone>()) {
            float distance = Vector3.Distance(zone.transform.position, transform.position);
            if (distance < closestDistance) {
                closestDistance = distance;
                closestObject = zone.gameObject;
            }
        }
        this.transform.rotation = closestObject.transform.rotation;
    }
}
