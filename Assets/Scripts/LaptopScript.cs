﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class LaptopScript : MonoBehaviour, Assets.Scripts.Interactable
{
    public MovementScript player;
    public GameObject decisionCanvas;

    public Text firstClue1;
    public Text firstClue2;
    public Text firstClue3;

    public Text secondClue1;
    public Text secondClue2;
    public Text secondClue3;

    public void interact()
    {
        decisionCanvas.SetActive(true);
        player.DisableMovement();

        firstClue1 = GameObject.Find("First Clue 1").GetComponent<Text>();
        firstClue2 = GameObject.Find("First Clue 2").GetComponent<Text>();
        firstClue3 = GameObject.Find("First Clue 3").GetComponent<Text>();
        secondClue1 = GameObject.Find("Second Clue 1").GetComponent<Text>();
        secondClue2 = GameObject.Find("Second Clue 2").GetComponent<Text>();
        secondClue3 = GameObject.Find("Second Clue 3").GetComponent<Text>();

        firstClue1.text = "???";
        firstClue2.text = "???";
        firstClue3.text = "???";
        secondClue1.text = "???";
        secondClue2.text = "???";
        secondClue3.text = "???";

        Journal journal = FindObjectOfType<Journal>();
        for (int i = 0; i < journal.journal.Count; i++)
        {
            if (journal.journal[i].clueOwner.Equals("Gabriel"))
            {
                if(firstClue1.text.Equals("???"))
                {
                    firstClue1.text = "Clue 1: " + journal.journal[i].clueName;
                }
                else if (firstClue2.text.Equals("???"))
                {
                    firstClue2.text = "Clue 2: " + journal.journal[i].clueName;
                }
                else
                {
                    firstClue3.text = "Clue 3: " + journal.journal[i].clueName;
                }
            }
            else
            {
                if (secondClue1.text.Equals("???"))
                {
                    secondClue1.text = "Clue 1: " + journal.journal[i].clueName;
                }
                else if(secondClue2.text.Equals("???"))
                {
                    secondClue2.text = "Clue 2: " + journal.journal[i].clueName;
                }
                else
                {
                    secondClue3.text = "Clue 3: " + journal.journal[i].clueName;
                }
            }
        }
    }
}
