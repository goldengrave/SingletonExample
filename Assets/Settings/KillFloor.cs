using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    public GameObject player;
    public Vector3 playerStartPos;
    public void Awake()
    {
        player = GameObject.Find("Player");
        playerStartPos = player.transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            player.transform.position = playerStartPos;
        }
    }
}
