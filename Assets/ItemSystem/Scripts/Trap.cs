using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trap : Item {


    [SerializeField]
    float rawDamage = 10;
    [SerializeField]
    GameObject model;


    public override void setupObject() {
        model.GetComponent<MeshRenderer>().enabled = false;
    }

    public override void Interact(GameObject playerObject) {
        HealthManager manager = playerObject.GetComponent<HealthManager>();
        if (manager != null) {
            model.GetComponent<MeshRenderer>().enabled = true;
            manager.SendMessageUpwards("Hit", rawDamage, SendMessageOptions.DontRequireReceiver);
        }
    }
}
