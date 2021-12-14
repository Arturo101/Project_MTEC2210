using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    public Sprite[] animationSprites;

    public float animationTime = 1.0f;

    private SpriteRenderer _spriteRenderer;

    private int _animationFrame;
    
    public int scoreValue;

    private GameManager gameManager;
    

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);

    }
    private void AnimateSprite()
    {
        _animationFrame++;
        if (_animationFrame > this.animationSprites.Length){
            _animationFrame = 0;
        }
        _spriteRenderer.sprite = this.animationSprites[_animationFrame];
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boundary" || collision.gameObject.tag == "Player" )
        {
            gameManager.RestartGame();
        }
    }

  
}
