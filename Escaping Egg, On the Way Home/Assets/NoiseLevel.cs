using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseLevel : MonoBehaviour
{
    public int noiseLevel = 0;
    private void OnCollisionEnter(Collision objects) {
    if (objects.transform.name == "mug" || objects.transform.name == "fork" || objects.transform.name == "knife" || objects.transform.name == "plate" || objects.transform.name == "cerealbox") {
            noiseLevel++;
            Debug.Log("Current Noise Level: " + noiseLevel);
        }   
    }
}
