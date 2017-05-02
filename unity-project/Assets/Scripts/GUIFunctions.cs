using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIFunctions : MonoBehaviour {
  public InputField loginName;
  public InputField loginPass;

  public InputField signupName;
  public InputField signupEmail;
  public InputField signupPass;

  public Text loginAlert;
  public Text signupAlert;


  private string hostname = "http://bc1691.code.engineering.nyu.edu:9800/";

  void Start () {}
  void Update () {}

  public void login(){
    WWWForm postData = new WWWForm();
    postData.AddField("Username",loginName.text);
    postData.AddField("Password",loginPass.text);

    WWW www = new WWW(hostname+"loginAuth", postData);

    while(!www.isDone){}

    if(parseResponseCode(www.responseHeaders["STATUS"]) == 302 || parseResponseCode(www.responseHeaders["STATUS"]) == 200){
      loginAlert.text = "Login Success";
    }
    else{
      loginAlert.text = "Login Failure";
      Debug.LogWarning(www.responseHeaders["STATUS"]);
      Debug.LogWarning(System.Text.Encoding.UTF8.GetString(www.bytes));
    }

  }

  public void createAcct(){
    WWWForm postData = new WWWForm();
    postData.AddField("Username",signupName.text);
    postData.AddField("Password",signupPass.text);
    postData.AddField("email",signupEmail.text);

    WWW www = new WWW(hostname+"registerAuth", postData);

    while(!www.isDone){}

    if(parseResponseCode(www.responseHeaders["STATUS"]) == 302 || parseResponseCode(www.responseHeaders["STATUS"]) == 200){
      signupAlert.text = "Signup Success";
    }
    else{
      signupAlert.text = "Signup Failure";
      Debug.LogWarning(www.responseHeaders["STATUS"]);
      Debug.LogWarning(System.Text.Encoding.UTF8.GetString(www.bytes));
    }


  }

  public void logout(){
    WWW www = new WWW(hostname+"logout");
    while(!www.isDone){}
    print(www.responseHeaders["STATUS"]);
       /*
    WWW www = new WWW("https://jsonplaceholder.typicode.com/posts");
    while(!www.isDone){}
    print(www.responseHeaders["STATUS"]);
    Debug.LogWarning(System.Text.Encoding.UTF8.GetString(www.bytes));
    */

  }

  //yanked this from stack overflow
  private static int parseResponseCode(string statusLine) {
    int ret = 0;

    string[] components = statusLine.Split(' ');
    if (components.Length < 3) {
      Debug.LogError("invalid response status: " + statusLine);
    }
    else {
      if (!int.TryParse(components[1], out ret)) {
        Debug.LogError("invalid response code: " + components[1]);
      }
    }

    return ret;
  }

}
