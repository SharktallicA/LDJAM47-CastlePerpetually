// Author: Sean
// Based from Khalids UnlockedPCRoomTask.cs script
// and James' JamesExampleSceneScript.cs script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWallScript : RoomTask
{
    /// <summary>
    /// Flags that the room task has been 
    /// triggered.
    /// </summary>
    private bool? start = null;

    [SerializeField]
    private GameObject Wall;

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
                diag.dialogue.sentences = new string[1];
                diag.dialogue.sentences[0] = "Opening Passage";
                diag.TriggerDialogue();

                start = false;
                Wall.SetActive(false);
            }
        }
        
        if (start == false)
        {
            complete = true;
        }
    }
}
