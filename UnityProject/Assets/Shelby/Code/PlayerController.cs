using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject playerCamera;
    public Transform cameraPivot;
    public float playerCameraSpeed;

    public GameObject cloud;

    public float moveSpeed = 10;
    public float rotSpeed = 50;

    void Start()
    {
        //Lock the mouse cursor and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


        //Spawn clouds lol
        for (int i = 0; i < 25; i++)
        {
            Instantiate(cloud, new Vector3(Random.Range(-1500, 1500), 5, Random.Range(-1500, 1500)), Quaternion.Euler(0,Random.Range(0, 180),0));
        }
    }
    void Update()
    {
        //Rotate player with A and D as well as the mouse
        Vector3 rotationPlayer = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), -Input.GetAxis("Horizontal") * 2.5f);
        transform.Rotate(rotationPlayer * Time.deltaTime * rotSpeed);

        //Move the player forward
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        //Lerp the camera to the camera pivot
        playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, cameraPivot.position, playerCameraSpeed);
        playerCamera.transform.rotation = Quaternion.Lerp(playerCamera.transform.rotation, cameraPivot.rotation, playerCameraSpeed);

    }
}
