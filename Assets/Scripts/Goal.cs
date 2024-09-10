using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Goal : MonoBehaviour
{
    public static UnityAction goalReached;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("here");
        goalReached();
    }

}
