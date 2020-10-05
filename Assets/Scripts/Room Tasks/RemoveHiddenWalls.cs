//Author: Manhim
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveHiddenWalls : RoomTask
{
    bool start = false;
    protected override void Payload()
    {
        diag.TriggerDialogue();
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        RemoveWalls();
    }
    void RemoveWalls()
    {
        if (start)
        {
            if (diag.IsFinished())
            {
                diag.dialogue.sentences = new string[3];
                diag.dialogue.sentences[0] = "2 x 2 + 2 x 2 = ?";
                diag.dialogue.sentences[1] = "The button is somewhere in this room...";
                diag.dialogue.sentences[2] = "You may press R to reset the counts.";

                diag.TriggerDialogue();
                start = false;
            }
        }
    }
}
