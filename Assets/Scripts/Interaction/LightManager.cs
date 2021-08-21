using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightManager : MonoBehaviour
{
    private Light _light;

    private bool _isBlinking;

    private float totalSeconds = 0.1f;
    private float maxIntensity = 1;

    void Start()
    {
        _light = transform.GetChild(0).GetComponent<Light>();
    }

    public void ToggleLight()
    {
        //if (Fusebox.isOn)
        //{
        if (_light.intensity == 1f)
        {
            Debug.Log("off");
            _light.intensity = 0;
        }
        else
        {
            Debug.Log("on");
            _light.intensity = 1;
        }
        //}
    }

    public void DisableLight()
    {
        _light.enabled = false;
    }

    public void BlinkLight()
    {
        _isBlinking = true;
        StartCoroutine(IBlinkLight());
    }

    public void FlickerLight()
    {
        int flickerAmount = Mathf.CeilToInt(Random.Range(2, 7));
        _isBlinking = true;

        for (int i = 0; i < flickerAmount; i++)
        {
            StartCoroutine(IBlinkLight());
            StartCoroutine(IBlinkLightTimer(flickerAmount));
        }
    }

    private IEnumerator IBlinkLight()
    {
        StartCoroutine(IBlinkLightTimer(10));

        while (_isBlinking)
        {
            float _blinkInterval = Random.Range(0.2f, 1.2f);
            StartCoroutine(IFlashLight());
            yield return new WaitForSeconds(_blinkInterval);
        }
    }

    private IEnumerator IBlinkLightTimer(int maxValue)
    {
        float _blinkTimer;

        //if (entityIsHunting)
        //{
        //  _blinkTimer = entityHuntingDuration;
        //}
        //else
        //{
        _blinkTimer = Random.Range(1, maxValue);
        //}

        while (true)
        {
            yield return new WaitForSeconds(1);
            _blinkTimer--;

            if (_blinkTimer <= 0)
            {
                _isBlinking = false;
                StopAllCoroutines();
            }
        }
    }

    public IEnumerator IFlashLight()
    {
        float waitTime = totalSeconds / 2;
        float blinkTime;

        blinkTime = Mathf.Sin(Time.deltaTime / waitTime);
        blinkTime = blinkTime - Mathf.Floor(blinkTime);

        while (_light.intensity < maxIntensity)
        {
            _light.intensity += blinkTime;        // Increase intensity
            yield return null;
        }
        while (_light.intensity > 0)
        {
            _light.intensity -= blinkTime;        //Decrease intensity
            yield return null;
        }
        yield return null;
    }
}