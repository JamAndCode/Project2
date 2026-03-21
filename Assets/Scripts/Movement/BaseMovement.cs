using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    public float speed = 2.5f;
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip[] walking;
    public AudioClip stareSound;
    public RuntimeAnimatorController movementController;
    public RuntimeAnimatorController stareController;

    //start walking animation and sound
    void Awake()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
            Debug.LogError("HumanMovement requires an Animator component.");
        if (movementController != null)
            animator.runtimeAnimatorController = movementController; 
        InvokeRepeating("WalkingSound", 0f, 0.4f); 
    }

    //Continuous walking sound playing
    void WalkingSound()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = walking[Random.Range(0, walking.Length)];
        audioSource.Play();
    }

    //what the character does when stared at - stop moving, stop walking sound, switch to stare animation
    public virtual void StaredAt()
    {
        speed = 0;
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop(); 
        if (stareController != null)
        {
            animator.runtimeAnimatorController = stareController;
            animator.Play(0); 
        }
        AudioClip stareSound = GetStareSound();
        if (stareSound != null)
        {
            audioSource.PlayOneShot(stareSound);
        }
    }

    protected virtual AudioClip GetStareSound()
    {
        return stareSound;
    }

    //Keep the character moving forward at constant speed
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
