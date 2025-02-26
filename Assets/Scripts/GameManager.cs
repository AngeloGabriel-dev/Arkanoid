using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public static int playerScore=0;
    public static int lifes = 3;
    public GUISkin layout;              
    GameObject theBall;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Scene scene = ;
        if(lifes == 0){
            SceneManager.LoadScene("GameOver");
            playerScore = 0;
            lifes = 3;
        }
        if(BricksGeneration.numberOfBricks == 0 && SceneManager.GetActiveScene().name == "Fase1"){
            SceneManager.LoadScene("Fase2");
        }
        if(BricksGeneration.numberOfBricks == 0 && SceneManager.GetActiveScene().name == "Fase2"){
            SceneManager.LoadScene("Vitoria");
        }
    }

    void OnGUI () {
        Scene scene = SceneManager.GetActiveScene();
        GUI.skin = layout;
        if (scene.name == "Fase1" || scene.name == "Fase2"){
            FaseGUI();
        }
        if (scene.name == "MenuInicial"){
            MenuInicialGUI();
        }
        if (scene.name == "GameOver"){
            GameOverGUI();
        }
        if (scene.name == "Vitoria"){
            VitoriaGUI();
        }
    }


    public static void LoseLife(){
        lifes--;
    }

    public static void Score(){
        playerScore += 50;
    }

    void FaseGUI(){
        GUI.Label(new Rect(160, 0, 400, 100), "Score: " + playerScore);
        GUI.Label(new Rect(Screen.width - 400, 0, 400, 100), "Vidas: " + lifes);
    }

    void VitoriaGUI(){
        GUIStyle customStyle = new GUIStyle(GUI.skin.label);
        customStyle.fontSize = 100; // Altere o tamanho da fonte aqui
        customStyle.normal.textColor = Color.white; // Define a cor do texto (opcional)
        customStyle.alignment = TextAnchor.MiddleCenter; 
        Vector2 textSize = customStyle.CalcSize(new GUIContent("PARABÉNS!\n VOCÊ GANHOU"));

        // Calcula a posição para centralizar
        float x = (Screen.width - textSize.x) / 2;
        float y = (Screen.height - textSize.y) / 2; // Posição Y fixa, ajuste conforme necessário

        GUI.Label(new Rect(x, y, textSize.x, textSize.y), "PARABÉNS! VOCÊ GANHOU", customStyle);
    }

    void GameOverGUI(){
        GUIStyle customStyle = new GUIStyle(GUI.skin.label);
        customStyle.fontSize = 100; // Altere o tamanho da fonte aqui
        customStyle.normal.textColor = Color.white; // Define a cor do texto (opcional)
        customStyle.alignment = TextAnchor.MiddleCenter; 
        Vector2 textSize = customStyle.CalcSize(new GUIContent("GAME OVER"));

        // Calcula a posição para centralizar
        float x = (Screen.width - textSize.x) / 2;
        float y = 200; // Posição Y fixa, ajuste conforme necessário

        GUI.Label(new Rect(x, y, textSize.x, textSize.y), "GAME OVER", customStyle);

        customStyle.fontSize = 70;
        Vector2 textSize2 = customStyle.CalcSize(new GUIContent("RESTART"));
        float x2 = (Screen.width - textSize2.x) / 2;

        if (GUI.Button(new Rect(x2-50, y+textSize.y+textSize2.y + 200, textSize2.x+100, textSize2.y), "RESTART", customStyle))
        {
            SceneManager.LoadScene("Fase1");
        }
    }

    void MenuInicialGUI(){
        GUIStyle customStyle = new GUIStyle(GUI.skin.label);
        customStyle.fontSize = 100; // Altere o tamanho da fonte aqui
        customStyle.normal.textColor = Color.white; // Define a cor do texto (opcional)
        customStyle.alignment = TextAnchor.MiddleCenter; 
        Vector2 textSize = customStyle.CalcSize(new GUIContent("ARKANOID"));

        // Calcula a posição para centralizar
        float x = (Screen.width - textSize.x) / 2;
        float y = 200; // Posição Y fixa, ajuste conforme necessário

        GUI.Label(new Rect(x, y, textSize.x, textSize.y), "ARKANOID", customStyle);

        customStyle.fontSize = 70;
        Vector2 textSize2 = customStyle.CalcSize(new GUIContent("START"));
        float x2 = (Screen.width - textSize2.x) / 2;

        if (GUI.Button(new Rect(x2-50, y+textSize.y+textSize2.y + 200, textSize2.x+100, textSize2.y), "START", customStyle))
        {
            SceneManager.LoadScene("Fase1");
        }
    }
}
