using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public SpriteRenderer sprite {  get; private set; }
    public Color[] states;
    public int health { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {
        this.sprite = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        this.health = this.states.Length;
        this.sprite.color = this.states[this.health - 1];
    }

    private void Hit()
    {
        this.health--;
        if(this.health <= 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.sprite.color = this.states[this.health - 1];
        }
        FindObjectOfType<Ball>().Hit();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Hit();
        }
    }
}
