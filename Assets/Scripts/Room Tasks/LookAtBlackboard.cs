using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtBlackboard : RoomTask
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
        Blackboard();
    }

    void Blackboard()
    {
        if (start)
        {
            if (diag.IsFinished())
            {
                diag.dialogue.sentences = new string[1];
                diag.dialogue.sentences[0] = "What year is it now?";
                diag.TriggerDialogue();
                start = false;
            }
        }
    }
}
