using System;
using System.IO;
using System.Text;

namespace iBlog.DTS.Util
{
    public static class FileHelper
    {
        #region 创建路径

        /// <summary>
        /// 创建路径
        /// </summary>
        /// <param name="path"></param>
        public static bool CreatePath(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                return true;
            }
            return false;
        }

        #endregion 创建路径

        #region 保存图片

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="bt"></param>
        public static void SaveImage(string filePath, byte[] bt)
        {
            try
            {
                File.WriteAllBytes(filePath, bt);
            }
            catch (Exception)
            {
            }
        }

        #endregion 保存图片

        #region 保存文本文件

        public static void SaveTxtFile(string filePath, string fileName, string txtStr, bool isCover = true)
        {
            try
            {
                CreatePath(filePath);
                if (isCover)
                    File.WriteAllText(filePath + fileName, txtStr, Encoding.Default);
                else
                    File.AppendAllText(filePath + fileName, txtStr, Encoding.Default);
            }
            catch (Exception)
            {
            }
        }

        #endregion 保存文本文件

        #region 过滤文件名中特殊字符

        public static string FilterInvalidChar(string fileName, string replaceStr)
        {
            foreach (var c in Path.GetInvalidFileNameChars())
            {
                fileName = fileName.Replace(c.ToString(), replaceStr);
            }
            return fileName;
        }

        #endregion 过滤文件名中特殊字符
    }
}