using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace GerenciadorDeEmpresas

{
    /// <summary>
    /// Class FileSaveRead
    /// </summary>
    public class FileSaveRead
    {
        public static string[] ReadFile(string path)
        {
            string[] text = null;
            int i = 0;
            try
            {
                StreamReader reader = new StreamReader(path);
                int numeroLinhas = System.IO.File.ReadAllLines(path).Length;
                text = new string[numeroLinhas];
                while (!reader.EndOfStream)
                {
                    text[i] = reader.ReadLine();
                    i++;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Deu ruim por que:" + ex);
            }
            return text;
        }
        /// <summary>
        /// Write in TXT
        /// </summary>
        /// <param name="path"></param>
        /// <param name="text"></param>
        public static void SaveFile(string path, string text)
        {
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine(text);
        }
        /// <summary>
        /// Write in .bin
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="content"></param>
        public static void SaveBinary<T>(string path, T content)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, content);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro: " + ex);
                throw ex;
            }
            finally
            {
                if(fs != null)
                    fs.Close();
            }
        }
        /// <summary>
        /// Read .bin
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T ReadBinary<T>(string path)
        {
            FileStream fs = null;
            T content = default(T);
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                BinaryFormatter bf = new BinaryFormatter();
                content =  (T)bf.Deserialize(fs);
            }
            catch (Exception ex)
            {
                Console.Write("ERROW: " + ex.Message);
                throw ex;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
            return content;
        }
    }
}
