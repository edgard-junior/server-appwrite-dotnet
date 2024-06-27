/*
 link from docs SDK .NET
https://github.com/appwrite/sdk-for-dotnet
*/ 

using Appwrite;
using Appwrite.Enums;
using Appwrite.Models;
using Appwrite.Services;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Windows.Forms;

namespace SDKAppWrite
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            AddListDataBase();
        }

        public async Task<int> AddListDataBase()
        {
            int pag = 0;
            long total = 0;
            DatabaseList todoDatabase = await GetDataBasePagnation(0);
            total = todoDatabase.Total;

            while (total > 0)
            {
                DatabaseList dataBaseApp = await GetDataBasePagnation(pag);
                foreach (var db in dataBaseApp.Databases)
                {
                    lstDataBase.Items.Add($"{db.Id} | {db.Name}");
                }
                pag = pag + 25;
                total = total - 25;
            }

            return lstDataBase.Items.Count;
        }

        public async Task<DatabaseList> GetDataBasePagnation(int pag = 0)
        {
            List<string> mylist = new List<string>(new string[] { "limit(25)", $"offset({pag})" });
            DatabaseList dataBaseApp = await GetDataBases(mylist);
            return dataBaseApp;
        }

        static async Task<DatabaseList> GetDataBases(List<string> mylist)
        {
            var apikey = new ApiKeys();

            var client = new Client()
                            .SetEndpoint(apikey.EndPoint)
                            .SetProject(apikey.Project) // Your project ID
                            .SetKey(apikey.ApiKey);

            var databases = new Databases(client);

            DatabaseList todoDatabase;

            todoDatabase = await databases.List(mylist);
            return todoDatabase;
        }

        public async Task<string> UpdateDataBase()
        {
            var apikey = new ApiKeys();

            var client = new Client()
                            .SetEndpoint(apikey.EndPoint)
                            .SetProject(apikey.Project) // Your project ID
                            .SetKey(apikey.ApiKey);

            var databases = new Databases(client);

            progressBar1.Value = 0;
            progressBar1.Maximum = lstDataBase.Items.Count;
            for (int i = 0; i < lstDataBase.Items.Count; i++)
            {
                if (lstDataBase.GetItemChecked(i))
                {
                    string itemList = lstDataBase.Items[i].ToString();
                    string[] _split = itemList.Split("|");
                    var ok = await UpdateData(_split[0], databases);

                };
                progressBar1.Value = i;
            }
            progressBar1.Value = lstDataBase.Items.Count;
            return "appWrite";

        }

        static async Task<bool> UpdateData(string idDataBase, Databases databases)
        {
            bool ok = false;
            string collectionName = "COLLECTION_NAME";

            try
            {
                Collection result = await databases.GetCollection(databaseId: $"{idDataBase.Trim()}", collectionId: collectionName);
                ok = true;
            }
            catch (AppwriteException e)
            {
                try
                {
                    Collection result = await databases.CreateCollection($"{idDataBase.Trim()}", collectionName, collectionName,
                    [Permission.Read(Role.User("user_id")),
                     Permission.Create(Role.User("user_id")),
                     Permission.Update(Role.User("user_id"))
                     ]);

                    CreateAtributte(databases, $"{idDataBase.Trim()}", collectionName, "int_att", TypeAtt.Int, 0, true);
                    CreateAtributte(databases, $"{idDataBase.Trim()}", collectionName, "str_att", TypeAtt.Str, 5, true);
                    CreateAtributte(databases, $"{idDataBase.Trim()}", collectionName, "float_att", TypeAtt.Float);
                    CreateAtributte(databases, $"{idDataBase.Trim()}", collectionName, "datatime_att", TypeAtt.Date);
                }
                catch (AppwriteException e1)
                {
                    Console.WriteLine(e1.Message);
                }

            }

            return ok;
        }

        public enum TypeAtt
        {
            Str,
            Int,
            Float,
            Date
        }

        static private async void CreateAtributte(Databases databases, string dataBaseId, string collectionID, string Name, TypeAtt Kind, long Size = 0,  bool Require1 = false)
        {
            switch (Kind)
            {
                case TypeAtt.Str:
                    AttributeString result = await databases.CreateStringAttribute(databaseId: $"{dataBaseId.Trim()}", collectionId: $"{collectionID.Trim()}", key: $"{Name.Trim()}", size: Size, required: Require1); 
                    break;
                case TypeAtt.Int:
                    AttributeInteger result1 = await databases.CreateIntegerAttribute(databaseId: $"{dataBaseId.Trim()}", collectionId: $"{collectionID.Trim()}", key: $"{Name.Trim()}", required: Require1, min: 0); 
                    break;
                case TypeAtt.Float:
                    AttributeFloat result2 = await databases.CreateFloatAttribute(databaseId: $"{dataBaseId.Trim()}", collectionId: $"{collectionID.Trim()}", key: $"{Name.Trim()}", required: Require1, min: 0); 
                    break;
                case TypeAtt.Date:
                    AttributeDatetime result3 = await databases.CreateDatetimeAttribute(databaseId: $"{dataBaseId.Trim()}", collectionId: $"{collectionID.Trim()}", key: $"{Name.Trim()}", required: Require1,""); 
                    break;
            }
            await Task.Delay(2000);
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
          string teste = await UpdateDataBase();
        }

        private void CheckAllList(bool enabled = false)
        {
            for (int i = 0; i < lstDataBase.Items.Count; i++)
            {
                lstDataBase.SetItemChecked(i, enabled);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int input = (lstDataBase.Tag is null) ? 1 : 0;
            bool check = (input != 0);

            if (check)
            {
                lstDataBase.Tag = 0;
                button2.Text = "UncheckedAll";
            }
            else
            {
                lstDataBase.Tag = null;
                button2.Text = "CheckedAll";
            }
            CheckAllList(check);
        }
    }
}
