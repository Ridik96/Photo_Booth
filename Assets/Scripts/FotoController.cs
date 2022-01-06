using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FotoController : MonoBehaviour
{
    public GameObject panel;

    public void OnFoto()
    {
        panel.SetActive(false);
        StartCoroutine(ShootPhoto(ModelManager.Instance.target.name));
    }
    public IEnumerator ShootPhoto(string name)
    {
       
        yield return new WaitForEndOfFrame();
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();

        string screnShotName = "screnShot." + name + "." + System.DateTime.Now.ToString("yyyy.mm.dd.HH.mm.ss") + ".png";

        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/Output/" + screnShotName, bytes);
        Destroy(texture);
        panel.SetActive(true);

    }
    public void OnDestroy()
    {
        StopAllCoroutines();
    }
}
