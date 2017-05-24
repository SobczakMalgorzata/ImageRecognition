using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDS.RDF;
using VDS.RDF.Ontology;
using VDS.RDF.Parsing;
using System.Xml;


namespace ImageRecognition.SemanticEngine
{
    public class OntologyEngine
    {
        public OntologyEngine() {
            OntologyGraph g = new OntologyGraph();
            string stringUri = "http://example.org";
            g.BaseUri = new Uri(stringUri);
            //XmlWriter xml = XmlWriter.Create("xml");

            //Create some Objects Classes
            
            INode roof = g.CreateUriNode(new Uri(stringUri + "/roof"));
            INode wall = g.CreateUriNode(new Uri(stringUri + "/wall"));
            INode window = g.CreateUriNode(new Uri(stringUri + "/window"));
            INode door = g.CreateUriNode(new Uri(stringUri + "/door"));
            INode sky = g.CreateUriNode(new Uri(stringUri + "/sky"));

            //Create Object instances

            Individual skyObject = g.CreateIndividual(sky, sky);
            Individual roofObject = g.CreateIndividual(roof, roof);
            Individual wallObject = g.CreateIndividual(wall, wall);
            Individual windowObject = g.CreateIndividual(window, window);
            Individual doorObject = g.CreateIndividual(door, door);

            //Create proprties
            
            INode above = g.CreateUriNode(new Uri(stringUri + "/above"));
            INode below = g.CreateUriNode(new Uri(stringUri + "/below"));
            INode within = g.CreateUriNode(new Uri(stringUri + "/within"));
            INode color = g.CreateUriNode(new Uri(stringUri + "/color"));

            OntologyProperty RoofColor = new OntologyProperty(roof, g);

            //Position maping

            g.Assert(new Triple(sky, above, roof));
            g.Assert(new Triple(roof, above, wall));
            g.Assert(new Triple(roof, above, window));
            g.Assert(new Triple(roof, above, door));
            g.Assert(new Triple(door, within, wall));
            g.Assert(new Triple(window, within, wall));
            //roofAboveWall.WriteXml(xml);

            g.SaveToFile("building.rdf");
            //Create some Triples
        }
    }
}
