using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using I2.Loc;
public class GameTools{
    
    public static string GetTranslation(string _key)
    {
        string t_translation;

        if (LocalizationManager.TryGetTermTranslation(_key, out t_translation))
        {
            if (string.IsNullOrEmpty(t_translation))
                t_translation = "#Empty: " + _key;
            else
                t_translation = t_translation.Replace("\\n", "\n");
        }
        else
            t_translation = "#" + _key;

        return t_translation;
    }

}
