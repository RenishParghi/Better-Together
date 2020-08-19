using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacking : MonoBehaviour
{
    private Transform linkedPlayer;
    private Transform ourPlayer;

    void Start()
    {
        ourPlayer = transform.parent;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.name.Equals("Bar")) return;


        linkedPlayer = other.transform.parent;
        ourPlayer.parent = linkedPlayer;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.name.Equals("Bar")) return;
        if (linkedPlayer == null) return;
        if (other.transform.parent != linkedPlayer) return;


        linkedPlayer = null;
        ourPlayer.parent = null;
    }
    
}
