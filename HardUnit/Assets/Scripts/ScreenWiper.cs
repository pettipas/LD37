using UnityEngine;
using System.Collections;
public class ScreenWiper : MonoBehaviour {

    public int max = 32;
    public int amount = 1;
    RenderTexture reTex;

    void OnRenderImage(RenderTexture src, RenderTexture dest) {
        reTex = RenderTexture.GetTemporary(src.width / amount, src.width / amount);
        reTex.filterMode = FilterMode.Point;
        src.filterMode = FilterMode.Point;
        Graphics.Blit(src, reTex);
        Graphics.Blit(reTex, dest);
        RenderTexture.ReleaseTemporary(reTex);
    }


    public IEnumerator WipeIn(int start, int end) {
        amount = start;
        max = end;
        while (amount > 1) {
            amount -= 2;
            if (amount < 1) {
                amount = 1;
            }
            yield return new WaitForSeconds(0.05f);
        }
        amount = 1;
        amount = end;
        yield break;
    }

    public IEnumerator WipeOut(int start, int end) {
        amount = start;
        max = end;
        while (amount < max) {
            amount += 2;
            yield return new WaitForSeconds(0.05f);
        }
        amount = end;
        yield break;
    }

    public IEnumerator WipeOut(float time) {
        float dt = 1 / time;
        float t = 0;
        float start = amount;
        while (t < 1) {
            t += dt * Time.deltaTime;
            amount = (int)Mathf.Lerp(start, max, t);
            Debug.Log(amount);
            yield return null;
        }
        yield break;
    }
}

