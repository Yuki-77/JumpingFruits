using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Dung : MonoBehaviour
{
    AudioSource audio;
    SpriteRenderer spriteRenderer;
    public string animationState = "idle";
    public float animationSpeed = 1.0f;
    public float jumpForce = 380.0f;
    public List<Animation> animations = new List<Animation>();
    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Character player = GameManager.GetInstance().player;
        player.animationState = "jump";
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y > 0)
            return;

        Character player = GameManager.GetInstance().player;
        player.animationState = "idle";
        animationState = "touched";

        GameManager.GetInstance().playerMovement.reverseControl = true;
        GameManager.GetInstance().timeLeftDung = 5.0f;

        if (!audio.isPlaying)
        {
            audio.Play();
        }
    }

}
