using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHitGround : MonoBehaviour
{
    // implement this script to any objects that can be knocked down.
    public int scoreNumber;
    
    public bool isEnter = true;
    //check if object is dropped first time or not
    private bool isFirst = true;
    private void OnCollisionEnter(Collision objects)
    {
        if (objects.gameObject.tag == "Ground" && isEnter)
        {
            isEnter = false;
            //if the object got dropped more than one time, receive half of the score
            Score._instance.score += isFirst?scoreNumber:scoreNumber/2;
            Score._instance.npcScore += isFirst?scoreNumber:scoreNumber/2;
            if (Score._instance.score >= Score._instance.npcRunScore)
                GameObject.Find("NPC").GetComponent<Npc>().SetFindPos(transform.position);
            isFirst = false;
        }
    }
}

