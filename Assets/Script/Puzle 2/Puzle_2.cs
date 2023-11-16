using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzle_2 : MonoBehaviour
{
    [SerializeField] public GameObject[] Characters = new GameObject[7];
    [SerializeField] public GameObject[] SlotFuera = new GameObject[7];
    [SerializeField] public GameObject[] SlotFamilia = new GameObject[2];
    [SerializeField] public GameObject[] SlotTrabajo = new GameObject[2];
    [SerializeField] public GameObject[] SlotAmigos = new GameObject[2];
    [SerializeField] public GameObject FamiliaAmigo;
    [SerializeField] public GameObject FamiliaTrabajo;
    [SerializeField] public GameObject TrabajoAmigo;
    [HideInInspector] public int Wrong;
    [HideInInspector] public int Vacio;
    
    public string Revision()
    {
        if(SlotFamilia[0].GetComponentInChildren<DraggableItem>() == null && SlotFamilia[1].GetComponentInChildren<DraggableItem>() == null && SlotTrabajo[0].GetComponentInChildren<DraggableItem>() == null && SlotTrabajo[1].GetComponentInChildren<DraggableItem>() == null && SlotAmigos[0].GetComponentInChildren<DraggableItem>() == null && SlotAmigos[1].GetComponentInChildren<DraggableItem>() == null && FamiliaAmigo.GetComponentInChildren<DraggableItem>() == null && TrabajoAmigo.GetComponentInChildren<DraggableItem>() == null && FamiliaTrabajo.GetComponentInChildren<DraggableItem>() == null)
        {
            return "Incompleto";
        }
        for (int i=0; i<SlotFamilia.Length; i++)
        {
            if (SlotFamilia[i].GetComponentInChildren<DraggableItem>() == null)
            {
                Wrong++;
            }
            else
            {
                if (SlotFamilia[i].GetComponentInChildren<DraggableItem>().ID != "Lupus")
                {
                    if (SlotFamilia[i].GetComponentInChildren<DraggableItem>().ID != "Phoenix")
                    {    
                        Wrong++;
                    }
                }
            }
            if (SlotTrabajo[i].GetComponentInChildren<DraggableItem>() == null)
            {
                Wrong++;
            }
            else
            {
                if (SlotTrabajo[i].GetComponentInChildren<DraggableItem>().ID != "Serpens")
                {
                    if (SlotTrabajo[i].GetComponentInChildren<DraggableItem>().ID != "Linx")
                    {
                        Wrong++;
                    }
                }
            }
            if (SlotAmigos[i].GetComponentInChildren<DraggableItem>() != null)
            {
                if (SlotAmigos[i].GetComponentInChildren<DraggableItem>().ID != "Polaris")
                {
                    Wrong++;
                }
            }
            else
            {
                Vacio++;
                Debug.Log("Slot Amigos: " +Vacio);
            }
        }
        if (FamiliaAmigo.GetComponentInChildren<DraggableItem>() != null && FamiliaAmigo.GetComponentInChildren<DraggableItem>().ID != "Pollux")
        {
            Wrong++;
        }
        if (TrabajoAmigo.GetComponentInChildren<DraggableItem>() != null && TrabajoAmigo.GetComponentInChildren<DraggableItem>().ID != "Boots")
        {
            Wrong++;
        }
        if (FamiliaTrabajo.GetComponentInChildren<DraggableItem>() != null)
        {
            Wrong++;
        }
        
        if (Vacio == 2)
        {
            return "Incorrecto";
        }
        else
        {    
            if (Wrong > 0)
            {
                return "Incorrecto";
            }
            else
            {
                return "Correcto";
            }
        }
    }

    public void Reinicia()
    {
        for (int i=0; i<SlotFuera.Length; i++)
        {
            Characters[i].transform.SetParent(SlotFuera[i].transform);
        }
        Wrong = 0;
        Vacio = 0;
        Debug.Log("Reinicio: " +Wrong);
    }
}
