using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator colorUIAnimator;
    
    public void EnableUIColor(bool enable)
    {
        colorUIAnimator.SetBool("ColorMode", enable);
    }
}
