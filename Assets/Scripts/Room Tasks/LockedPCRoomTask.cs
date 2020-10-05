// Room task implementation for locked PCs
// Author: Khalid

/// <summary>
/// Room task implementation for locked PCs in
/// Khalid's room.
/// </summary>
public class LockedPCRoomTask : RoomTask
{
    protected override void Payload()
    {
        diag.TriggerDialogue();
        complete = true;
    }
}