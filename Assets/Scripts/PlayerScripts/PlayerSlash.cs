using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlash : MonoBehaviour
{
    [SerializeField] private float attackCooldawn = 0.3f;
    [SerializeField] private GameObject slashPrefab;

    private float attackTimer;
    private Camera mainCamera;
    private AudioSource audioSource;
    private Vector3 spawnPosition;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && Time.time > attackTimer)
        {
            Slash();
            audioSource.Play();
            attackTimer = Time.time + attackCooldawn;
        }
    }

    private void Slash()
    {
        spawnPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        spawnPosition.z = 0;
        Instantiate(slashPrefab, spawnPosition, Quaternion.identity);
    }
}
