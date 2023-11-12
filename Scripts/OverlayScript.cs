using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayScript : MonoBehaviour
{
    private PlayerController _playerController;
    private Animator animator;


    // Start is called before the first frame update
    void Awake()
    {
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Animations();
    }

    private void Animations()
    {
        if(_playerController.isTurningLeft) animator.SetBool("Turning Left", true);
        else animator.SetBool("Turning Left", false);

        if(_playerController.isTurningRight) animator.SetBool("Turning Right", true);
        else animator.SetBool("Turning Right", false);
    }
}
