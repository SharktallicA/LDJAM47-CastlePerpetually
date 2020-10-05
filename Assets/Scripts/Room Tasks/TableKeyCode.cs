using UnityEngine;

public class TableKeyCode : RoomTask
{
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
                diag.dialogue.sentences[0] = "A book! is it magic?";
                diag.dialogue.sentences[1] = "There seems to be a code in amongst all the scribbles, I think it reads 52698";
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