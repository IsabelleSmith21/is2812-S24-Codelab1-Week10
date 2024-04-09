using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueRunner : MonoBehaviour
{
    public Transform player; // player object
    public float moveSpeed = 1f; // Speed 
    public GameObject heart; // heart object

    private Queue<Vector3> movementQueue; // Queue to store movement directions

    void Start()
    {
        movementQueue = new Queue<Vector3>();
    }

    void Update()
    
        {
            // Player 
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // move left
                movementQueue.Enqueue(player.position + Vector3.left);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // move right
                movementQueue.Enqueue(player.position + Vector3.right);
            }

            // Check if there are movements in the queue
            if (movementQueue.Count > 0)
            {
                // Move the player towards the next position in the queue
                Vector3 nextPos = movementQueue.Peek();
                Vector3 moveDir = nextPos - player.position;
                player.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);

                // Check if the player has reached the next position
                if (Vector3.Distance(player.position, nextPos) < 0.1f)
                {
                    // Remove the position from the queue
                    movementQueue.Dequeue();
                }
            }
        }
    
    
}


