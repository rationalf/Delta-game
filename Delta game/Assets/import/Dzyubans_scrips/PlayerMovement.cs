using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{   
    public float speed = 6.0f;
    public float gravity = -9.8f;
    public Animator forward;
    public GameObject player;
    private CharacterController _characterController;
    // Start is called before the first frame update
    void Start()
    {
        forward = player.GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    
    void Update()
    {   
        forward.SetBool("isForward", false);
        speed = 6.0f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed *= 2f;
        }
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        float dt = Time.deltaTime;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ)  * speed;
        if (movement.x != 0 || movement.z != 0)
        {
            StartCoroutine(Forward());
        }
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= dt;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);
    }

    private IEnumerator Forward()
    {
        forward.SetBool("isForward", true);
        yield return new WaitForSeconds(0.00002f);
    }
}
