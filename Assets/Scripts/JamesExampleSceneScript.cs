using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Tilemaps;

public class JamesExampleSceneScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] doorOptions;
    [SerializeField]
    private GameObject[] colours;

    private GameObject changeColour;

    bool isColliding = false;
    bool clear = false;
    private void Update()
    {
        if (isColliding)
        {
            if (Input.GetButtonDown("Jump"))
            {
                colours[0].GetComponent<SpriteRenderer>().color += changeColour.GetComponent<SpriteRenderer>().color / 2;

                isColliding = false;
                changeColour = null;
            }

        }
        if (clear)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                colours[0].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
                clear = false;
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "InteractableTilemapButton")
        {
            doorOptions[0].SetActive(false);
            doorOptions[1].SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cauldron")
        {
            isColliding = true;
            changeColour = collision.gameObject;
        }
        if (collision.gameObject.name == "Cauldron_Reset")
        { 
            clear = true;
        }
    }
}
