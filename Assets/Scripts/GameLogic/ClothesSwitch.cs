using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ClothesSwitch : MonoBehaviour
{
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private ParticleSystem _particles;

    [Space][Header("SWITCHABLE OBJECTS")]
    [SerializeField] private List<GameObject> _clothes;
    [SerializeField] private List<GameObject> _skins;


    private void SwitchClothes(int clothesId, int skinId, bool isDressed)
   {
       _photonView.RPC("SetActive", RpcTarget.AllBuffered, clothesId, skinId, isDressed);
       _particles.transform.position = _clothes[clothesId].transform.position;
       _particles.Play();
   }

   [PunRPC]
   public void SetActive(int clothesId, int skinId, bool isDressed)
   {
       _clothes[clothesId].SetActive(isDressed);
       _skins[skinId].SetActive(!isDressed);
   }

   public void ShirtButton()
   {
       // ShirtIndex = 0
       SwitchClothes(0, 0, !_clothes[0].activeSelf);
    }
    
    public void PantsButton()
    {
        // PantsIndex = 1
        SwitchClothes(1, 1, !_clothes[1].activeSelf);
    }
    
    public void FeetButton()
    {
        // FeetIndex = 2
        SwitchClothes(2, 2, !_clothes[2].activeSelf);
    }
}
