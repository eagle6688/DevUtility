using DevUtility.Com.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace DevUtility.Com.IO.Files
{
    public class CsvHelper
    {
        #region Get data

        public static DataTable GetData(string path, string encodingName = "")
        {
            if (!File.Exists(path))
            {
                return null;
            }

            string extension = Path.GetExtension(path);

            if (!extension.Equals(".csv"))
            {
                return null;
            }

            DataTable table = new DataTable();
            table.TableName = Path.GetFileNameWithoutExtension(path);
            Encoding encoding = EncodingHelper.GetEncoding(encodingName);

            using (StreamReader streamReader = new StreamReader(path, encoding))
            {
                string line = "";

                while (!string.IsNullOrEmpty((line = streamReader.ReadLine())))
                {
                    string[] cells = line.Split(',');

                    if (cells == null || cells.Length == 0)
                    {
                        continue;
                    }

                    if (table.Columns.Count < cells.Length)
                    {
                        for (int i = table.Columns.Count; i < cells.Length; i++)
                        {
                            table.Columns.Add(i.ToString());
                        }
                    }

                    DataRow row = table.NewRow();

                    for (int i = 0; i < cells.Length; i++)
                    {
                        row[i] = cells[i];
                    }

                    table.Rows.Add(row);
                }
            }

            return table;
        }

        #endregion

        #region Save

        public static void Save(string path, DataTable table, string encodingName = "")
        {
            if (table == null || table.Rows.Count == 0)
            {
                return;
            }

            DirectoryHelper.CreatByPath(path);

            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                Encoding encoding = EncodingHelper.GetEncoding(encodingName);

                using (StreamWriter streamWriter = new StreamWriter(fileStream, encoding))
                {
                    StringBuilder content = new StringBuilder();

                    foreach (DataRow row in table.Rows)
                    {
                        content.Clear();

                        for (int i = 0; i < table.Columns.Count; i++)
                        {
                            content.Append(row[i]);
                            content.Append(",");
                        }

                        content.Remove(content.Length - 1, 1);
                        streamWriter.WriteLine(content.ToString());
                    }
                }
            }
        }

        #endregion
    }
}