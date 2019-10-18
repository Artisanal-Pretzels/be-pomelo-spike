using Google.Maps;
using Google.Maps.DistanceMatrix;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace be_pomelo_spike
{
  public class gapi
  {
    public gapi()
    {
    }

    public void getData()
    {
      GoogleSigned.AssignAllServices(new GoogleSigned("API KEY"));

      DistanceMatrixRequest request = new DistanceMatrixRequest();
			//sheffield
			request.AddDestination(new LatLng(latitude: 53.378243m, longitude: -1.462131m));
			//rotherham
			request.AddOrigin(new LatLng(latitude: 53.434297m,longitude: -1.364678m));

			request.Mode = TravelMode.driving;

      var data = new DistanceMatrixService().GetResponse(request);

      Console.WriteLine(data.Rows);
    }

    public void webReq() //API KEY
    {
      string url = @"https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=Washington,DC&destinations=New+York+City,NY&key=API KEY";

      WebRequest request = WebRequest.Create(url);

      WebResponse response = request.GetResponse();

      Stream data = response.GetResponseStream();

      StreamReader reader = new StreamReader(data);

      // json-formatted string from maps api
      string responseFromServer = reader.ReadToEnd();

      Console.WriteLine(responseFromServer);

      response.Close();
    }
  }
}