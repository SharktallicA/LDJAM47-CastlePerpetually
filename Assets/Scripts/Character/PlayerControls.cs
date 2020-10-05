//
// Author(s): Manhim (script), Khalid (Room code)

using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    private Room curRoom;
    private float horizontal;
    private float vertical;

    public float walkSpeed;
    Rigidbody2D rb;

    public Sprite doorClosed;
    public Sprite doorOpened; //replacing with the floor sprite

    /// <summary>
    /// How close the player needs to be to interact with
    /// something in the room.
    /// </summary>
    [SerializeField]
    private float range = 1f;

    [SerializeField] private LayerMask InteractableObjects;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public float GetRange()
    {
        return range;
    }

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
    /*
    private Door GetNearestDoor()
    {
        Door nearestDoor = null;
        TileBase tile = doors.GetTile(tiles.WorldToCell(transform.position)) as TileBase;
        float closestDist = range;

        if (tile.name.Contains("Door"))
        {
            Debug.Log("Got a door!");
            
        }

        return nearestDoor;
    }*/
    /*
    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        for (int yd = -1; yd <= 1; yd++)
        {
            for (int xd = -1; xd <=1; xd++)
            {
                Vector3Int doorPos = new Vector3Int(position.x + xd, position.y + yd, position.z);
                if (IsDoor(doorPos, tilemap))
                    tilemap.RefreshTile(doorPos);
            }
        }
    }
    private bool IsDoor(Vector3Int position, ITilemap tilemap)
    {
        TileBase tile = tilemap.GetTile(position);
        return (tile != null && tile == this);
    }
    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        tileData.sprite = doorClosed;
        for (int yd = -1; yd <= 1; yd ++)
        {
            for (int xd = -1; xd <= 1; xd++)
            {
                Vector3Int doorPos = new Vector3Int(position.x + xd, position.y + yd, position.z);
                if (IsDoor(doorPos, tilemap))
                    tileData.sprite = doorOpened;
            }
        }
    }*/

    void Start()
    {
        if (!curRoom) Destroy(this);
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
            //var curDoor = GetNearestDoor();
            var curDoor = false;
            if (curDoor)
            {
                //set tile to floor tile to open door
                
            }
            else
            {
                //change back to door tile to close door

                // If no door is found, try finding a task instead

                var curTask = GetNearestRoomTask();
                if (curTask != null)
                    curRoom.GiveTask(curTask);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void ChangeRoom(Room newRoom, Grid newTiles, Tilemap newDoors)
    {
        curRoom = newRoom;
        tiles = newTiles;
        doors = newDoors;
    }
}
