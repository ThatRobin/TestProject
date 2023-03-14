using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CCTVCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject player in players) {
            Vector3 viewPos = this.GetComponent<Camera>().WorldToViewportPoint(player.transform.position);
            if (viewPos.x >= 0 && viewPos.x <= 1) {

                if(viewPos.y >= 0 && viewPos.y <= 1) {

                    if(viewPos.z > 0 && viewPos.z < this.GetComponent<Camera>().farClipPlane) {

                        Debug.Log("On camera");

                    }
                }
            }
        }
        
    }
}
