using UnityEngine;
using UnityEngine.SceneManagement;

public class BricksGeneration : MonoBehaviour
{
    public GameObject blueBrick;
    public static int numberOfBricks = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Fase1"){
            Fase1();
        }
        if(SceneManager.GetActiveScene().name == "Fase2"){
            Fase2();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fase1(){
        for(int j=0; j<3; j++){
            for(int i=0; i<16; i++){
                blueBrick = Instantiate(blueBrick, new Vector2(-5 + 0.64f*i, 3 - j), Quaternion.identity);
                numberOfBricks++;
            }
        }
        
        for(int j=0; j<3; j++){
            for(int i=0; i<5; i++){
                blueBrick = Instantiate(blueBrick, new Vector2(-5 + 0.64f*i, 0 - j*0.32f), Quaternion.identity);
                numberOfBricks++;
            }
        }
        for(int j=0; j<3; j++){
            for(int i=10; i<15; i++){
                blueBrick = Instantiate(blueBrick, new Vector2(-5 + 0.64f*i, 0 - j*0.32f), Quaternion.identity);
                numberOfBricks++;
            }
        }
    }

    void Fase2(){
        for(int j=0; j<3; j++){
            for(int i=0; i<10; i++){
                if(j % 2 == 0){
                    blueBrick = Instantiate(blueBrick, new Vector2(-5 + i, 3 - j), Quaternion.identity);
                }
                else{
                    blueBrick = Instantiate(blueBrick, new Vector2(-4 + i, 3 - j), Quaternion.identity);
                }
                
                numberOfBricks++;
            }
        }
        
        // for(int j=0; j<3; j++){
        //     for(int i=0; i<5; i++){
        //         blueBrick = Instantiate(blueBrick, new Vector2(-5 + 0.64f*i, 0 - j*0.32f), Quaternion.identity);
        //         numberOfBricks++;
        //     }
        // }
        // for(int j=0; j<3; j++){
        //     for(int i=10; i<15; i++){
        //         blueBrick = Instantiate(blueBrick, new Vector2(-5 + 0.64f*i, 0 - j*0.32f), Quaternion.identity);
        //         numberOfBricks++;
        //     }
        // }
    }
}
