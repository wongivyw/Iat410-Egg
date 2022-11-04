using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Npc : MonoBehaviour
{
    private NavMeshAgent nav;
    private Vector3 findPos;
    private Vector3 startPos;

    public Animator farmerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        nav = GetComponent<NavMeshAgent>();
    }
    public float delayTime;
    private float t;
    private bool isFind = true;
    private Vector3 nextPos;
    // Update is called once per frame
    void Update()
    {
        if ((findPos - transform.position).magnitude <= 3f)
        {

            farmerAnimator.SetBool("isFarmerMoving", false);

            isFind = true;
            if (nextPos != Vector3.zero)
            {
                SetFindPos(nextPos);
                nextPos = Vector3.zero;
            }
            t += Time.deltaTime;
            if (t >= delayTime)
            {
                if (Score._instance.npcScore <= Score._instance.npcBackScore)
                    nav.SetDestination(startPos);
            }
        } else {
            farmerAnimator.SetBool("isFarmerMoving", true);

        }
    }

    public void SetFindPos(Vector3 pos)
    {
        if (isFind == false)
        {
            nextPos = pos;
        }
        else
        {
            findPos = pos;
            nav.SetDestination(pos);
            isFind = false;
        }
    }
    private bool isOpen = false;
    //open the door
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (other.gameObject.CompareTag("Door"))
        {
            if (isOpen) return;
            isOpen = true;
            other.gameObject.GetComponent<Animator>().SetTrigger("trigger");
        }
    }
    //close the door
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            isOpen = false;
        }
    }
}
