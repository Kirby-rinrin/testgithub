using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoved : MonoBehaviour
{
    public Transform player;
    private Rigidbody rb;
    [SerializeField]
    private int MoveSpeed;
    [SerializeField]
    private float RotateSpeed;
    [SerializeField]
    private float jumpPower;
    private Vector3 startPosi;
    private bool grounded;
    public static bool creativity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosi = player.position;
        creativity = false;
        Debug.Log("not creativity!");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeCreativity();
        }
        if (!creativity)
        {
            rb.useGravity = true;
            if (Input.GetKey(KeyCode.W))    //移動
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
            if (Input.GetKeyDown(KeyCode.Space))    //ジャンプ
            {
                if (grounded)
                {
                    rb.AddForce(Vector3.up * jumpPower);
                }
            }
            if (transform.position.y < 0)       //奈落対策
            {
                Debug.Log(startPosi);
                transform.position = startPosi;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
        else
        {
            rb.useGravity = false;
            if (Input.GetKey(KeyCode.W))    //移動
            {
                transform.position += transform.TransformDirection(Vector3.forward * MoveSpeed * 10 * Time.deltaTime);//(grounded)?==if(grouded) // dashSpeed : jumpSpeed  == true : false
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += transform.TransformDirection(Vector3.back * MoveSpeed * 10 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += transform.TransformDirection(Vector3.left * MoveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.TransformDirection(Vector3.right * MoveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Space))    //ジャンプ
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    rb.AddForce(Vector3.down * MoveSpeed * 5);
                }
                else
                {
                    rb.AddForce(Vector3.up * MoveSpeed * 5);
                }
            }
            else
            {
                rb.velocity = Vector3.zero;
            }

        }
        if (Input.GetKey(KeyCode.LeftArrow))//方向転換
        {
            transform.Rotate(new Vector3(0, -RotateSpeed, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, RotateSpeed, 0));
        }
    }
    void OnCollisionEnter(Collision collision)//○○に当たったとき
    {
        if (collision.gameObject.tag == "Goal")
        {
            SceneManager.LoadScene(collision.gameObject.GetComponent<Teleporter>().Warpworld);
            Debug.Log("To be continued...");
        }
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
    void ChangeCreativity()
    {
        creativity = !creativity;
        Debug.Log("change creativity!");
        if (creativity)
        {
            Debug.Log("Now it's creativity!");
        }
        else
        {
            Debug.Log("Now it's not creativity!");
        }
    }
}
