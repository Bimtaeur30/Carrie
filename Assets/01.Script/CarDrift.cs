using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.Windows;

public class CarDrift : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform Visual;
    [SerializeField] private TrailRenderer Tr_01;
    [SerializeField] private TrailRenderer Tr_02;
    [SerializeField] private ParticleSystem Ps_01; // ¿¬±â

    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        inputManager.IsDriftAction += Drift;
    }
    private void OnDisable()
    {
        inputManager.IsDriftAction -= Drift;
    }


    private void Drift(bool value)
    {
        bool pmVal = playerMovement.IsMoveing;
        var emission = Ps_01.emission;
        if (value & pmVal)
        {
            Vector2 input = inputManager.MoveInput;
            float inputx = input.x;

            Visual.transform.DOLocalRotate(new Vector3(0, 0, -inputx * 20), 0.5f);
            Tr_01.emitting = true;
            Tr_02.emitting = true;
            emission.enabled = true;
            playerMovement.IsDriftMovement(true);

            if (!Ps_01.isPlaying)
                Ps_01.Play();

        }
        else
        {
            Visual.transform.DOLocalRotate(Vector3.zero, 1f);
            Tr_01.emitting = false;
            Tr_02.emitting = false;
            emission.enabled = false;
            playerMovement.IsDriftMovement(false);

            if (Ps_01.isPlaying)
                Ps_01.Stop(withChildren: false, ParticleSystemStopBehavior.StopEmitting);
        }
    }
}
