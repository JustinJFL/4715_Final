using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public float speed;
    private CharacterController character;
    
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        Debug.Log("Teeeeeeeeeeeest");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);

        character.Move(movement * speed);
    }
}
