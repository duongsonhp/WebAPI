using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Enums;
using System.Security.Permissions;
using File = System.IO.File;
using ConfigurationFile = Utilities.Enums.File.ConfigurationFile;
using LogFile = Utilities.Enums.File.LogFile;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Utilities
{
    public class FileUtility
    {
        public static List<string> Read(string filePath)
        {
            return File.ReadAllLines(filePath).ToList();
        }

        public static string ReadLine(string filePath, int line)
        {
            if (line <= 0)
            {
                return "$ERROR$";
            }

            return File.ReadAllLines(filePath).ToList()[line - 1];
        }

        /// <summary>
        /// Đọc mục cấu hình trong file cấu hình
        /// File cấu hình, mỗi mục cấu hình là 1 dòng
        /// Mỗi dòng có dạng: {Tên cấu hình}::{Nội dung cấu hình}
        /// </summary>
        /// <param name="filePath">ĐƯờng dẫn file</param>
        /// <param name="section">Tên mục cấu hình</param>
        /// <returns></returns>
        public static string ReadSection(string filePath, string section)
        {
            using (StreamReader file = new StreamReader(filePath))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    var segments = line.Split("::");
                    if (segments == null || !segments.Any() || segments.Count() != 2)
                    {
                        continue;
                    }

                    string configurationName = segments[0];
                    string configurationValue = segments[1];

                    if (configurationName.Equals(section))
                    {
                        file.Close();
                        return configurationValue;
                    }
                }

                file.Close();
                return "$ERROR$";
            }
        }

        /// <summary>
        /// Đọc mục cấu hình trong file cấu hình
        /// File cấu hình, mỗi mục cấu hình là 1 dòng
        /// Mỗi dòng có dạng: {Tên cấu hình}::{Nội dung cấu hình}
        /// </summary>
        /// <param name="fileType">Loại file cấu hình</param>
        /// <param name="section">Tên mục cấu hình</param>
        /// <returns></returns>
        public static string ReadSection(ConfigurationFile fileType, string section)
        {
            string filePath = "";

            if (fileType == ConfigurationFile.ConnectionConfiguration)
            {
                filePath = "E:\\Source\\CSharp\\College\\DataLayer\\DataInformation\\ConnectionInformation.txt";
            }
            else if (fileType == ConfigurationFile.ConnectionConfiguration2)
            {
                filePath = "E:\\Source\\CSharp\\College\\DataLayer\\DataInformation\\ConnectionInformation2.txt";
            }

            WriteContent(LogFile.ErrorLog, new List<string>() { $"[{DateTime.Now.ToString()}] Test" });

            // WriteContent(LogFile.ErrorLog, new List<string>() { $"[{DateTime.Now.ToString()}] connection file = {filePath}" });

            using (StreamReader file = new StreamReader(filePath))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    var segments = line.Split("::");
                    if (segments == null || !segments.Any() || segments.Count() != 2)
                    {
                        continue;
                    }

                    string configurationName = segments[0];
                    string configurationValue = segments[1];

                    if (configurationName.Equals(section))
                    {
                        // WriteContent(LogFile.ErrorLog, new List<string>() { $"[{DateTime.Now.ToString()}] connection string = {configurationValue}" });
                        file.Close();
                        return configurationValue;
                    }
                }

                file.Close();
                return "$ERROR$";
            }
        }

        /// <summary>
        /// Đọc mục cấu hình trong file cấu hình
        /// File cấu hình, mỗi mục cấu hình là 1 dòng
        /// Mỗi dòng có dạng: {Tên cấu hình}::{Nội dung cấu hình}
        /// </summary>
        /// <param name="fileType">Loại file cấu hình</param>
        /// <param name="section">Tên mục cấu hình</param>
        /// <returns></returns>
        public static string WriteContent(LogFile logFileType, List<string> contents)
        {
            string filePath = "";
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var buildedConfiguration = builder.Build();

            if (logFileType == LogFile.ErrorLog)
            {
                // filePath = "E:\\Source\\CSharp\\College\\Utilities\\Log\\Error20231127.txt";
                filePath = buildedConfiguration.GetSection("LogFilePaths").GetSection("Error").Value;
            }

            using (StreamWriter file = new StreamWriter(filePath, true))
            {
                foreach (var content in contents)
                {
                    file.WriteLine(content);
                }

                file.Close();
                return "";
            }
        }
    }
}
