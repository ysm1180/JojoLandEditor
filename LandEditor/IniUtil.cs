using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace LandEditor
{
    class IniUtil
    {
        private string iniPath;

        public IniUtil(string path)
        {
            this.iniPath = path;
        }

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(
            String section,
            String key,
            String def,
            StringBuilder retVal,
            int size,
            String filePath);



        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(  // SetIniValue를 위해
            String section,
            String key,
            String val,
            String filePath);


        /// <summary>
        /// Ini 파일의 [Section] Key = value 의 값을 불러온다.
        /// </summary>
        /// <param name="Section">Section name</param>
        /// <param name="Key">Key name</param>
        /// <returns>value</returns>
        public String GetIniValue(String Section, String Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, iniPath);
            return temp.ToString();
        }

        /// <summary>
        /// [Section] Key = Value 형식으로 쓴다.
        /// </summary>
        /// <param name="Section">Section name</param>
        /// <param name="Key">Key name</param>
        /// <param name="Value">value</param>
        public void SetIniValue(String Section, String Key, String Value)
        {
            WritePrivateProfileString(Section, Key, Value, iniPath);
        }

    }
}
