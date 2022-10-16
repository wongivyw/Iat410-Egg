 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHitGround : MonoBehaviour
{
    // implement this script to any objects that can be knocked down.
    public GameObject terrain;
    public Score scr;
    private void OnCollisionEnter(Collision objects) {
        terrain = GameObject.Find("Terrain");
        scr = terrain.GetComponent<Score>();
        //score increase only when terrain collides with untagged objects 
        if (objects.gameObject.tag == "Ground" && gameObject.tag != "Hit"){
            scr.score++;
            //change object tag to hit
            gameObject.tag = "Hit";
            Debug.Log("An object hit the ground!");
            Debug.Log("Player Score: " + scr.score);
        }
    }
}
