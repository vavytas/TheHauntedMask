using System;
using UnityEngine;
using System.Collections;


public class FootStepSoundPlayer : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip[] footstepClips;

    public float walkStepInterval = 0.5f;
    public float runStepInterval = 0.3f;
    public float minVelocity = 0.1f;
    private float stepTimer = 0.1f;

    [SerializeField] public Rigidbody2D rb;
    Coroutine footstepRoutine;

    void Update()
    {
        float speed = rb.linearVelocity.magnitude;

        bool isMoving = speed > minVelocity;
        if (isMoving )
        { stepTimer -= Time.deltaTime; }


        if (stepTimer <= 0f)
        {
            PlayFootstep();
            stepTimer = walkStepInterval;
        }
        //if (isMoving && footstepRoutine == null)
        //{
        //    footstepRoutine = StartCoroutine(FootstepLoop());
        //}
        //else if (!isMoving && footstepRoutine != null)
        //{
        //    StopCoroutine(footstepRoutine);
        //    footstepRoutine = null;
        //}
    }

    IEnumerator FootstepLoop()
    {
        while (true)
        {
            PlayFootstep();
            yield return new WaitForSeconds(walkStepInterval);
        }
    }

    float GetCurrentStepInterval()
    {
        float speed = rb.linearVelocity.magnitude;
        return speed > 4f ? runStepInterval : walkStepInterval;
    }

    void PlayFootstep()
    {
        if (footstepClips.Length == 0) return;

        audioSource.pitch = UnityEngine.Random.Range(0.85f, 1.15f);

        audioSource.panStereo = UnityEngine.Random.Range(-0.15f, 0.15f);
        AudioClip clip = footstepClips[UnityEngine.Random.Range(0, footstepClips.Length)];
        audioSource.PlayOneShot(clip);
    }
}
