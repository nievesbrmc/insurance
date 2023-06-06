using System.Collections.Generic;

namespace WpfApp1.Entity
{
    public class EndorsementList
    {
        public string codigo { get; set; }
        public bool response { get; set; }
        public string mensaje { get; set; }
        public IEnumerable<DocumentData> data { get; set; }
}
    public class DocumentData
    {
        public int id { get; set; }
        public string valor { get; set; }
        public string descripcion { get; set; }
        public RequiredDocument documentosRequeridos { get; set; }
        public List<string> datosRequeridos { get; set; }
    }
    public class RequiredDocument
    {
        public FisicalPerson personaFisica { get; set; }
        public MoralPerson personaMoral { get; set; }
    }
    public class FisicalPerson
    {
        public string documentosVehiculo { get; set; }
        public string documentosAsegurado { get; set; }
        public string documentosQualitas { get; set; }
    }

    public class MoralPerson:FisicalPerson
    {}
    public class DocumentList
    {
        public string DocumentDescription { get; set; }
        public string ToolTip { get; set; }
    }
    public class DocumentType
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
    public class PolicyData
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}