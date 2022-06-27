using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Snail : MonoBehaviour
{
    AudioSource audio;
    public GameObject starPrefab;
    SpriteRenderer spriteRenderer;
    public float animationSpeed = 1.0f;
    private Vector3 startPosition;
    public string animationState = "left";
    //public string animationState = "right";

    public List<Animation> animations = new List<Animation>();
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetInstance().soundEffectOn)
        {
            gameObject.GetComponent<AudioSource>().mute = false;
        }

        else if (!GameManager.GetInstance().soundEffectOn)
        {
            gameObject.GetComponent<AudioSource>().mute = true;
        }

        Animation currentAnimation = GetAnimation(animationState);
        time += Time.deltaTime;
        if (currentAnimation == null || currentAnimation.sprites.Count == 0)
            return;
        int index = ((int)(time * animationSpeed)) % currentAnimation.sprites.Count;
        spriteRenderer.sprite = currentAnimation.sprites[index];

        Vector3 wormPosition = transform.position;

        if (Time.timeScale == 1)
        {
            if (animationState == "left" && wormPosition.x > (startPosition.x - 0.5f))
            {
                transform.position = transform.position - new Vector3(0.002f, 0.0f, 0.0f);
            }
            else if (animationState == "left" && wormPosition.x <= (startPosition.x - 0.5f))
            {
                animationState = "right";
            }
            else if (animationState == "right" && transform.position.x < startPosition.x)
            {
                transform.position = wormPosition + new Vector3(0.002f, 0.0f, 0.0f);
            }
            else if (animationState == "right" && transform.position.x >= startPosition.x)
            {
                animationState = "left";
                transform.position = wormPosition - new Vector3(0.002f, 0.0f, 0.0f);
            }
        }
        
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y > 0)
            return;

        if (!audio.isPlaying)
        {
            audio.Play();
        }
        GameManager.GetInstance().gameOver = true;
    }
}
