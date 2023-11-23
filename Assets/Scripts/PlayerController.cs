using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public AudioSource pickupSound;

    private int count;
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movement_value)
    {
        Vector2 movement_vector = movement_value.Get<Vector2>();

        movementX = movement_vector.x;
        movementY = movement_vector.y;
    }

    void FixedUpdate()
    {
        // Touch controls override keyboard controls' movementX and movementY
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == UnityEngine.TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Calibrating swipe movement speed
            movementX = touchDeltaPosition.x * 0.01f;
            movementY = touchDeltaPosition.y * 0.01f;
            if (movementX > 0.5f) movementX = 0.5f;
            else if (movementX < -0.5f) movementX = -0.5f;
            if (movementY > 0.5f) movementY = 0.5f;
            else if (movementY < -0.5f) movementY = -0.5f;
        }

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;

            SetCountText();

            pickupSound.Play();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }
}
