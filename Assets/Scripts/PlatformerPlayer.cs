using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{

    public float speed = 4.5f;
    public float jumpForce = 12f;

    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D box;
    private int coin;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource JumpAudioSource;
    [SerializeField] AudioClip running;
    [SerializeField] AudioClip jumping;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        coin = 0;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltax = Input.GetAxis("Horizontal") * speed;
        Vector2 movement = new Vector2(deltax, body.velocity.y);
        body.velocity = movement;

        anim.SetFloat("speed", Mathf.Abs(deltax));
        if(!Mathf.Approximately(deltax, 0)){
            transform.localScale = new Vector3(Mathf.Sign(deltax), 1, 1);
        }

        Vector3 max = box.bounds.max;
        Vector3 min = box.bounds.min;
        Vector2 corner1 = new Vector2(max.x, min.y - 0.1f);
        Vector2 corner2 = new Vector2(min.x, min.y - 0.2f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

        bool grounded = hit != null;

        MovingPlatform platform = null;
        if(grounded){
            platform = hit.GetComponent<MovingPlatform>();
        }

        if(platform != null){
            transform.parent = platform.transform;
        }

        else{
            transform.parent = null;
        }

        Vector3 playerScale = Vector3.one;
        if(platform != null){
            playerScale = platform.transform.localScale;
        }

        if(!Mathf.Approximately(deltax, 0)){
            transform.localScale = new Vector3(Mathf.Sign(deltax) / playerScale.x, 1 / playerScale.y, 1);
        }

        body.gravityScale = (grounded && Mathf.Approximately(deltax, 0)) ? 0 : 1;

        if(Input.GetKeyDown(KeyCode.Space) && grounded){
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            if (!audioSource.isPlaying || audioSource.clip != jumping)
            {
                JumpAudioSource.PlayOneShot(jumping);
            }
        }
        bool isRunning = anim.GetFloat("speed") > 0.1f;

        if (isRunning && grounded)
        {
            if (!audioSource.isPlaying || audioSource.clip != running)
            {
                audioSource.clip = running;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying && audioSource.clip == running)
            {
                audioSource.Stop();
            }
        }
    }

    public void AddCoin(int amount){
        coin += amount;
        Debug.Log($"Coin: {coin}");
    }
}
