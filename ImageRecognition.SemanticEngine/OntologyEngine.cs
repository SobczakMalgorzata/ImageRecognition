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
        public IGraph buildingOntology;
        public OntologyEngine() {
            OntologyGraph g = new OntologyGraph();
            IGraph gr = new OntologyGraph();
            gr.LoadFromFile("budynek1.owl");
            IGraph gr1 = new OntologyGraph();
            gr1.LoadFromFile("new.owl");

            string stringUri = "http://example.org";
            g.BaseUri = new Uri(stringUri);
            //XmlWriter xml = XmlWriter.Create("xml");

            //Create some Objects Literal
            INode roofClass = g.CreateUriNode(new Uri(stringUri + "/roofClass"));
            INode wallClass = g.CreateUriNode(new Uri(stringUri + "/wallClass"));
            INode windowClass = g.CreateUriNode(new Uri(stringUri + "/windowClass"));
            INode doorClass = g.CreateUriNode(new Uri(stringUri + "/doorClass"));


            INode roof = g.CreateUriNode(new Uri(stringUri + "/roof"));
            INode wall = g.CreateUriNode(new Uri(stringUri + "/wall"));
            INode window = g.CreateUriNode(new Uri(stringUri + "/window"));
            INode door = g.CreateUriNode(new Uri(stringUri + "/door"));

            OntologyClass roofClassInstance = g.CreateOntologyClass(roofClass);
            OntologyClass wallClassInstance = g.CreateOntologyClass(wallClass);
            OntologyClass windowClassInstance = g.CreateOntologyClass(windowClass);
            OntologyClass doorClassInstance = g.CreateOntologyClass(doorClass);

            Individual roofObject = g.CreateIndividual(roof, roofClass);
            Individual wallObject = g.CreateIndividual(wall, wallClass);
            Individual windowObject = g.CreateIndividual(window, windowClass);

            INode above = g.CreateUriNode(new Uri(stringUri + "/above"));
            INode below = g.CreateUriNode(new Uri(stringUri + "/below"));
            INode within = g.CreateUriNode(new Uri(stringUri + "/within"));

            //Create some Triples
            Triple roofAboveWall = new Triple(roof, above, wall);
            Triple roofAboveWindow = new Triple(roof, above, window);
            Triple roofAboveDoor = new Triple(roof, above, door);
            Triple doorWithinWall = new Triple(door, within, wall);
            Triple windowWithinWall = new Triple(window, within, wall);
            OntologyProperty RoofColor = new OntologyProperty(roof, g);
            
            g.Assert(roofAboveWall);
            g.Assert(roofAboveWindow);
            g.Assert(roofAboveDoor);
            g.Assert(doorWithinWall);
            g.Assert(windowWithinWall);
            //roofAboveWall.WriteXml(xml);

            List<Triple> ans = (List<Triple>)g.GetTriplesWithPredicate(above);
            Triple ans1 = ans[ans.IndexOf(roofAboveDoor)];

            buildingOntology = gr1;
            gr1.SaveToFile("building_try.rdf");
            g.SaveToFile("building.rdf");

        }
    }
}
