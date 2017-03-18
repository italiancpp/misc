void Main()
{
	// molto becero ma funziona
  
	var path = @"C:\Users\Marco\Downloads\All'Estero.kml"; // path al file KML
	var xml = XDocument.Load(path);
	
	Console.WriteLine("Nome,Headline,Email,Web,Luogo");
	
	IEnumerable<XElement> de =
    from el in xml.Descendants("{http://www.opengis.net/kml/2.2}Placemark")
    select el;
	foreach (XElement el in de)
	{
    	Console.Write(string.Format("\"{0}\",", el.Element("{http://www.opengis.net/kml/2.2}name").Value));
		var data = el.Element("{http://www.opengis.net/kml/2.2}ExtendedData").
					Elements("{http://www.opengis.net/kml/2.2}Data");
		foreach (var d in data)
		{
			Console.Write(string.Format("\"{0}\",", d.Element("{http://www.opengis.net/kml/2.2}value").Value));
		}
		Console.WriteLine();
	}
}

// Define other methods and classes here
