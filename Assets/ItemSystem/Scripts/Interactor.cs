using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    Transform actorCamera;
    LayerMask layerMask;

    [SerializeField]
    private float maxDistanceFromCamera = 10f;

    [SerializeField]
    private float maxInteractableDistance = 3f;
    private float distanceFromActor;

    void Start()
    {
        layerMask = ~LayerMask.GetMask(LayerMask.LayerToName(gameObject.layer));
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxInteractableDistance);
    }
}