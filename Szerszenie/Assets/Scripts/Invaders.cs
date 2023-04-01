using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    public Invader[] prefabs;
    public int rows = 5;
    public int columns = 11;
    public AnimationCurve speed;
    private Vector2 direction = Vector2.right;
    private Vector3 startingPosition;
    private float edgeBuffer = 1f;
    public int totalInvaders => this.rows * this.columns;
    public float percentKilled => (float)this.amountKilled / (float)this.totalInvaders;
    public int amountKilled { get; private set; }

    private void Start()
    {
        // Store the starting position of the grid
        startingPosition = transform.position;

        for (int row = 0; row < rows; row++)
        {
            float width = 2.0f + (this.columns - 1);
            float height = 2.0f * (this.rows - 1);
            Vector2 centering = new Vector2(-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 2.0f), 0.0f);
            for (int col = 0; col < columns; col++)
            {
                Invader invader = Instantiate(this.prefabs[row], this.transform);
                invader.killed += InvaderKiller;
                Vector3 position = rowPosition;
                position.x += col * 2.0f;
                invader.transform.position = position;
            }
        }
    }

    private void Update()
    {
        transform.position += new Vector3(direction.x * speed * Time.deltaTime, 0, 0);

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, -Camera.main.transform.position.z));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, -Camera.main.transform.position.z));

        bool hitEdge = false;
        foreach (Transform invader in transform)
        {
            if (invader.gameObject.activeInHierarchy)
            {
                Vector3 pos = invader.transform.position;
                if (direction == Vector2.right && pos.x + edgeBuffer >= rightEdge.x)
                {
                    hitEdge = true;
                    break;
                }
                else if (direction == Vector2.left && pos.x - edgeBuffer <= leftEdge.x)
                {
                    hitEdge = true;
                    break;
                }
            }
        }

        if (hitEdge)
        {
            // Change the direction of the grid and move it down
            direction.x *= -1.0f;
            Vector3 position = transform.position;
            position.y -= 1.0f;
            transform.position = position;

            // Update the positions of the invaders
            foreach (Transform invader in transform)
            {
                if (invader.gameObject.activeInHierarchy)
                {
                    Vector3 pos = invader.transform.position;
                    pos.y -= 1.0f;
                    invader.transform.position = pos;
                }
            }
        }
    }
    private void InvaderKiller()
    {

    }


}
