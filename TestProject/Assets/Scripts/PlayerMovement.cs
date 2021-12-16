using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Animator myAnimator;

    float horizontal;
    float vertical;

    [SerializeField]
    float speed = 2;

    [SerializeField]
    GameObject playerMesh;
    private void Awake()
    {
        myAnimator = playerMesh.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ManagePlayerMovement();
        FlipPlayer();
        ManageAnimations();
    }

    void ManagePlayerMovement()
    {
        horizontal = Input.GetAxis("Horizontal");
        Vector3 position = transform.position;
        position.x = position.x + 0.1f * horizontal * Time.deltaTime * speed * 10;
        transform.position = position;

    }

    void FlipPlayer()
    {
        if (horizontal > 0 && transform.rotation.y != 90) playerMesh.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        else if (horizontal < 0 && transform.rotation.y != -90) playerMesh.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
    }

    void ManageAnimations()
    {
        myAnimator.SetBool("isRunning", horizontal != 0);
    }
}
