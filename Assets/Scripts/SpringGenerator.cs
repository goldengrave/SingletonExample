using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringGenerator : MonoBehaviour
{
    public GameObject springPrefab;
    public int springPointAmount;
    public float springSpacingX;
    public List<GameObject> springPointList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < springPointAmount; i++)
        {
            GameObject newSpringPoint = GameObject.Instantiate(springPrefab,transform.position,transform.rotation);
            newSpringPoint.transform.position += new Vector3(springSpacingX, 0, 0);
            if(i>0)
                newSpringPoint.GetComponent<SpringJoint2D>().connectedBody = springPointList[i-1].GetComponent<Rigidbody2D>();
            else
                newSpringPoint.GetComponent<SpringJoint2D>().connectedBody = springPrefab.GetComponent<Rigidbody2D>();
            springPointList.Add(newSpringPoint);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
