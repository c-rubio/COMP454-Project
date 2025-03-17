using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    public Animator animController;  // Assign in Inspector or find dynamically
    public Transform player;  // Reference to the player's Transform
    public float closeDistance = 3.0f;  // Distance threshold for proximity-based animation
    public float jumpDistance = 1.0f;

    private bool isClose = false;

    void Start()
    {
        if (animController == null)
        {
            animController = GetComponent<Animator>();  // Ensure Animator is assigned
        }

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;  // Find player by tag
        }
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(player.position, transform.position);

            if (distance <= closeDistance)
            {
                if (distance <= jumpDistance)
                {
                    animController.SetBool("isClose", false);
                    isClose = false;
                }
                else
                {
                    animController.SetBool("isClose", true);
                    isClose = true;  // Avoid repeated calls
                }
                
            }
            else if (distance > closeDistance && isClose)
            {
                animController.SetBool("isClose", false);
                isClose = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animController.SetBool("jumpTrigger", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animController.SetBool("jumpTrigger", false);
        }
    }
}
