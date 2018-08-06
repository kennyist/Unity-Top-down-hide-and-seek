using UnityEngine;
using System.Collections;

public class scoreBoard{
	
	private string secretKey = "S3DFvnf£Smg";
	private string addURL = "http://kennyist.com/unitygame/addscore.php";
	private string top10URL = "http://www.kennyist.com/unitygame/top10.php";
	private string hash;
	private WWW highScore;
	private string ip;
	private string top10;
	
	private string placement;
	
	private bool loading = false;
	private float loadingPercent = 0.0f;
	
	private Texture2D text;
	
	public IEnumerator postScore(string name, int score, string oponent, bool isSeeker){
		//hash = Md5Sum(name + loc + secretKey);
		
		/*Network.Connect("http://www.google.com");
		ip = Network.player.externalIP;
		Network.Disconnect();*/
		
		int seeker = isSeeker ? 1 : 0;
		
		string post_url = addURL + "?name=" + WWW.EscapeURL(name) + "&score=" + score + "&oponent=" + WWW.EscapeURL(oponent) + "&seeker=" + seeker;
		
		WWW highScore = new WWW(post_url);
		loading = true;
		
        yield return highScore; // Wait until the download is done
		loading = false;
 
        if (highScore.error != null)
        {
            Debug.Log("There was an error posting the high score: " + highScore.error);
        } else {
			Debug.Log ("posted" + post_url);
			placement = highScore.text;
		}
	}
	
	public IEnumerator getTop10(bool isSeeker){
		int seeker = isSeeker ? 1 : 0;
		WWW hsGet = new WWW(top10URL+"?s="+seeker);
		
		loading = true;
		
		yield return hsGet;
		
		loading = false;
		
		if (hsGet.error != null)
        {
            Debug.Log("There was an error getting the high score: " + hsGet.error);
        }
        else
        {
        	top10 = hsGet.text; 
        }
	}
	
	public bool isLoading(){
		return loading;
	}
	
	public string isLoadingSTR(){
		string rLoading = loading ? "Loading" : "loaded";
		return rLoading;
	}
	
	public float getLoadPercent(){
		if(loading){
			return highScore.progress;
		} else {
			return 0f;
		}
	}
	
	public string GetTop10STR(){
		return top10;
	}
	
	public IEnumerator getTextTestStart(bool isSeeker){
		loading = true;
		int seeker = isSeeker ? 1 : 0;
		WWW hsGet = new WWW("http://www.kennyist.com/unitygame/top10img.php?s=" + seeker);
		
		yield return hsGet;
		
		if (hsGet.error != null)
        {
            Debug.Log("There was an error getting the high score: " + hsGet.error);
			loading = false;
        }
        else
        {
        	text = hsGet.texture; 
			Debug.Log ("got texture");
			loading = false;
        }
	}
	
	public Texture2D returnTextTest(){
		return text;	
	}
	
	private string Md5Sum(string strToEncrypt)
	{
		System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
		byte[] bytes = ue.GetBytes(strToEncrypt);
	 
		System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
		byte[] hashBytes = md5.ComputeHash(bytes);
	 
		string hashString = "";
	 
		for (int i = 0; i < hashBytes.Length; i++)
		{
			hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
		}
	 
		return hashString.PadLeft(32, '0');
	}
	
	public string GetPlacement(){
		return placement; 
	}
}
