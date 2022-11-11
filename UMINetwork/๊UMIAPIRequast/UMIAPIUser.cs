using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking ; 
namespace UMI.API
{
public class UMIAPIUser : MonoBehaviour
{
    public static UMIAPIUser hInst ;
    private  string UMIWebUser = "http://localhost:8000/api/login/login";
    // Start is called before the first frame update
    void Awake()
    {
        hInst = this ; 
    }
    public  IEnumerator UMIGetUser( string UID )
    {
            WWWForm UMIReq = new WWWForm();
            UMIReq.AddField("userName", UID);
            using (UnityWebRequest www = UnityWebRequest.Post(this.UMIWebUser, UMIReq))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    Debug.Log(www.downloadHandler.text);
                }
                
            }

    }
}

}