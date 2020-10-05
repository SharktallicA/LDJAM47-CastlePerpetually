using UnityEngine;

public class BoxMover : MonoBehaviour
{
    public GameObject player;

    bool moving = false;

    private void Update()
    {
        if (moving == true)
        {
            transform.position = player.transform.position;

            if (Input.GetKeyDown("space"))
            {
                moving = false;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, player.transform.position) <= 0.5)
            {
                if (Input.GetKeyDown("space"))
                {
                    moving = true;
                }
            }
        }
    }
}
