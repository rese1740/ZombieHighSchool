using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerJob
{
    None,   
    Medic,
    Archer,
    ChairMan,
    FireMan
    // �ʿ��� ���� �߰�
}

public class JobType : MonoBehaviour
{
    public PlayerJob job;
}
