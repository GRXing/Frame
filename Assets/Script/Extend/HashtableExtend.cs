using System.Collections;

public static class HashtableExtend
{

    public static string GetString(this Hashtable hashtable, string key, string defaultValue = "")
    {

        if (hashtable.ContainsKey(key))
        {
            object value = hashtable[key];
            if (value is string)
            {
                return (string)value;
            }
            else if (value != null)
            {
                return value.ToString();
            }
        }

        return defaultValue;
    }

    public static int GetInt(this Hashtable hashtable, string key, int defaultValue = 0)
    {

        if (hashtable.ContainsKey(key))
        {
            object value = hashtable[key];
            if (value is double)
            {
                return (int)(double)value;
            }
            else if (value is string)
            {
                int intValue;
                if (int.TryParse((string)value, out intValue))
                {
                    return intValue;
                }
            }
        }

        return defaultValue;
    }

    public static bool GetBool(this Hashtable hashtable, string key, bool defaultValue = false)
    {

        if (hashtable.ContainsKey(key))
        {
            object value = hashtable[key];
            if (value is bool)
            {
                return (bool)value;
            }
            else if (value != null)
            {
                bool boolValue;
                if (bool.TryParse((string)value, out boolValue))
                {
                    return boolValue;
                }
            }
        }

        return defaultValue;
    }

    public static float GetFloat(this Hashtable hashtable, string key, float defaultValue = 0.0f)
    {

        if (hashtable.ContainsKey(key))
        {
            object value = hashtable[key];
            if (value is double)
            {
                return (float)(double)value;
            }
            else if (value is string)
            {
                float floatvalue;
                if (float.TryParse((string)value, out floatvalue))
                {
                    return floatvalue;
                }
            }
        }

        return defaultValue;
    }

    public static Hashtable GetHashtable(this Hashtable hashtable, string key)
    {
        if (hashtable.ContainsKey(key))
        {
            object value = hashtable[key];
            if (value is Hashtable)
            {
                return (Hashtable)value;
            }
        }

        return new Hashtable();
    }

}