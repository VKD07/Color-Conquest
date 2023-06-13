using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchColor : MonoBehaviour
{
    [SerializeField] Color[] availableColors;
    [SerializeField] SpriteRenderer[] colorSlots;
    [SerializeField] string[] animationParameters;
    [SerializeField] PlayerMovementScript pm;
    [SerializeField] public string currentColor;

    [Header("Keyboard Inputs")]
    [SerializeField] KeyCode[] colorKeys;
    [SerializeField] KeyCode switchColorMode = KeyCode.Q;

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
        //if (Input.GetKeyDown(colorKeys[0]))
        //{
        //    playerAnim.SetPlayerColor(animationParameters[0]);
        //}
        //else if (Input.GetKeyUp(colorKeys[1]))
        //{
        //    playerAnim.SetPlayerColor(animationParameters[1]);
        //}
        //else if (Input.GetKeyDown(colorKeys[2]))
        //{
        //    playerAnim.SetPlayerColor(animationParameters[2]);
        //}

        for (int i = 0; i < colorKeys.Length; i++)
        {
            if (Input.GetKeyDown(colorKeys[i]))
            {
                playerAnim.SetPlayerColor(animationParameters[i]);
                currentColor = animationParameters[i];
                ChangeLayerName(animationParameters[i]);
            }
        }
    }

    void ChangeLayerName(string layerName)
    {
        int newLayerIndex = LayerMask.NameToLayer(layerName);

        if (newLayerIndex != -1)
        {
            gameObject.layer = newLayerIndex;
        }
    }
}
