using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class OutroCinematic : MonoBehaviour
{
    // start at one cuase i'll
    // forget to match the indexing at 0
    int activeSceneNum = 1;

    [Header("Background")]
    public Image activeBackground;

    public Sprite oneBg;
    public Sprite twoBg;
    public Sprite threeBg;
    public Sprite fourBg;
    public Sprite fiveBg;
    public Sprite sixBg;
    public Sprite sevenBg;

    public Sprite creditsBg;

    [Header("Dialogue")]
    public Image dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public Image avatar;


    [Header("Chad Dialogue")]
    public Sprite chadDialogueBox;
    public Sprite chadCrying;
    public Sprite chadExcited;
    public Sprite chadDefault;
    public Sprite chadSad;
    public Sprite chadBuff;
    public Sprite chadSheepish;
    public Sprite chadSniffle;

    [Header("Filbert Dialogue")]
    public Sprite filbertDialogueBox;
    public Sprite filbertAnnoyed;
    public Sprite filbertAsleep;
    public Sprite filbertConfused;
    public Sprite filbertDetermined;
    public Sprite filbertDistantLook;
    public Sprite filbertHappy;
    public Sprite filbertSad;
    public Sprite filbertSigh;


    [Header("Misc.")]
    public Sprite blueDialogueBox;
    public Sprite purpleDialogueBox;
    public Sprite orangeDialogueBox;
    // avatars
    public Sprite randomCat;
    public Sprite excitedCat;
    public Sprite nervousCat;
    public Sprite cashierCat;

    private readonly float DEFAULT_DIALOGUE_TIME_S = 3.5f;
    private void Start()
    {
        StartCoroutine(StartOne());
    }

    private void HideDialogueBox ()
    {

        dialoguePanel.color = Color.clear;
        avatar.color = Color.clear;
        dialogueText.color = Color.clear;
    }

    private void ShowDialogueBox ()
    {
        dialoguePanel.color = Color.white;
        avatar.color = Color.white;
        dialogueText.color = Color.black;
    } 

    private void SetDialogueBox (Sprite img)
    {
        dialoguePanel.sprite = img;
    }

    private void SetBackgroundImage (Sprite img)
    {
        activeBackground.sprite = img;
    }

    private void SetAvatar (Sprite img)
    {
        avatar.sprite = img;
    }

    private void SetDialogueText (string txt)
    {
        dialogueText.text = txt;
    }

    private void FilbertSpeak (Sprite avatar, string text)
    {
        SetDialogueBox(filbertDialogueBox);
        SetAvatar(avatar);
        SetDialogueText(text);
    }

    private void ChadSpeak (Sprite avatar, string text)
    {
        SetDialogueBox(chadDialogueBox);
        SetAvatar(avatar);
        SetDialogueText(text);
    }

    private void CashierSpeak(string text)
    {
        SetDialogueBox(orangeDialogueBox);
        SetAvatar(cashierCat);
        SetDialogueText(text);
    }

    private IEnumerator StartOne ()
    {
        SetBackgroundImage(oneBg);
        HideDialogueBox();
        yield return new WaitForSeconds(2);
        ShowDialogueBox();
        ChadSpeak(chadDefault, "We made it... finally.");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);
        FilbertSpeak(filbertDetermined, "See... I told you...");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);
        SetBackgroundImage(twoBg);
        HideDialogueBox();
        yield return new WaitForSeconds(2);
        ShowDialogueBox();
        ChadSpeak(chadSheepish, "Thank you buddy, I honestly can't say it enough.");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);
        FilbertSpeak(filbertAnnoyed, "Not yet... we still have to wait in line.");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);
        ChadSpeak(chadDefault, "Dude! We have to go NOW.");
        yield return new WaitForSeconds(2.0f);
        SetBackgroundImage(threeBg);
        yield return new WaitForSeconds(2);
        SetBackgroundImage(fourBg);
        HideDialogueBox();
        yield return new WaitForSeconds(2);
        ShowDialogueBox();
        ChadSpeak(chadDefault, "I NEED THE-");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);
        // CASHIER
        CashierSpeak("Don't worry, we heard you were coming, anyone who's willing to go through all that trouble shouldn't have their efforts go to waste!");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);

        SetBackgroundImage(fiveBg);
        HideDialogueBox();
        yield return new WaitForSeconds(2);
        ShowDialogueBox();

        ChadSpeak(chadExcited, "Thank you so much!");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);
        HideDialogueBox();
        SetBackgroundImage(sixBg);

        yield return new WaitForSeconds(2);
        SetBackgroundImage(sevenBg);
        ShowDialogueBox();
        FilbertSpeak(filbertConfused, "No way... that was today?!");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);
        FilbertSpeak(filbertSigh, "Yeah... I'll just wait until the 3.0 comes out.");
        yield return new WaitForSeconds(4.0f);
        HideDialogueBox();
        SetBackgroundImage(creditsBg);
        yield return new WaitForSeconds(10.0f);
        // TODO:
        // Show credits
        SceneManager.LoadScene(0);
    }
}
