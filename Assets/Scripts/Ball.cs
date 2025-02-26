using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2d; 
    private AudioSource[] audioSources;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void GoBall(){                      
        float rand = Random.Range(0, 2);
        if(rand < 1){
            rb2d.AddForce(new Vector2(10, -30));
            
        } else {
            rb2d.AddForce(new Vector2(-10, -30));
            
        }
    }
    


    void Start () {
        audioSources = GetComponents<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>(); // Inicializa o objeto bola
        Invoke("GoBall", 2);    // Chama a função GoBall após 2 segundos
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            rb2d.AddForce(new Vector2(0, 5));
        }
    }

    void OnCollisionEnter2D (Collision2D coll) {
        if(coll.collider.CompareTag("Player")){
            Vector2 vel;
            vel.y = rb2d.linearVelocity.y;
            vel.x = (rb2d.linearVelocity.x / 2) + (coll.collider.attachedRigidbody.linearVelocity.x / 3);
            rb2d.linearVelocity = vel;
        }
        if(coll.gameObject.tag == "Brick"){
            Destroy(coll.gameObject);
            GameManager.Score();
            BricksGeneration.numberOfBricks--;
            audioSources[1].Play();
        }
        if(coll.gameObject.tag == "Bound"){
            audioSources[0].Play();
        }
    }

    void ResetBall(){
        rb2d.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    // Reinicializa o jogo
    void RestartGame(){
        ResetBall();
        Invoke("GoBall", 1);
    }

}
