﻿using System.Collections.Generic;

namespace WpfApp1.Entity
{
    public class EndorsementData
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string ColorStatus { get; set; }
        public string DateRegister { get; set; }
        public string Judgment { get; set; }
        public DocumentData data { get; set; }
        public string ButtonText { get; set; }
    }

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
        public string Value { get; set; }
        public byte[] DocumentValue { get; set; }
        public bool FillValue { get; set; }
        public string TextInput { get; set; }
        public string BtnUpload { get; set; }
        public string BtnText { get; set; }
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