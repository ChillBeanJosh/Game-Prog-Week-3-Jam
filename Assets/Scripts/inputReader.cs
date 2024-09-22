using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputReader : MonoBehaviour
{


    public KeyCode[] possibleInputs; //An array for possible inputs

    public List<KeyCode> InputPattern { get { return inputPattern; } } //public component for private List<KeyCode>
    private List<KeyCode> inputPattern; //The randomized pattern created based on the list of possible inputs.

    public int patternLength; //How long each pattern / # of inputs per pattern.

    public int CurrentIndex { get { return currentIndex; } } //public component for private int
    private int currentIndex = 0; //Tracks progress throughout inputPattern.

    public float score; //float for the score.
    public float waitTime; //float used for the amount of seconds of delay when putting the wrong input.

    private bool canInput = true; //bool toggle when an input is messed up working alongside the waitTime.

    public Animator enemyAnimator;
    public Animator playerAnimator;


    void Start()
    {
        inputPattern = new List<KeyCode>();
        CreatePattern();
    }


    void Update()
    {
        if (canInput)
        {
            CheckInput(); 
        }
    }


    void CheckInput()
    {
        //IF THE USER INPUTS THE CORRECT KEYCODE.
        if (Input.GetKeyDown(inputPattern[currentIndex]))
        {
            TriggerAnimation(inputPattern[currentIndex]);

            enemyAnimator.SetTrigger("isHit");
            score++;
            Debug.Log("Correct input your score is :" + score);
            currentIndex++;




            //WHEN THE PATTERN REACHES THE END, RESETS AND CREATES A NEW ONE CAUSING A LOOP.
            if (currentIndex >= inputPattern.Count)
            {
                //***
                currentIndex = 0;
                CreatePattern();
                //***
            }
        }
        else if (Input.anyKeyDown)
        {
            enemyAnimator.SetTrigger("isTaunt");
            Debug.Log("Wrong input, you cannot do anything for " + waitTime + " seconds");
            TriggerWrongInputAnimation();
            StartCoroutine(DisableInputs());
        }
    }

    IEnumerator DisableInputs()
    {
        canInput = false;
        yield return new WaitForSeconds(waitTime);
        canInput = true;

        //***
        currentIndex = 0;
        CreatePattern();
        //***
    }


    void CreatePattern()
    {
        inputPattern.Clear();

        //CREATES A FOR LOOP IN WHICH BASED ON THE PATTERN LENGTH, CHOOSES A RANDOM KEYCODE FROM POSSIBLE INPUTS, THEN ADDS IT TO THE ARRAY OF THE INPUT PATTERN, REPEATS UNTIL PATTERN LENGTH IS REACHED.
        for (int i = 0; i < patternLength; i++)
        {
            KeyCode randomKey = possibleInputs[Random.Range(0, possibleInputs.Length)];
            inputPattern.Add(randomKey); 
        }
    }


    void TriggerAnimation(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.W:
                playerAnimator.SetTrigger("PlayerUp");
                break;

            case KeyCode.S:
                playerAnimator.SetTrigger("PlayerDown");
                break;

            case KeyCode.A:
                playerAnimator.SetTrigger("PlayerLeft");
                break;

            case KeyCode.D:
                playerAnimator.SetTrigger("PlayerRight");
                break;
        }
    }


    void TriggerWrongInputAnimation()
    {
        playerAnimator.SetTrigger("WrongInput");
    }

}
