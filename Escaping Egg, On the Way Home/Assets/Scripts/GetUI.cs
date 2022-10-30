using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUI : MonoBehaviour
{
    public static bool IsGet = true;
    public bool isOpen;
    private GameObject currentObj;
    public Transform getPos;

    //the force player throwing an object
    public float focus;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("MainCamera").transform);
        }
        if (!IsGet)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Give();
            }
        }
    }

    //retrievable status
    public void OpenGet()
    {
        isOpen = true;
        this.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void CloseGet()
    {
        isOpen = false;
        this.GetComponent<SpriteRenderer>().enabled = false;

    }

    //pick up object
    public void Get(GameObject obj)
    {
        currentObj = obj;
        currentObj.GetComponent<Rigidbody>().isKinematic = true;
        currentObj.GetComponent<MeshCollider>().enabled = false;
        currentObj.GetComponent<ObjectHitGround>().isEnter = true;
        currentObj.transform.SetParent(getPos);
        var pos = currentObj.transform.localPosition;
        currentObj.transform.localPosition = new Vector3(pos.x, 0, pos.y);
        CloseGet();
        IsGet = false;
    }

    //drop object
    public void Give()
    {
        currentObj.transform.SetParent(null);
        currentObj.GetComponent<Rigidbody>().isKinematic = false;
        currentObj.GetComponent<MeshCollider>().enabled = true;
        var dir = getPos.position - transform.parent.parent.position;
        currentObj.GetComponent<Rigidbody>().AddForce(dir * focus);

        currentObj = null;
        IsGet = true;

    }
}
