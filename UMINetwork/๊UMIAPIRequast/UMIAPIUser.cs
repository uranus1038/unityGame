using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking ; 
namespace UMI.API
{
public class UMIAPIUser : MonoBehaviour
{
    public static UMIAPIUser hInst ;
    private  string UMIWebUser = "http://localhost/generator-back-end/api/test.php";
    // Start is called before the first frame update
    void Awake()
    {
        hInst = this ; 
    }
    public  IEnumerator umiGetUser( string helloApi )
    {
            WWWForm umiReq = new WWWForm();
            umiReq.AddField("name", helloApi);
            using (UnityWebRequest www = UnityWebRequest.Post(this.UMIWebUser, umiReq))
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