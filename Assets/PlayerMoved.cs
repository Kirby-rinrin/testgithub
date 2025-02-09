using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoved : MonoBehaviour
{
    public Transform player;
    private Rigidbody rb;
    [SerializeField]
    private int MoveSpeed;
    [SerializeField]
    private float RotateSpeed;
    private Vector3 startPosi;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosi = player.position;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))    //ˆÚ“®
        {
            transform.position += transform.TransformDirection(Vector3.forward * MoveSpeed * Time.deltaTime);//(grounded)?==if(grouded) // dashSpeed : jumpSpeed  == true : false
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.TransformDirection(Vector3.back * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.TransformDirection(Vector3.left * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.TransformDirection(Vector3.right * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))//•ûŒü“]Š·
        {
            transform.Rotate(new Vector3(0, -RotateSpeed, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, RotateSpeed, 0));
        }
        if (transform.position.y < 0)       //“Þ—Ž‘Îô
        {
            Debug.Log(startPosi);
            transform.position = startPosi;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
