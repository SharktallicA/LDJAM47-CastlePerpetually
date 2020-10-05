// Base class for room task implementations.
// Author(s): Khalid

using UnityEngine;

/// <summary>
/// Base class for room task implementations. Once implemented,
/// an empty GameObject with such script attached will need to be
/// made into a prefab so it can be inserted in Room's roomTasks[] field.
/// </summary>
[RequireComponent(typeof(DialogueTrigger))]
public class RoomTask : MonoBehaviour
{
    /// <summary>
    /// Name of room task. 
    /// </summary>
    [SerializeField]
    protected string taskName;

    /// <summary>
    /// Describes what the task is. 
    /// </summary>
    [SerializeField]
    protected string taskDesc;

    /// <summary>
    /// Changes when player finishes the tasks' specification.
    /// </summary>
    protected bool complete = false;

    /// <summary>
    /// RNG percentage chance for door success
    /// dice role.
    /// </summary>
    [SerializeField]
    protected int doorSuccessPct = 50;

    /// <summary>
    /// 
    /// </summary>
    protected DialogueTrigger diag;

    /// <summary>
    /// The actions this room task will perform once it is interacted
    /// with. This should be overriden like the following in your 
    /// derivative room task class:
    /// protected override void Payload() {}
    /// </summary>
    virtual protected void Payload()
    {
        diag.TriggerDialogue();
    }

    private void Start()
    {
        diag = GetComponent<DialogueTrigger>();
        //if (!diag) Destroy(this);
    }

    /// <summary>
    /// Initated this room task's dialogue and payload tasks.
    /// </summary>
    virtual public void Interact()
    {
        diag.dialogue.name = taskName;
        diag.dialogue.sentences = new string[1];
        diag.dialogue.sentences[0] = taskDesc;

        Payload();
    }

    /// <summary>
    /// Resets the room task. Use this when the player moves out of
    /// range of the task after triggering it. 
    /// </summary>
    public void Reset()
    {
        
    }

    /// <summary>
    /// Destroyss the room task instance. Use this when the player
    /// has completed the task.
    /// </summary>
    public void End()
    {
        Reset();
        Destroy(this);
    }

    /// <summary>
    /// Flags if the task has been completely successfully
    /// by the player.
    /// </summary>
    public bool IsComplete() { return complete; }

    /// <summary>
    /// Returns whether this task will result in a 'bad' door.
    /// Returns:
    /// - true if the door will lead to another room.
    /// - false if the door will lead to the start.
    /// - null if this task is due to run again.
    /// </summary>
    public bool? IsSuccess()
    {
        int rand = Random.Range(1, 100);

        if (rand <= doorSuccessPct)
            return true;
        else if (doorSuccessPct == 0)
            return null;
        else
            return false;
    }

    /// <summary>
    /// Returns the name of this room task.
    /// </summary>
    public string GetName() { return taskName; }
    
    /// <summary>
    /// Returns the description of this room task.
    /// </summary>
    public string GetDesc() { return taskDesc; }
}