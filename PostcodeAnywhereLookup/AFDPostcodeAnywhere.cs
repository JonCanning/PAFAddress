using System.Xml.Serialization;
using System.Xml;

namespace PostcodeAnywhereLookup
{
	public class AFDPostcodeEverywhere
	{
		[XmlElement(ElementName="Item")]
		public PostOfficeAddress[] Item;
		public string Result;
		public string ErrorText;
	}
}
