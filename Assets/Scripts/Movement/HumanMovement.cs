using Unity.VisualScripting;
using UnityEngine;

public class HumanMovement : BaseMovement
{
    //normal humans don't die when stared at, they just stop
    public void StopStare()
    {
        Debug.Log("StopStare called, resuming movement and switching to walking animation.");
        speed = 2.5f;
        if (movementController != null)
        {
            animator.runtimeAnimatorController = movementController;
            animator.Play(0);
        }
    }
}
