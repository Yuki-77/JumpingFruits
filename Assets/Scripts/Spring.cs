using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public string animationState = "idle";
    public float animationSpeed = 10.0f;
    public float jumpForce = 800.0f;
    public List<Animation> animations = new List<Animation>();
    float time = 0;
    //public AudioClip firstAudioClip;
    //public AudioClip secondAudioClip;
    public AudioSource[] audios;
    //public AudioSource audio;

    //public AudioSource soundEffect1;
    //public AudioSource soundEffect2;
    //AudioSource soundEffect1;
    //AudioSource soundEffect2;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audios = GetComponents<AudioSource>();
        //soundEffect1 = audios[0];
        //soundEffect2 = audios[1];
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


        audios[0].mute = !GameManager.GetInstance().soundEffectOn;
        audios[1].mute = !GameManager.GetInstance().soundEffectOn;


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

        collision.GetComponent<RotateMe>().enabled = true;


        Rigidbody2D rigidBody = GameManager.GetInstance().playerMovement.GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0.0f);
        rigidBody.AddForce(new Vector2(0.0f, jumpForce * Time.deltaTime), ForceMode2D.Impulse);

        if (!audios[0].isPlaying)
            audios[0].Play();
        if (!audios[1].isPlaying)
            audios[1].Play();
        //soundEffect2.Play();
        //soundEffect1.Play();


    }
}
