using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using OregonNexus.Broker.Connector.Configuration;
using OregonNexus.Broker.Domain;
using OregonNexus.Broker.Connector.StudentLookup;
using OregonNexus.Broker.Connector.Student;

namespace OregonNexus.Broker.Connector.Fixture.Services;

public class StudentLookupService : IStudentLookupService
{
    public Task<List<StudentLookupResult>> SearchAsync(Domain.Student studentParameters)
    {
         return Task.Run(() => {
        
            var students = new List<StudentLookupResult>
            {
                new StudentLookupResult
                {
                    StudentId = "232323",
                    FirstName = "John",
                    MiddleName = "JoM",
                    LastName = "Doe",
                    BirthDate = new DateOnly(2000, 1, 3),
                    Gender = Gender.Male.ToString(),
                    Grade = "10",
                    Additional = new Dictionary<string, object> { 
                        [typeof(Models.Student).FullName!] = new Models.Student()
                            {
                                FixtureStudentNumber = "232323"
                            }
                        }
                },
                new StudentLookupResult
                {
                    StudentId = "234933",
                    FirstName = "Jane",
                    MiddleName = "JaM",
                    LastName = "Doe",
                    BirthDate = new DateOnly(2003, 4, 5),
                    Gender = Gender.Female.ToString(),
                    Grade = "05",
                    Additional = new Dictionary<string, object> { 
                        [typeof(Models.Student).FullName!] = new Models.Student()
                        {
                            FixtureStudentNumber = "234933"
                        }
                    }
                }
            };

            var filteredStudents = students.Where(
                x => x.StudentId!.ToLower().Contains(studentParameters.StudentNumber!)
                 ||  (x.FirstName is not null && x.FirstName.ToLower().Contains(studentParameters.FirstName!))
                 ||  (x.LastName is not null && x.LastName.ToLower().Contains(studentParameters.LastName!))
                 ||  (x.MiddleName is not null && x.MiddleName.ToLower().Contains(studentParameters.MiddleName!))
                ).ToList();
            
            return filteredStudents;
        
        });
    }
}