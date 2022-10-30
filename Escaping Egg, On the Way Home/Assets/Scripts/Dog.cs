using System.IO.Pipes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dog : MonoBehaviour
{
    public Transform roadPos;
    public Transform nowPos;
    public Transform nextPos;
    public float speed;
    void Start()
    {
        nowPos = roadPos.GetChild(0);
        transform.position = nowPos.position;
        RandomMove();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.LookAt(nextPos);
        transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        if (Vector3.Distance(transform.position, nextPos.position) <= 0.5)
        {
            RandomMove();
        }
    }

    //randomly move in the level to look for player
    void RandomMove()
    {
        if (nextPos != null)
        {
            nowPos = nextPos;
        }
        int isNext = Random.Range(0, 3);
        if (isNext != 0)
        {
            if (nowPos != null && nowPos.childCount > 0)
            {
                int index = Random.Range(0, nowPos.childCount);
                nextPos = nowPos.GetChild(index);
            }
            else
            {
                nextPos = nowPos.parent;
            }
        }
        else
        {
            if (nowPos.parent == roadPos)
            {
                RandomMove();
                return;
            }
            nextPos = nowPos.parent;
        }
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
