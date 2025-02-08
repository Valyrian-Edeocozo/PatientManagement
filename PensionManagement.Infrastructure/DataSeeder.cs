using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PatientMangementApi.PensionManagement.Domain;

namespace PatientMangementApi.PensionManagement.Infrastructure
{
    public class DataSeeder
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());


            if (context.Patients.Any())
            {
                //Do nothing
            }
            if (!context.Patients.Any())
            {
                context.Patients.AddRange(new List<Patient>{
                        new Patient{
                            Id = 1,
                            FirstName = "Ozoeze",
                            LastName = "Boniface",
                            DateOfBirth = DateTime.ParseExact("1995-05-31", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                            DateCreated = DateTime.Now,
                            PatientRecords = new List<PatientRecord>{
                                new PatientRecord {
                                    PatientId = 1,
                                    Description = "5ft 6', 75kg, Malaria parasite",
                                    RecordDate = DateTime.Now,
                                    DateCreated = DateTime.Now,
                                }
                            }
                        },
                        new Patient{
                            Id = 2,
                            FirstName = "John",
                            LastName = "Doe",
                            DateOfBirth = DateTime.ParseExact("1995-01-30", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                            DateCreated = DateTime.Now,
                            PatientRecords = new List<PatientRecord>{
                                new PatientRecord {
                                    PatientId = 2,
                                    Description = "5ft 6', 75kg, Malaria parasite",
                                    RecordDate = DateTime.Now,
                                    DateCreated = DateTime.Now,
                                }
                            }
                        },
                        new Patient{
                            Id = 3,
                            FirstName = "Aza",
                            LastName = "Man",
                            DateOfBirth = DateTime.ParseExact("1990-06-02", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                            DateCreated = DateTime.Now,
                            PatientRecords = new List<PatientRecord>{
                                new PatientRecord {
                                    PatientId = 3,
                                    Description = "5ft 6', 75kg, Malaria parasite",
                                    RecordDate = DateTime.Now,
                                    DateCreated = DateTime.Now,
                                }
                            }
                        }
                });

                await context.SaveChangesAsync();
            }

        }
    }
}