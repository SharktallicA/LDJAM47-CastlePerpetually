using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject[] doorOptions;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "InteractableLeverButton")
        {
            doorOptions[0].SetActive(false);
            doorOptions[1].SetActive(true);
        }

    }
}
