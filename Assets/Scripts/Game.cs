using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModal : MonoBehaviour {

    [SerializeField] GameObject modal;

    void Start() {
        modal.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            modal.SetActive(!modal.activeSelf);
        }
    }

    public void ModalClose () {
        if (modal == null) {
            modal = GameObject.FindGameObjectWithTag("GameMenuModal");
        }
        
        modal.SetActive(false);
    }
}
