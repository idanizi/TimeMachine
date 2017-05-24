using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Threading;

namespace TimeMachine.Service.Agents
{
    public class GoogleCalendarAgent : IAgent
    {
        #region Constants
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/calendar-dotnet-quickstart.json
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };

       

        static string ApplicationName = "TimeMachineClient2";
        #endregion

        #region Fields
        private HttpClient conn = default(HttpClient);
        private string requestUri;

        #endregion

        #region Properties
        public double TotalFreeTime { get; set; }

        #endregion

        #region Constructors
        public GoogleCalendarAgent()
        {
            conn = new HttpClient();
            requestUri = string.Empty; // undone
        }

        #endregion

        #region Private Functions

        #endregion

        #region Methods

        public void Clear()
        {
            // TODO: clean resources
        }

        public string FirstTest()
        {
            var result = "";

            UserCredential credential;

            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/calendar-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Calendar API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = request.Execute();
            result += string.Format("Upcoming events:\n");
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    string when = eventItem.Start.DateTime.ToString();
                    if (String.IsNullOrEmpty(when))
                    {
                        when = eventItem.Start.Date;
                    }
                    result += string.Format("{0} ({1})\n", eventItem.Summary, when);
                }
            }
            else
            {
                result += string.Format("No upcoming events found.\n");
            }

            return result;
        }
        #endregion
    }
}
