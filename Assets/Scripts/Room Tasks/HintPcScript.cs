// Author: Sean
// Based from Khalids UnlockedPCRoomTask.cs script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintPcScript : RoomTask
{
    /// <summary>
    /// Flags that the room task has been 
    /// triggered.
    /// </summary>
    private bool? start = null;

    protected override void Payload()
    {
        diag.TriggerDialogue();
        start = true;
    }

    private void Update()
    {
        if (start == true)
        {
            if (diag.IsFinished())
            {
                diag.dialogue.sentences = new string[2];
                diag.dialogue.sentences[0] = "Scanning of room complete. 2 doors found within room";
                diag.dialogue.sentences[1] = "Logs: Mossy paths guide through the dark..";
                diag.TriggerDialogue();

                start = false;
            }
        }
        if (start == false)
        {
            complete = true;
        }
    }
}
