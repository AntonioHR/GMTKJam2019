using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GMTKJ.Ai
{
    public class WaveManager : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        [SerializeField]
        private Wave[] waves;

        void Start()
        {
            foreach(Wave w in waves)
            {
                StartCoroutine(NewWave(w as Wave));
            }
        }

        IEnumerator NewWave(Wave wave)
        {
            foreach (WaveSection ws in wave.waveSections)
            {
                StartCoroutine(NewSection(ws));
                yield return new WaitForSeconds(ws.Size * ws.timeToSpawn + 3f);
            }
            yield return new WaitForSeconds(30f);
        }

        IEnumerator NewSection(WaveSection waveSection)
        {
            foreach (GameObject g in waveSection.enemyPrefabs)
            {
                AddEnemy(g);
                yield return new WaitForSeconds(waveSection.timeToSpawn);
            }   
        }
        
        void AddEnemy(GameObject prefab)
        {
            GameObject e = Instantiate(prefab, this.transform);
            e.GetComponent<GoToTarget>().SetTarget(target);
        }
    }
}