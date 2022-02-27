using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    private Vector3 m_Velocity = Vector3.zero;
    Vector3 Vec;
    float walkingSpeed = 15;
    bool m_FacingRight = true;
    float xThrow, yThrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void Move(float move)
    {
        
        Vec = transform.localPosition;
        Vec.y += Input.GetAxis("Jump") * Time.deltaTime * walkingSpeed;
        Vec.x += Input.GetAxis("Vertical") * Time.deltaTime * -1 *walkingSpeed;
        Vec.z += Input.GetAxis("Horizontal") * Time.deltaTime * walkingSpeed;
        transform.localPosition = Vec;

        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
