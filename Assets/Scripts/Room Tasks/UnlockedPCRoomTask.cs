// Room task implementation for unlocked PC
// Author: Khalid

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Room task implementation for unlocked PC in
/// Khalid's room.
/// </summary>
public class UnlockedPCRoomTask : RoomTask
{
    /// <summary>
    /// Flags that the room task has been 
    /// triggered.
    /// </summary>
    private bool start = false;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private InputField cmdInput;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private GameObject doors;

    protected override void Payload()
    {
        diag.TriggerDialogue();
        start = true;
    }

    private void ShowDialog()
    {
        if (start)
        {
            if (diag.IsFinished())
            {
                diag.dialogue.sentences = new string[2];
                diag.dialogue.sentences[0] = "It's a DOS machine and you type a command to list all files.";
                diag.dialogue.sentences[1] = "You see a program called \"dolphin.exe\" in the home directory. If you want to try running it, type the program name out.";
                diag.TriggerDialogue();
                start = true;
                cmdInput.gameObject.SetActive(true);
            }
        }
    }

    private void CheckInput()
    {
        if (cmdInput.text == "dolphin.exe")
        {
            diag.dialogue.sentences = new string[2];
            diag.dialogue.sentences[0] = "You've ran the program. It's probably a virus, but at least it's not your computer to worry about.";
            diag.dialogue.sentences[1] = "After a few seconds, you hear some clicks around the room. Strange.";
            diag.TriggerDialogue();
            complete = true;
            cmdInput.gameObject.SetActive(false);
            doors.SetActive(false);
        }
        else
            doorSuccessPct -= 10;
    }

    private void Update()
    {
        ShowDialog();
        CheckInput();
    }
}