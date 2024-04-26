using UnityEngine;
using System.Collections; 
public class AnimationOnClick : MonoBehaviour
{
    public Animator animator; 
    public string animationTriggerName = "hammer"; 
    private bool isCooldown = false;

  
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !isCooldown)
        {
            Debug.Log("Left click detected");

            animator.SetTrigger(animationTriggerName);

            Debug.Log($"Trigger {animationTriggerName} set");
;


        }
    }


}
