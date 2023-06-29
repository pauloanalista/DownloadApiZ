using System;
using System.IO;
using System.Reflection;
using LibGit2Sharp;
using static System.Net.Mime.MediaTypeNames;

namespace DownloadApi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            string path = @"c:\apizap";
            Console.WriteLine($"Baixando fonte atualizado da api no diretório {path}");

            if (Directory.Exists(path))
            {
                Console.WriteLine("Exclua os arquivos do diretorio " + path);
                Console.ReadKey();
            }

            CriaDiretorio(path);
            Console.ReadKey();
        }

        private static void ExcluirDiretorio(string path)
        {
            try
            {
                Directory.Delete(path, true);
            }
            catch (Exception e)
            {
                Console.WriteLine("Falha ao excluir - Processo falhou: {0}", e.ToString());
            }
            finally { }
        }

        private static void CriaDiretorio(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    DownloadApi(path);


                    return;
                }

                DirectoryInfo di = Directory.CreateDirectory(path);
                DownloadApi(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Processo falhou: {0}", e.ToString());
            }
            finally { }
        }

        private static void DownloadApi(string localPath)
        {
            string repositoryUrl = "https://github.com/salman0ansari/whatsapp-api-nodejs.git";

            CloneOptions options = new CloneOptions
            {
                IsBare = false,
                Checkout = true,
                CredentialsProvider = (_url, _user, _cred) =>
                    new UsernamePasswordCredentials
                    {
                        Username = "nebir38749dotvillacom",
                        Password = "nebir38749@dotvilla.com"
                    }
            };

            Repository.Clone(repositoryUrl, localPath, options);

            Console.WriteLine("Download realizado com sucesso!");
        }
    }
}
