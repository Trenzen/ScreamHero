using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAnimator : MonoBehaviour
{
    [SerializeField] private Animator obstacleAnimator;

    void Update()
    {
        if(PlayerMovement.Fly == true)
        {
            obstacleAnimator.SetBool("IsFlying", true);
        }
        else
        {
            obstacleAnimator.SetBool("IsFlying", false);
        }
    }
}
