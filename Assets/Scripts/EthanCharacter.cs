using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class EthanCharacter : MonoBehaviour
{
  private Animator animator;
  public Rigidbody rb;
  public float modifier = 1;
  public float jumpForce = 1;
  [Range(-2, 2)] public float speed = 0;
  private bool jump = false;


  void Awake()
  {
    animator = GetComponent<Animator>();
  }

  void Update()
  {
    float horizontal = Input.GetAxis("Horizontal");
    jump = (Input.GetKeyDown(KeyCode.Space)) ? true : false;

    //horizontal = speed;

    // //Set character rotation
    // float x = (horizontal < 0) ? 0 : 180;
    // Quaternion newRotation = Quaternion.Euler(x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    // transform.rotation = newRotation;

    //Set character animation
    animator.SetFloat("Speed", Mathf.Abs(horizontal));

    //move character
    transform.Translate(transform.right * horizontal * modifier* Time.deltaTime);
    
  }

  void FixedUpdate()
  {
    if (jump) rb.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
  }
}
