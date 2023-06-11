using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchColor : MonoBehaviour
{
    [SerializeField] Color[] availableColors;
    [SerializeField] SpriteRenderer[] colorSlots;
    [SerializeField] PlayerMovement pm;

    [Header("Keyboard Inputs")]
    [SerializeField] KeyCode switchColorMode = KeyCode.Q;
    [SerializeField] KeyCode[] colorKeys;

    //Animation
    [SerializeField] PlayerAnimation playerAnim;
    [SerializeField] GameObject colorUI;
    void Start()
    {
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
            GetColorChosen();
            pm.enabled = false;
            colorUI.SetActive(true);
        }
        else if (Input.GetKeyUp(switchColorMode))
        {
            pm.enabled = true;
            colorUI.SetActive(false);
        }
    }

    void GetColorChosen()
    {
        if (Input.GetKeyDown(colorKeys[0]))
        {
            playerAnim.SetPlayerColor("red");
        }
        else if (Input.GetKeyUp(colorKeys[1]))
        {
            playerAnim.SetPlayerColor("orange");
        }
        else if (Input.GetKeyDown(colorKeys[2]))
        {
            playerAnim.SetPlayerColor("yellow");
        }
    }
}
