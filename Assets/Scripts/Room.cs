// 
// Author(s): Khalid

using UnityEngine;

/// <summary>
/// 
/// </summary>
public class Room : MonoBehaviour
{
    /// <summary>
    /// Reference to player's game object.
    /// </summary>
    private GameObject player;

    /// <summary>
    /// Reference to UI element that displays room names.
    /// </summary>
    [SerializeField]
    private GameObject UI;

    /// <summary>
    /// Name of room.
    /// </summary>
    [SerializeField]
    private string roomName;

    /// <summary>
    /// Array of prefab'd room tasks.
    /// </summary>
    [SerializeField]
    private GameObject[] roomTasks;

    /// <summary>
    /// Reference to the currently-active room
    /// task. Will be null if no room task is active.
    /// </summary>
    private RoomTask curTask;

    public void Update()
    {
        // If a task is available, manage it its lifetime.
        if (curTask)
        {
            if (curTask.IsComplete())
            {
                curTask = null;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void GiveTask(RoomTask task)
    {
        if (curTask == null)
        {
            curTask = task;
            curTask.Interact();
        }
    }
}