using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchColor : MonoBehaviour
{
    [SerializeField] Color[] availableColors;
    [SerializeField] SpriteRenderer[] colorSlots;
    Camera cameraBg;

    [Header("Keyboard Inputs")]
    [SerializeField] KeyCode switchColorMode = KeyCode.Q;
    [SerializeField] KeyCode[] colorKeys;

    //Animation
    PlayerAnimation playerAnim;
    void Start()
    {
        cameraBg = Camera.main;
        playerAnim = GetComponent<PlayerAnimation>();
        InitColorSlots();
    }

    // Update is called once per frame
    void Update()
    {
        EnableColorMode();
    }

    private void InitColorSlots()
    {
        for (int i = 0; i < availableColors.Length; i++)
        {
            colorSlots[i].color = availableColors[i];
        }
    }

    private void EnableColorMode()
    {
        if (Input.GetKey(switchColorMode))
        {
            playerAnim.EnableUIColor(true);
            GetColorChosen();
        }
        else if (Input.GetKeyUp(switchColorMode))
        {
            playerAnim.EnableUIColor(false);
        }
    }

    void GetColorChosen()
    {
        if (Input.GetKeyDown(colorKeys[0]))
        {
            SetBackgroundColor(availableColors[0]);

        }
        else if (Input.GetKeyUp(colorKeys[1]))
        {
            SetBackgroundColor(availableColors[1]);
        }
        else if (Input.GetKeyDown(colorKeys[2]))
        {
            SetBackgroundColor(availableColors[2]);
        }
    }

    void SetBackgroundColor(Color color)
    {
        cameraBg.backgroundColor = color;
    }
}
