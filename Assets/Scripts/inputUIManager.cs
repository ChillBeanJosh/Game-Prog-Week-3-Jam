using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class inputUIManager : MonoBehaviour
{

    public TextMeshProUGUI currentInputText; //Text for button press.
    public TextMeshProUGUI upcomingInputText; //Text for preview button press.

    public inputReader game; //Pattern creater script refrence.
    public int previewLength; //Value that determines how many inputs you are able to see ahead of time.

    void Start()
    {
        //HAVING THEM START OFF AS EMPTY STRINGS INSTEAD OF BEING UNDELCARED.
        currentInputText.text = "";
        upcomingInputText.text = "";
    }

    void Update()
    {

        if (game.InputPattern.Count > 0)
        {
            //WHILE THE INPUT PATTERN IS IN PROGRESS SETS THE CURRENT INPUT TEXT TO THAT SPECIFIC KEYCODE AT THE CURRENT INDEX TO A STRING SO THAT IT IS A TEXT.
            currentInputText.text = game.InputPattern[game.CurrentIndex].ToString();
            UpdateInputs(); //REFRESHES THE UPCOMING INPUTS SO THEY UPDATE REAL TIME.
        }
    }

    void UpdateInputs()
    {
        upcomingInputText.text = "";

        //FOR LOOP STARTING AT 1 SINCE IF WE START AT 0 IT WILL ALSO COUNT THE CURRENT INPUT.
        for (int i = 1; i <= previewLength; i++)
        {
            int nextIndex = game.CurrentIndex + i;

            //SHOWS THE PREVIEW OF THE UPCOMING INPUTS
            if (nextIndex < game.InputPattern.Count)
            {
                upcomingInputText.text += game.InputPattern[nextIndex].ToString() + " ";
            }
            //IN THE CASE THAT THE PATTERN IS REACHING LESS THAN THE PREVIEW LENGTH
            else
            {
                upcomingInputText.text += " - ";

            }
        }
    }
}
