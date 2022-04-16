using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JAL.Extenders
{
    public static class Strings
    {
        public static string GetStringArrayToString(this string[] arg, string delimiter = ", ")
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (string a in arg)
            {
                stringBuilder.Append(a);
                stringBuilder.Append(delimiter);
            }

            stringBuilder.Remove(stringBuilder.Length - 1 - delimiter.Length, delimiter.Length);
            return stringBuilder.ToString();
        }

        public static string GetObjectArrayToString(this object[] arg, string delimiter = ", ")
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var a in arg)
            {
                stringBuilder.Append(a.ToString());
                stringBuilder.Append(delimiter);
            }

            stringBuilder.Remove(stringBuilder.Length - 1 - delimiter.Length, delimiter.Length);
            return stringBuilder.ToString();
        }

        public static string GetMBArrayToString(this MonoBehaviour[] arg, string delimiter = ", ")
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var a in arg)
            {
                stringBuilder.Append(a.ToString());
                stringBuilder.Append(delimiter);
            }

            stringBuilder.Remove(stringBuilder.Length - 1 - delimiter.Length, delimiter.Length);
            return stringBuilder.ToString();
        }

        public static string GetGameObjectArrayToString(this GameObject[] arg, string delimiter = ", ")
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var a in arg)
            {
                stringBuilder.Append(a.ToString());
                stringBuilder.Append(delimiter);
            }

            stringBuilder.Remove(stringBuilder.Length - 1 - delimiter.Length, delimiter.Length);
            return stringBuilder.ToString();
        }

        public static string GetSceneArrayToString(this Scene[] arg, string delimiter = ", ")
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var a in arg)
            {
                stringBuilder.Append(a.name);
                stringBuilder.Append(delimiter);
            }

            stringBuilder.Remove(stringBuilder.Length - 1 - delimiter.Length, delimiter.Length);
            return stringBuilder.ToString();
        }
    }
}