using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Net.Http;
using System;

namespace PostcodeAnywhereLookup
{
  public class Service
  {
    string endpoint;
    public Service(string endpoint)
    {
        this.endpoint = endpoint;
    }

    public async Task<PostOfficeAddress[]> Lookup(string postcode, string houseNumber = null)
    {
      var url = endpoint + "?data=address&task=propertylookup&fields=raw&lookup=" + postcode;
      url = string.IsNullOrWhiteSpace(houseNumber) ? url : url + "," + houseNumber;
      using (var httpClient = new HttpClient())
      {
        using (var xml = await httpClient.GetStreamAsync(new Uri(url)))
        {
          var serializer = new XmlSerializer(typeof(AFDPostcodeEverywhere));
          var aFDPostcodeEverywhere = (AFDPostcodeEverywhere)serializer.Deserialize(xml);
          return aFDPostcodeEverywhere.Item;
        }
      }
    }
  }
}
