// 
// Author(s): Khalid

using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>
public class Room : MonoBehaviour
{
    /// <summary>
    /// Reference to player.
    /// </summary>
    [SerializeField]
    private PlayerControls player;

    /// <summary>
    /// Name of room.
    /// </summary>
    [SerializeField]
    private string roomName;

    /// <summary>
    /// Reference to the currently-active room
    /// task. Will be null if no room task is active.
    /// </summary>
    private RoomTask curTask;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Grid roomTiles;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Tilemap roomDoors;

    /// <summary>
    /// 
    /// </summary>
    private bool doorIsBad = false;

    /// <summary>
    /// 
    /// </summary>
    private void TaskComplete()
    {
        bool? doorSuccess = curTask.IsSuccess();
        curTask.End();

        if (doorSuccess == true || doorSuccess == false)
        {
            Destroy(curTask.gameObject);
            roomDoors.tag = "OpenDoor";

            if (doorSuccess == true)
                doorIsBad = false;
            else
                doorIsBad = true;
        }

        curTask = null;
    }

    public void Start()
    {
        if (!player) player = FindObjectOfType<PlayerControls>();
    }

    public void Update()
    {
        // If a task is available, manage it its lifetime.
        if (curTask)
        {
            if (curTask.IsComplete()) TaskComplete();
            else
            {
                // Check if player has moved out of range of the task.
                var playerPos = player.transform.position;
                var taskPos = curTask.transform.position;
                var dist = Vector2.Distance(playerPos, taskPos);

                if (dist > player.GetRange())
                {
                    curTask.Reset();
                    curTask = null;
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void GiveTask(RoomTask task)
    {
        Debug.Log(task);
        if (curTask == null)
        {
            curTask = task;
            curTask.Interact();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Grid GetTiles()
    {
        return roomTiles;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Tilemap GetDoors()
    {
        return roomDoors;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool GetIsDoorBad() { return doorIsBad; }
}