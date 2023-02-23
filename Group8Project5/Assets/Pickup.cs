using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isWinItem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isWinItem)
            {
                other.GetComponent<GameController>().coffeeAmmount += 20;
                Destroy(gameObject);
            } else
            {
                other.GetComponent<GameController>().Win();
                Destroy(gameObject);
            }
        }
    }
}
