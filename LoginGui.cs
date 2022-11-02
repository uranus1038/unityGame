using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI.API ; 
public class LoginGui : MonoBehaviour
{
    public static LoginGui hInst ; 
    public string string_0;
    private string string_1 ; 
    private float float_0;
    private float float_1;
    private GUIStyle guistyle_0;
    public eLoginState eLoginState_0; 

    //texture
    private Texture texture_0;
    // Void Awake
    private void Awake()
    {
        hInst = this ; 
        this.Init();
        string_0 = string.Empty ; 
        string_1 = string.Empty ; 
        eLoginState_0 = eLoginState.Init ; 
    }

    private void Init()
    {
        //Texture
        this.texture_0 = (Texture)Resources.Load("GUI/Login/black", typeof(Texture));

        //GUI
        this.guistyle_0 = new GUIStyle();
        this.guistyle_0.font = (Font)Resources.Load("Font/maaja", typeof(Font));
        this.guistyle_0.fontSize = 50;
    } 
    // Display GUI
    private void OnGUI()
    {
         
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.height / 1024f, (float)Screen.height / 1024f, 1f));
        GUI.depth = 2;
        this.float_1 = (float)(1024 * Screen.width / Screen.height);
        if (eLoginState_0 == eLoginState.Init)
        {
            GUI.DrawTexture(new Rect(0.5f * this.float_1 - 960f, 0f, 1920f, 1024f), this.texture_0);
            float_0 = Time.deltaTime;
            eLoginState_0 = eLoginState.fadeIn;
            return;
        }
        if (eLoginState_0 == eLoginState.fadeIn)
        {
            if (Time.time < this.float_0 + 0.5f)
            {
                float a = 2f * (this.float_0 + 0.5f - Time.time);
                Color color = GUI.color;
                color.a = a;
                GUI.color = color;
                GUI.DrawTexture(new Rect(0.5f * this.float_1 - 960f , 0f , 1920f , 1024f), this.texture_0);
                Color color2 = GUI.color;
                color2.a = 1f;
                GUI.color = color2;
                return;
            }
            this.eLoginState_0 = eLoginState.login;
            this.float_0 = Time.time;
            return;
        }
         if (eLoginState_0 == eLoginState.login)
        {
           // Text Input
            this.string_0 = GUI.TextField(new Rect(0.5f * this.float_1 - 65f, 751f, 200f, 50f), this.string_0, 15,this.guistyle_0);
            // Password Input
            this.string_1 = GUI.PasswordField(new Rect(0.5f * this.float_1 - 65f, 785f, 200f, 50f), this.string_1, "*"[0], 15,this.guistyle_0);

            if (GUI.Button(new Rect(0.5f * this.float_1 - 68f, 832f, 136f, 36f), "Login"))
            {
                    StartCoroutine(UMIAPIUser.hInst.umiGetUser(this.string_0));
            }
        }
        

    }
}
