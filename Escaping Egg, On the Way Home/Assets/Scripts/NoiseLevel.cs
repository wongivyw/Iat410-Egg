using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoiseLevel : MonoBehaviour
{
    public int noiseLevel = 0;
    public Text noiseLevelText;
    private void OnCollisionEnter(Collision objects) {
    if (objects.transform.name == "mug-1" 
        || objects.transform.name == "fork-1" 
        || objects.transform.name == "knife-1" 
        || objects.transform.name == "plate-1" 
        || objects.transform.name == "cereal-1"
        || objects.transform.name == "cereal-2"
        || objects.transform.name == "cereal-3"
        || objects.transform.name == "cereal-4"
        || objects.transform.name == "bowl-1"
        || objects.transform.name == "bowl-2"
        || objects.transform.name == "banana-1"
        || objects.transform.name == "banana-2"
        || objects.transform.name == "glass-1"
        || objects.transform.name == "glass-2"
        || objects.transform.name == "glass-3"
        || objects.transform.name == "glass-4"
        || objects.transform.name == "glass-5"
        || objects.transform.name == "glass-6"
        || objects.transform.name == "glass-7"
        || objects.transform.name == "glass-8"
        || objects.transform.name == "glass-9"
        || objects.transform.name == "glass-10"
        || objects.transform.name == "glass-11") 
        {
            noiseLevel++;
            Debug.Log("Current Noise Level: " + noiseLevel);
        }
    }
    void Update() 
    {
        //noiseLevelText.text = "Noise Level: " + noiseLevel.ToString("0");
    }
}