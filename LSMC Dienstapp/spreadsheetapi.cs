using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace LSMC_Dienstapp
{
    class spreadsheetapi
    {
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        public static string ApplicationName = "TimeSheetUpdation By Cybria Technology";
        public static string SheetId = "Your sheet id ";
        public static SheetsService service;

        public spreadsheetapi(string AppName = "", string SId = "")
        {
            ApplicationName = AppName;
            SheetId = SId;
            AuthorizeGoogleApp();
        }

        public void updateTable(string range, IList<IList<Object>> inhalt)
        {
            UpdatGoogleSheetinBatch(inhalt, SheetId, range);
        }

        private static void AuthorizeGoogleApp()
        {
            UserCredential credential;

            string credPath = System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.Personal);
            if (!File.Exists(credPath + "/credentials.json"))
            {
                StreamWriter sw = new StreamWriter(credPath + "/credentials.json");
                sw.WriteLine("{\"installed\":{\"client_id\":\"358347084101-mkv6agit5o3kvab63lm138030d4f9iag.apps.googleusercontent.com\",\"project_id\":\"gvmp-lsmc\",\"auth_uri\":\"https://accounts.google.com/o/oauth2/auth\",\"token_uri\":\"https://oauth2.googleapis.com/token\",\"auth_provider_x509_cert_url\":\"https://www.googleapis.com/oauth2/v1/certs\",\"client_secret\":\"Lnejb1P1SmJFHOtFtyAvYjgm\",\"redirect_uris\":[\"urn:ietf:wg:oauth:2.0:oob\",\"http://localhost\"]}}");
                sw.Close();
            }
            using (var stream =
               new FileStream(credPath + "/credentials.json", FileMode.Open, FileAccess.Read))
            {
                credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Sheets API service.
            service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            
        }

        protected static string GetRange(SheetsService service)
        {
            // Define request parameters.
            String spreadsheetId = SheetId;
            String range = "A:A";

            SpreadsheetsResource.ValuesResource.GetRequest getRequest =
                       service.Spreadsheets.Values.Get(spreadsheetId, range);

            ValueRange getResponse = getRequest.Execute();
            IList<IList<Object>> getValues = getResponse.Values;

            int currentCount = getValues.Count() + 1;

            String newRange = "A" + currentCount + ":A";

            return newRange;
        }

        protected static string SetRange(string position)
        {
            // Define request parameters.
            String spreadsheetId = SheetId;
            string range = position;

            SpreadsheetsResource.ValuesResource.GetRequest getRequest = service.Spreadsheets.Values.Get(spreadsheetId, range);

            ValueRange getResponse = getRequest.Execute();
            IList<IList<Object>> getValues = getResponse.Values;

            String newRange = range;

            return newRange;
        }

        private static IList<IList<Object>> GenerateData()
        {
            List<IList<Object>> objNewRecords = new List<IList<Object>>();

            IList<Object> obj = new List<Object>();

            obj.Add("Column - 1");
            obj.Add("Column - 2");
            obj.Add("Column - 3");

            objNewRecords.Add(obj);

            return objNewRecords;
        }

        private static void UpdatGoogleSheetinBatch(IList<IList<Object>> values, string spreadsheetId, string newRange)
        {
            SpreadsheetsResource.ValuesResource.UpdateRequest request =
               service.Spreadsheets.Values.Update(new ValueRange() { Values = values }, spreadsheetId, newRange);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
            var response = request.Execute();
        }

        private static IList<IList<Object>> LoadGoogleSheet(string spreadsheetId, string Range)
        {
            SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(spreadsheetId, Range);
            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;

            return values;
        }

        public IList<IList<Object>> GetSheetData(string Range)
        {
            return LoadGoogleSheet(SheetId, Range);
        }
    }
}
