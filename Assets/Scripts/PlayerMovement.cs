using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Vector2 direction;
    private Animator animator;
    private bool moveUp = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        TakeInput();
        Move();
    }

    private void TakeInput()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow)){

            direction += Vector2.up;
            moveUp = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            direction += Vector2.left;
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {

            direction += Vector2.down;
            moveUp = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector2.right;
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        SetAnimatorMovement(direction);
    }

    private void SetAnimatorMovement(Vector2 direction)
    {
        //animator.SetLayerWeight(1, 1);
        animator.SetFloat("mov", direction.magnitude);
        animator.SetBool("movUp", moveUp);
    }
}
