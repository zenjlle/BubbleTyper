using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ParagraphTyper : MonoBehaviour
{
    public GameObject endScreen;
    public GameObject typerDisplay;
    public GameObject gameOverScreen;

    public ParagraphWordBank wordBank = null;
    public TextMeshProUGUI wordOutput = null;

    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;

    public TextMeshProUGUI mistakes;
    public int mistakesCounter = 0;

    //
    public Animator animator;
    //

    //
    public Transform mistakeParent;
    public GameObject mistakeIcon;
    //
    void Start()
    {
        //
        ReturnWordIdle();
        //
        gameOverScreen.SetActive(false);
        SetCurrentWord();
    }

    private void SetCurrentWord()
    {
        currentWord = wordBank.GetWord();
        SetRemainingWord(currentWord);
    }

    private void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = remainingWord;
    }

    void Update()
    {
        CheckInput();
        mistakes.text = "Mistakes: " + mistakesCounter.ToString();
        isGameOver();
    }

    private void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if (keysPressed.Length == 1)
            {
                EnterLetter(keysPressed);
            }
        }
    }

    private void EnterLetter(string typedLetter)
    {
        if (IsCorrectLetter(typedLetter))
        {
            RemoveLetter();

            if (IsWordComplete())
            {
                SetCurrentWord();
            }
        }
        else
        {
            mistakesCounter++;
            //
            SpawnMistakePrefab();
            animator.SetBool("isWrongWord", true);
            Invoke("ReturnWordIdle", 0.15f);
            //
        }
    }


    private bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    private void RemoveLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }

    private bool IsWordComplete()
    {
        return remainingWord.Length == 0;
    }



    private void isGameOver()
    {
        if (mistakesCounter == 10)
        {
            typerDisplay.SetActive(false);
            gameOverScreen.SetActive(true);
        }
    }

    //
    public void ReturnWordIdle()
    {
        animator.SetBool("isWrongWord", false);
    }
    public void SpawnMistakePrefab()
    {
        Instantiate(mistakeIcon, mistakeParent);
    }
    //
}
