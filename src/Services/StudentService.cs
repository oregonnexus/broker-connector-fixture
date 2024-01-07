using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using OregonNexus.Broker.Connector.Configuration;
using OregonNexus.Broker.Domain;
using OregonNexus.Broker.Connector.StudentLookup;
using OregonNexus.Broker.Connector.Student;

namespace OregonNexus.Broker.Connector.Fixture.Services;

public class StudentService : IStudentService
{
    public Task<IStudent?> FetchAsync(Domain.Student studentParameters)
    {
        return Task.Run(() => {
        
            var students = new List<Models.Student>
            {
                new Models.Student
                {
                    FixtureStudentNumber = "232323"
                },
                new Models.Student
                {
                    FixtureStudentNumber = "234933"
                }
            };

            var filteredStudents = students.Where(
                x => x.FixtureStudentNumber!.ToLower().Contains(studentParameters.StudentNumber!)
                ).FirstOrDefault();
            
            return filteredStudents as IStudent;
        });
    }
}