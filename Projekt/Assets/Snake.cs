using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{

    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    private List<Transform> _snakeSpawn;
    public Transform snakePrefab;

    public AudioClip eatingSound; 
    public AudioClip loseLifeSound; 
    private AudioSource audioSource; 

    public int lives = 3;

    public GameObject[] livesImages;

    public GameObject gameOverPanel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(moveSpeed, 0);    

        _snakeSpawn = new List<Transform>();
        _snakeSpawn.Add(this.transform);

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)){
            rb.velocity = new Vector2(0, moveSpeed);
        }
        if(Input.GetKeyDown(KeyCode.S)){
            rb.velocity = new Vector2(0, -moveSpeed);
        }
        if(Input.GetKeyDown(KeyCode.D)){
            rb.velocity = new Vector2(moveSpeed, 0);
        }
        if(Input.GetKeyDown(KeyCode.A)){
            rb.velocity = new Vector2(-moveSpeed, 0);
        }
    }

    private void FixedUpdate(){
        for(int i = _snakeSpawn.Count - 1; i>0; i--) {
            _snakeSpawn[i].position = _snakeSpawn[i - 1].position;
        }
    }

    private void grow(){
        Transform snakeSpawn = Instantiate(this.snakePrefab);
        snakeSpawn.position = _snakeSpawn[_snakeSpawn.Count - 1].position;

        _snakeSpawn.Add(snakeSpawn);

        audioSource.PlayOneShot(eatingSound); 
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Food"){
            grow();
        }
        if(collision.gameObject.tag == "Obstacle") {
            LoseLife();
        }
        if(collision.gameObject.tag == "Extra") {
            moveSpeed += 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Wall") {
            LoseLife();
        }
    }

    private void LoseLife() {
        lives--;
        livesImages[lives].SetActive(false);

        if(lives <= 0) {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }

        audioSource.PlayOneShot(loseLifeSound); 
    }

    public void Restart() {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        moveSpeed = 5f;
        
        lives = 3;
        for (int i = 0; i < livesImages.Length; i++) {
            livesImages[i].SetActive(true);
        }

        foreach (Transform segment in _snakeSpawn) {
            if (segment != this.transform) {
                Destroy(segment.gameObject);
            }
        }
        _snakeSpawn.Clear();
        _snakeSpawn.Add(this.transform);

        this.transform.position = Vector3.zero;
        rb.velocity = new Vector2(moveSpeed, 0);

    }

}
