using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    public Invader[] prefabs;
    public int rows = 5;
    public int columns = 11;
    // Start is called before the first frame update
    private void Awake()
    {
        for (int row = 0; row < rows; row++)
        {
            Vector3 rowPosition = new Vector3(0.0f, row * 2.0f, 0.0f);
            for (int col = 0; col < columns; col++)
            {
                Invader invader = Instantiate(this.prefabs[row], this.transform);
                Vector3 position = rowPosition;
                position.x += col * 1.0f;
                invader.transform.position = position;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
