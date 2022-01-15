
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpListenerConsole
{
    //HTTP STATUS codes.
    //https://developer.mozilla.org/pt-PT/docs/Web/HTTP/Status
    //https://pt.wikipedia.org/wiki/Lista_de_c%C3%B3digos_de_estado_HTTP

    internal class MyWebService : WebServiceBase
    {
        protected override byte ProcessAnyVerbPath(HttpListenerContext context)
        {
            HttpListenerRequest httpRequest = context.Request;
            HttpListenerResponse httpResponse = context.Response;

            byte retValue = 0;

            switch (context.Request.Url.AbsolutePath) //All possible path
            {
                case "/":
                    retValue = RootPath(httpRequest, httpResponse);
                    break;

                case "/settings":
                    retValue = SettingsPath(httpRequest, httpResponse);
                    break;

                default:
                    retValue = UndefinedPaths(httpRequest, httpResponse);
                    break;
            }

            return retValue;
        }

        private byte BasicMessageResponse(HttpListenerRequest httpRequest, HttpListenerResponse httpResponse)
        {
            //if (ConnectionHeaders(context))
            //{
            //    response.ContentType = "text/html";
            //    response.AddHeader("Connection", "keep-alive");
            //    return;
            //}

            //Write it to the response stream
            byte[] buffer = Encoding.UTF8.GetBytes("This basic message...");
            httpResponse.ContentLength64 = buffer.Length;
            httpResponse.OutputStream.Write(buffer, 0, buffer.Length);
            httpResponse.StatusCode = 200;
            httpResponse.ContentType = "text/html";

            return 0;
        }

        private byte UndefinedPaths(HttpListenerRequest httpRequest, HttpListenerResponse httpResponse)
        {
            BasicMessageResponse(httpRequest, httpResponse);

            return 0;
        }

        private byte RootPath(HttpListenerRequest httpRequest, HttpListenerResponse httpResponse)
        {
            byte retValue = 0;

            switch (httpRequest.HttpMethod) // All possible Verbs
            {
                case "GET":
                    retValue = BasicMessageResponse(httpRequest, httpResponse);
                    break;

                case "POST":
                    SetHeaders(httpResponse);

                    byte[] buffer1 = Encoding.UTF8.GetBytes(response1());
                    httpResponse.ContentLength64 = buffer1.Length;
                    httpResponse.OutputStream.Write(buffer1, 0, buffer1.Length);
                    break;

                default:
                    retValue = 1;
                    break;
            }

            return retValue;
        }

        private static byte SettingsPath(HttpListenerRequest httpRequest, HttpListenerResponse httpResponse)
        {
            byte retValue = 0;

            switch (httpRequest.HttpMethod) // All possible Verbs
            {
                case "GET":
                //Get the current settings
                httpResponse.ContentType = "application/json";

                    //This is what we want to send back
                    var responseBody = "null"; // JsonConvert.SerializeObject(MyApplicationSettings);

                    //Write it to the response stream
                    var buffer1 = Encoding.UTF8.GetBytes(responseBody);
                httpResponse.ContentLength64 = buffer1.Length;
                httpResponse.OutputStream.Write(buffer1, 0, buffer1.Length);
                    break;

                case "POST":
                //Get the current settings
                httpResponse.ContentType = "application/json";

                    //This is what we want to send back
                    int thr = Thread.CurrentThread.ManagedThreadId;
                    var responseBody2 = "{myResponse : '" + thr.ToString() + "'}";
                    // JsonConvert.SerializeObject(MyApplicationSettings);

                    //Write it to the response stream
                    var buffer2 = Encoding.UTF8.GetBytes(responseBody2);
                httpResponse.ContentLength64 = buffer2.Length;
                httpResponse.OutputStream.Write(buffer2, 0, buffer2.Length);
                    break;

                case "PUT":
                    //Update the settings
                    using (var body = httpRequest.InputStream)
                    using (var reader = new StreamReader(body, httpRequest.ContentEncoding))
                    {
                        //Get the data that was sent to us
                        var json = reader.ReadToEnd();

                    //Use it to update our settings
                    ///////////////////////UpdateSettings(JsonConvert.DeserializeObject<MySettings>(json));

                    //Return 204 No Content to say we did it successfully
                    httpResponse.StatusCode = 204;


                    }
                    break;

                default:
                    retValue = 1;
                    break;
            }

            return retValue;
        }

        private static string response1()
        {
            string resp = @"
<?xml version='1.0' encoding='utf-8'?>
<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>
<soapenv:Body>
<ns0:Getlist_AppianRemediesDetailsResponse xmlns:ns0='urn:HPD_ConsultRemedies_IntegrationAppian'>
<ns0:getListValues>
<ns0:Incident_Number>INC000000052503</ns0:Incident_Number>
<ns0:Customer_Login_ID__c>s800016</ns0:Customer_Login_ID__c>
<ns0:Company>YYYYYYYYYYYYYY Dir.Coord.Qualidade</ns0:Company>
<ns0:Unidade_Organica>6250 - Dep.Atenção ao Cliente</ns0:Unidade_Organica>
<ns0:First_Name>Ana</ns0:First_Name>
<ns0:Middle_Initial>Paula Adriao Dias</ns0:Middle_Initial>
<ns0:Last_Name>Casalinho</ns0:Last_Name>
<ns0:Status>Assigned</ns0:Status>
<ns0:Description>teste 2</ns0:Description>
<ns0:Detailed_Decription>teste 2</ns0:Detailed_Decription>
<ns0:Categorization_Tier_1>Qld - Câmara Municipal</ns0:Categorization_Tier_1>
<ns0:Categorization_Tier_2>Cred.Habit.Carteira</ns0:Categorization_Tier_2>
<ns0:Categorization_Tier_3>ACC-Agravamento Spread</ns0:Categorization_Tier_3>
<ns0:Service_Type>User Service Request</ns0:Service_Type>
<ns0:Status_Reason xsi:nil= 'true' />
<ns0:Urgency>3-Medium</ns0:Urgency>
<ns0:Impact>2-Significant/Large</ns0:Impact>
<ns0:Priority>Medium</ns0:Priority>
<ns0:Priority_Weight>15</ns0:Priority_Weight>
<ns0:Assigned_Group>Dep.de Qualidade</ns0:Assigned_Group>
<ns0:add_CaseType>Reclamação</ns0:add_CaseType>
<ns0:Reported_Source>Self Service</ns0:Reported_Source>
<ns0:Submit_Date>2015-05-25T15:31:06+01:00</ns0:Submit_Date>
<ns0:add_DataAssignado>2020-01-16T15:59:11Z</ns0:add_DataAssignado>
<ns0:Assigned_Group_ID>SGP000000000315</ns0:Assigned_Group_ID>
<ns0:Assigned_Support_Organization>Dir.Coord.Qualidade</ns0:Assigned_Support_Organization>
<ns0:Assigned_Support_Company>Dir.Coord.Qualidade</ns0:Assigned_Support_Company>
<ns0:Last_Modified_By>appadmin</ns0:Last_Modified_By>
<ns0:Last_Modified_Date>2020-01-16T15:59:21Z</ns0:Last_Modified_Date>
</ns0:getListValues>
</ns0:Getlist_AppianRemediesDetailsResponse>
</soapenv:Body>
</soapenv:Envelope>
";

            return resp.Trim().Replace("\r\n","");
        }
    }
}
//request
//<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/"><SOAP-ENV:Header><AuthenticationInfo><userName>appian_admin</userName><password>password</password><authentication/><locale/><timeZone/></AuthenticationInfo></SOAP-ENV:Header><SOAP-ENV:Body><ns2:Getlist_AppianRemediesDetails xmlns:ns2="urn:HPD_ConsultRemedies_IntegrationAppian"><ns2:Incident_ID>INC000000052503</ns2:Incident_ID></ns2:Getlist_AppianRemediesDetails></SOAP-ENV:Body></SOAP-ENV:Envelope>


//<SOAP-ENV:Envelope xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/">
//<SOAP-ENV:Header>
//<AuthenticationInfo>
//<userName>appian_admin</userName>
//<password>password</password>
//<authentication/>
//<locale/>
//<timeZone/>
//</AuthenticationInfo>
//</SOAP-ENV:Header>
//<SOAP-ENV:Body>

//<ns2:Getlist_AppianRemediesDetails xmlns:ns2="urn:HPD_ConsultRemedies_IntegrationAppian">
//<ns2:Incident_ID>INC000000052503</ns2:Incident_ID>
//</ns2:Getlist_AppianRemediesDetails>
//</SOAP-ENV:Body>

//</SOAP-ENV:Envelope>