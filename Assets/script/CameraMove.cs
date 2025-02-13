using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    public GameObject CameraMaster;
    [SerializeField]
    private float rotateSpeed;
    private Vector3 playerpos;
    void Start()
    {
        transform.rotation = player.rotation;
    }
    void Update()
    {
        playerpos = player.transform.position;
        if (Input.GetKey(KeyCode.Z))    //–ß‚·
        {
            transform.rotation = player.rotation;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position = new Vector3(playerpos.x, playerpos.y + 4, playerpos.z);
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(new Vector3(-rotateSpeed, 0, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(new Vector3(rotateSpeed, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Rotate(new Vector3(0, -rotateSpeed, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Rotate(new Vector3(0, rotateSpeed, 0));
        }
    }
}
