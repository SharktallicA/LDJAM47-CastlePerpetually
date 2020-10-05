using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManhimCharacterScript : MonoBehaviour
{
    [SerializeField]
    private GameObject doorOptions;

    [SerializeField]
    private GameObject HiddenWalls;
    [SerializeField]
    private GameObject HiddenFloors;

    int collisionCount = 0; //amount of times colliding the button
    int chances = 3;
    // Start is called before the first frame update

    void Update()
    {
        RefreshCollisionCount();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "DoorbuttonTilemap")
        {
            doorOptions.SetActive(false);
        }

        if (collision.gameObject.name == "HiddenButtonTilemap")
        {
            collisionCount++;
            Debug.Log(collisionCount);
            if (collisionCount == 8)
            {
                HiddenWalls.SetActive(false);
                HiddenFloors.SetActive(false);
            }
            else if (collisionCount <= 7 || collisionCount >= 9)
            {
                HiddenWalls.SetActive(true);
                HiddenFloors.SetActive(true);
            }
        }
    }

    void RefreshCollisionCount()
    {
        if (collisionCount >= 9)
        {
            if (Input.GetKey(KeyCode.R))
                collisionCount = 0;
        }
    }
}
