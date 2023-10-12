
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private Rigidbody2D playerRb;
    private Vector2 MoveInput;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        MoveInput = new Vector2(moveX, 0f);
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + MoveInput * speed * Time.fixedDeltaTime);
    }
}
