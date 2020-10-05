//Author: Manhim
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UnlockSideDoors : RoomTask
{
    public InputField inputPassword;
    public GameObject autoDoors;

    bool pcPower = false;

    protected override void Payload()
    {
        diag.TriggerDialogue();
        pcPower = true;
    }


    // Update is called once per frame
    void Update()
    {
        turnOnPC();
        passwordChecker();
        unlockOtherDoors();
    }

    void passwordChecker()
    {
        if (inputPassword.text == "2020")
        {
            Debug.Log("Password accepted.");
            complete = true;
            inputPassword.gameObject.SetActive(false);
        }
        else
            doorSuccessPct -= 10;
    }

    void turnOnPC()
    {

        if (pcPower)
        {
            if (diag.IsFinished())
            {
                diag.dialogue.sentences = new string[2];
                diag.dialogue.sentences[0] = "You must enter the password to unlock the next few doors.";
                diag.dialogue.sentences[1] = "Tips: The sign on the board...";


                diag.TriggerDialogue();
                pcPower = false;
            }
            inputPassword.gameObject.SetActive(true);
        }
    }
    void unlockOtherDoors()
    {
        if (complete)
            autoDoors.SetActive(false);
    }


}
