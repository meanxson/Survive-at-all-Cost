using System;
using System.Collections;
using System.Collections.Generic;
using Client.Scripts.Player;
using UnityEngine;

public class LootBox : MonoBehaviour
{
    //TODO: Finish pickup
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Inventory inventory))
        {
            Debug.Log("Picked Up");
            Destroy(gameObject);
        }
    }
}
