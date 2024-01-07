using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using OregonNexus.Broker.Connector.Configuration;
using OregonNexus.Broker.Connector.Student;

namespace OregonNexus.Broker.Connector.Fixture.Models;

public class Student : IStudent
{
    [DataType(DataType.Text)]
    [Description("Fixture student number")]
    public string? FixtureStudentNumber { get; set; }
}