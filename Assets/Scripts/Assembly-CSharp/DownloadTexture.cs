using System.Collections;
using UnityEngine;

[RequireComponent(typeof(UITexture))]
public class DownloadTexture : MonoBehaviour
{
	public string url = "http://www.yourwebsite.com/logo.png";

	public bool pixelPerfect = true;

	private Texture2D mTex;

	private IEnumerator Start()
	{
		WWW www = new WWW(url);
		yield return www;
		mTex = www.texture;
		if (mTex != null)
		{
			UITexture component = GetComponent<UITexture>();
			component.mainTexture = mTex;
			if (pixelPerfect)
			{
				component.MakePixelPerfect();
			}
		}
		www.Dispose();
	}

	private void OnDestroy()
	{
		if (mTex != null)
		{
			Object.Destroy(mTex);
		}
	}
}
