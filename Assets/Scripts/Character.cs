using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Animation
{
    public string animationId = "";
    public List<Sprite> sprites = new List<Sprite>();
}

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SpriteRenderer))]
public class Character : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public float animationSpeed = 1.0f;
    public string animationState = "idle";
    //public string animationState = "jump";
    float time = 0;

    
    
    public List<Animation> animations = new List<Animation>();
    /*
    set sprite for charachter animations
    private Sprite jumpSprite = ThemeManager.GetInstance().characterSpriteJump;
    private Sprite idleSprite1 = ThemeManager.GetInstance().characterSpriteIdle1;
    private Sprite idleSprite2 = ThemeManager.GetInstance().characterSpriteIdle2;
    */

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Animation charJump = new Animation();
        charJump.animationId = "jump";

    }

    Animation GetAnimation(string animationId)
    {
        foreach (Animation anim in animations)
        {
            if (anim.animationId == animationId)
                return anim;
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (GameManager.GetInstance().soundEffectOn)
        {
            gameObject.GetComponent<AudioSource>().mute = false;
        }

        else if (!GameManager.GetInstance().soundEffectOn)
        {
            gameObject.GetComponent<AudioSource>().mute = true;
        }
        */

        //if (transform.position.y < -6f)
        if (transform.position.y < GameManager.GetInstance().mainCamera.transform.position.y - 6f)
        {
            GameManager.GetInstance().gameOver = true;
        }

        Animation currentAnimation = GetAnimation(animationState);
        time += Time.deltaTime;
        if (currentAnimation == null || currentAnimation.sprites.Count == 0)
            return;
        int index = ((int)(time * animationSpeed)) % currentAnimation.sprites.Count;
        spriteRenderer.sprite = currentAnimation.sprites[index];
    }
}