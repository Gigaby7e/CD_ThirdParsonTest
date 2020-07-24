using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _barImage;
    private Transform _camera;


    // Start is called before the first frame update
    void Start()
    {
        FindCamera();
    }

    private void FindCamera()
    {
        _camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        LookArCamera();
    }

    private void LookArCamera()
    {
        transform.LookAt(_camera);
    }

    public void SetBarValue(int max, int current)
    {
        _barImage.fillAmount = (float)current / (float)max;
    }
}
