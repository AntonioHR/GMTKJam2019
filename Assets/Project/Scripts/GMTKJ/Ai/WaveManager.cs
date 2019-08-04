using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GMTKJ.Ai
{
    public class WaveManager : MonoBehaviour
    {
        [SerializeField]
        private ScriptableObject[] waves;
        [SerializeField]
        private float timeBetweenWaves = 10f;
        [SerializeField]
        private Text currentWaveText;

        public void Begin ()
        {
            StartCoroutine(Run());
        }
        IEnumerator Run()
        {
            foreach(Wave w in waves)
            {
                yield return new WaitForSeconds(w.initialDelay);
                StartCoroutine(NewWave(w));
                if(currentWaveText != null)
                    currentWaveText.text = w.name;
                yield return new WaitForSeconds(w.TotalTime());
            }
        }

        IEnumerator NewWave(Wave wave)
        {
            foreach (WaveSection ws in wave.waveSections)
            {
                StartCoroutine(NewSection(ws));
                float sectionTotalTime = ws.Size * ws.timeBewteenEnemies + wave.timeBewteenSections;
                yield return new WaitForSeconds(sectionTotalTime);
            }
        }

        IEnumerator NewSection(WaveSection waveSection)
        {
            foreach (GameObject g in waveSection.enemyPrefabs)
            {
                AddEnemy(g);
                yield return new WaitForSeconds(waveSection.timeBewteenEnemies);
            }   
        }
        
        void AddEnemy(GameObject prefab)
        {
            GameObject e = Instantiate(prefab, this.transform);
        }
    }
}