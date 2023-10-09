using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private const string IS_DRIVING = "IsDriving";
    private Animator animator;
    private PlayerScript player;

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    private void Update()
    {
        animator.SetBool(IS_DRIVING, player.IsDriving());
    }
}
