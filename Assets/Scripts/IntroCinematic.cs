using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroCinematic : MonoBehaviour
{
    // start at one cuase i'll
    // forget to match the indexing at 0
    int activeSceneNum = 1;

    [Header("Background")]
    public Image activeBackground;

    public Sprite oneFilbertsRoom;
    public Sprite twoLineOfCats;
    public Sprite threeShimmerBall;
    public Sprite fourSnorkel;
    public Sprite fiveSoldout;
    public Sprite sixBreakdown;
    public Sprite sevenLetsGo;

    public Sprite twoHoursLater;

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
    private IEnumerator WaitAndDo (float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback();
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

    private IEnumerator StartOne ()
    {
        SetBackgroundImage(oneFilbertsRoom);
        HideDialogueBox();
        yield return new WaitForSeconds(2);
        SetDialogueBox(chadDialogueBox);
        SetAvatar(chadExcited);
        ShowDialogueBox();
        SetDialogueText("Filbert, you're coming with me right now!");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);
        SetDialogueBox(filbertDialogueBox);
        SetAvatar(filbertAsleep);
        SetDialogueText("Chad...");
        yield return new WaitForSeconds(2);
        SetDialogueText("Chad... it's 4 in the morning...");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);
        SetDialogueBox(chadDialogueBox);
        SetAvatar(chadExcited);
        SetDialogueText("I know... We're already late! C'mon!");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);


        StartCoroutine(StartTwo());
    }

    private IEnumerator StartTwo ()
    {
        HideDialogueBox();
        SetBackgroundImage(twoLineOfCats);
        yield return new WaitForSeconds(2);
        ChadSpeak(chadExcited, "Sorry I took you out here, I just knew it'd be lame waiting in this line alone.");

        ShowDialogueBox();
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);
        FilbertSpeak(filbertAnnoyed, "Yeah thanks for that... I wouldn't mind if you told me what this line is for though.");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);

        StartCoroutine(StartThree());
    }

    private IEnumerator StartThree()
    {
        SetBackgroundImage(threeShimmerBall);
        HideDialogueBox();
        yield return new WaitForSeconds(1);
        ChadSpeak(chadExcited, "Dude. It's the Shimmerball 2000. Cutting edge tech, I've been waiting for this baby to come out for years!");
        ShowDialogueBox();
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);
        FilbertSpeak(filbertAnnoyed, "A toy? Chad, aren't you too old for that?");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);

        StartCoroutine(StartFour());
    }


    private IEnumerator StartFour()
    {
        SetBackgroundImage(fourSnorkel);
        HideDialogueBox();
        yield return new WaitForSeconds(2);
        ShowDialogueBox();
        ChadSpeak(chadExcited, "Don't say that. It's a dream dude. I don't get at you for your snorkel collection...you don't even go underwater!");
        yield return new WaitForSeconds(5.0f);
        FilbertSpeak(filbertSigh, "Ok ok, I understand. It's kind of cool seeing everyone so excited though.");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);
        // EXCEPTION
        SetBackgroundImage(twoLineOfCats);
        SetAvatar(randomCat);
        SetDialogueBox(orangeDialogueBox);
        SetDialogueText("Woot! Imma shimmer the heck out of that ball!");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);
        HideDialogueBox();
        SetBackgroundImage(twoHoursLater);
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);
        StartCoroutine(StartFive());
    }

    private IEnumerator StartFive ()
    {
        SetBackgroundImage(fiveSoldout);
        yield return new WaitForSeconds(2.0f);
        ShowDialogueBox();
        // EXCEPTION
        SetAvatar(nervousCat);
        SetDialogueBox(purpleDialogueBox);
        SetDialogueText("Sorry guys... Uhmm we're sold out. Uhh can you pass the news down?");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);
        ChadSpeak(chadSad, "what... Aw man...");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);
        FilbertSpeak(filbertAnnoyed, "Really? We've been here for hours!");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);
        // EXCEPTION
        SetAvatar(nervousCat);
        SetDialogueBox(purpleDialogueBox);
        SetDialogueText("Uhh I can't help you here, but I heard there's another shipment coming in at the other town.");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);

        StartCoroutine(StartSix());
    }

    private IEnumerator StartSix ()
    {
        SetBackgroundImage(sixBreakdown);
        HideDialogueBox();
        yield return new WaitForSeconds(2);
        ShowDialogueBox();
        ChadSpeak(chadSniffle, "I can't get there on time. The fastest way has a bunch of water and canyons. I can't swim or fly.");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);
        FilbertSpeak(filbertDetermined, "No, you can't, but I can. I'll help you get there!");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);
        ChadSpeak(chadSniffle, "Wait, really? You'd do that?");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);
        FilbertSpeak(filbertDistantLook, "Let's go Chad, you're coming with me.");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);

        StartCoroutine(StartSeven());
    }

    private IEnumerator StartSeven ()
    {
        SetBackgroundImage(sevenLetsGo);
        HideDialogueBox();
        yield return new WaitForSeconds(2);
        ShowDialogueBox();
        ChadSpeak(chadSniffle, "Are you sure dude? It's gonna be rough.");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);
        FilbertSpeak(filbertDistantLook, "It's dangerous sure, but you got me to start working out, so I'm sure we can do it.");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);
        ChadSpeak(chadBuff, "You know what? You're right, with the two of us, we CAN make it!");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);
        FilbertSpeak(filbertHappy, "Of course! We're best friends, you'll help me and I'll help you. Now let's go!");
        yield return new WaitForSeconds(DEFAULT_DIALOGUE_TIME_S);

        StartGame();
    }


    private void StartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
