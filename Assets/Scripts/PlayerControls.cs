//
// Author(s): Manhim (script), Khalid (Room code)
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    private Room curRoom;
    private float horizontal;
    private float vertical;

    public float walkSpeed;
    Rigidbody2D rb;

    /// <summary>
    /// How close the player needs to be to interact with
    /// something in the room.
    /// </summary>
    [SerializeField]
    private float range = 1f;

    [SerializeField] private LayerMask InteractableObjects;

    /// <summary>
    /// Evaluates what the closest room task is.
    /// Returns:
    /// - null if no room task is in range.
    /// - RoomTask if one is found to be closest in range.
    /// are in range. 
    /// </summary>
    private RoomTask GetNearestRoomTask()
    {
        RoomTask closestTask = null;
        float closestDist = range;

        foreach (var task in FindObjectsOfType<RoomTask>())
        {
            var playerPos = transform.position;
            var taskPos = task.transform.position;
            var dist = Vector2.Distance(playerPos, taskPos);

            if (dist < closestDist)
            {
                closestTask = task;
                closestDist = dist;
            }
        }

        return closestTask;
    }

    private Door GetNearestDoor()
    {
        Door nearestDoor = null;
        TileBase tile = doors.GetTile(tiles.WorldToCell(transform.position));
        float closestDist = range;

        if (tile.name.Contains("Door"))
        {
            Debug.Log("Got a door!");
            //find closest door
        }

        return nearestDoor;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    [SerializeField]
    private Grid tiles;

    [SerializeField]
    private Tilemap doors;

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerInteraction();
    }

    private Vector2 GetPos()
    {
        return transform.position;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * walkSpeed, vertical * walkSpeed);
    }

    void PlayerMovement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void PlayerInteraction()
    {
        if (Input.GetKeyDown("space"))
        {
            // TODO: add door code - doors should be checked before
            // tasks. If both are in range, do door only
            var curDoor = GetNearestDoor();
            if (curDoor)
            {
                //set tile to floor tile to open door
                
            }
            else
            {
                //change back to door tile to close door

                // If no door is found, try finding a task instead

                var curTask = GetNearestRoomTask();
                curRoom.GiveTask(curTask);
            }
        }
    }
}
