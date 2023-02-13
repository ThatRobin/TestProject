using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public enum Weapon {
        Gun,
        Bow
    };

    [SerializeField]
    private Weapon weapon = Weapon.Gun;
    
    [SerializeField]
    private GameObject weaponPrefab;
    


    SwitchPerspective perspective;
    [SerializeField]
    Transform pofTransform;
    Transform gunTransform;
    Transform cameraTransform;
    float range = 100f;

    [SerializeField]
    float rawDamage = 10f;
    [SerializeField]
    float speed = 10f;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        gunTransform = gameObject.transform.Find("PlayerGun");
        perspective = this.GetComponent<SwitchPerspective>();
    }

    void Update() {
        FireWeapon();
    }

    void FireWeapon() {
        if (Input.GetButtonDown("Fire1")) {
            cameraTransform = Camera.main.transform;

            if(weapon.Equals(Weapon.Gun)) {
                Ray ray;
                if (perspective.GetPerspective().Equals(SwitchPerspective.Perspective.First)) {
                    ray = new Ray(cameraTransform.position, cameraTransform.forward);
                } else {
                    ray = new Ray(gunTransform.position, gunTransform.forward);
                }

                RaycastHit raycastHit;

                if (Physics.Raycast(ray, out raycastHit, range)) {
                    if (raycastHit.transform != null) {
                        raycastHit.collider.SendMessageUpwards("Hit", rawDamage, SendMessageOptions.DontRequireReceiver);
                    }
                }
            } else if(weapon.Equals(Weapon.Bow)) {
                GameObject arrow = Instantiate(weaponPrefab, pofTransform.position, Quaternion.identity);

                
                if (perspective.GetPerspective().Equals(SwitchPerspective.Perspective.First)) {
                    arrow.transform.rotation = cameraTransform.rotation;
                    Rigidbody rb = arrow.GetComponent<Rigidbody>();
                    rb.velocity = cameraTransform.forward * speed;
                } else {
                    arrow.transform.rotation = this.transform.rotation;
                    Rigidbody rb = arrow.GetComponent<Rigidbody>();
                    rb.velocity = pofTransform.forward * speed;
                }

                
            }
            
        }
    }
}