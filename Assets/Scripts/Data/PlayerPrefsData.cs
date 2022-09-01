using UnityEngine;

namespace Data
{
    public static class PlayerPrefsData
    {
        private const string KilledEnemiesKey = "KilledEnemies";

        public static int KilledEnemies
        {
            get => PlayerPrefs.GetInt(KilledEnemiesKey);
            set => KilledEnemiesKey.Save(value);
        }
        
        private static void Save(this string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
            PlayerPrefs.Save();
        }
    }
}