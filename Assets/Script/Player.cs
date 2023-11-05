
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private Rigidbody2D playerRb;
    private Vector2 MoveInput;
    private bool movementEnabled;
    private Animator animator;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        movementEnabled = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(movementEnabled)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            MoveInput = new Vector2(moveX, 0f);

            animator.SetFloat("Horizontal", moveX);
            animator.SetFloat("Speed", MoveInput.sqrMagnitude);
        }
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + MoveInput * speed * Time.fixedDeltaTime);
    }

    public void StopMovement()
    {
        MoveInput = new Vector2(0, 0);
    }

    public void EnableMovement()
    {
        movementEnabled = true;
    }

    public void DisableMovement()
    {
        movementEnabled = false;
    }
}
