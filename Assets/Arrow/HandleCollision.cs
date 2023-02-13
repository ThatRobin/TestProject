using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleCollision : MonoBehaviour {
    
    [SerializeField]
    float rawDamage = 10f;

    [SerializeField]
    float rotationSpeed = 2f;

    private void Update() {
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(transform.GetComponent<Rigidbody>().velocity, Vector3.up),
            Time.deltaTime * rotationSpeed
        );
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag.Equals("Enemy")) {
            collision.collider.SendMessageUpwards("Hit", rawDamage, SendMessageOptions.DontRequireReceiver);
        }
        if(!collision.gameObject.tag.Equals("Player")) {
            Destroy(this.gameObject);
        }
    }
}
