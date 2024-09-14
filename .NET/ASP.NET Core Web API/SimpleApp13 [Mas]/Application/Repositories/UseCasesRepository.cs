using Application.Database;
using Application.Database.Models.AddressPart;
using Application.Repositories.DTOs;
using Application.Repositories.DTOs.DocumentPart;
using Application.Repositories.DTOs.EmploeePart;
using Application.Repositories.DTOs.EmploeePart.MethodGet;
using Application.Repositories.DTOs.EmploeePart.MethodGetForList;
using Application.Repositories.DTOs.GetPersonByPesel;
using Domain.Entites.DepartmentPart;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public class UseCasesRepository : IUseCasesRepository
    {
        private readonly BankDbContext _context;
        public UseCasesRepository(BankDbContext context)
        {
            _context = context;
        }

        //Person part Ok
        public async Task<SingleObjectResponse<DTOs.GetPersonByPesel.PersonDtoResponse>> GetPersonByPeselAsync(string pesel)
        {
            try
            {
                var Pesel = new Pesel(pesel);
                var person = await _context.People.Where(x => x.Pesel == Pesel.Value)
                    .Include(x => x.Client).ThenInclude(x => x.Employee)
                    .Include(x => x.Employee)
                    .Include(x => x.Documents).ThenInclude(x => x.DocumentType)
                    .Select(x => new DTOs.GetPersonByPesel.PersonDtoResponse
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        BirthDate = x.BirthDate,
                        Email = x.Email,
                        PhoneNumber = x.PhoneNumber,
                        Pesel = x.Pesel,
                        IsPep = (string.IsNullOrWhiteSpace(x.LastPositionPep)),
                        LastPositionPep = x.LastPositionPep,
                        EmployeeProfile = (x.Employee == null) ? null : new DTOs.GetPersonByPesel.EmployeeDtoResponse
                        {
                            Id = x.Employee.Id,
                            Position = x.Employee.Position,
                            Competences = x.Employee.Competences
                                        .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries) // Przekształć w tablicę znaków
                                        .ToList(),
                        },
                        ClientProfile = (x.Client == null) ? null : new DTOs.GetPersonByPesel.ClientDtoResponse
                        {
                            Id = x.Client.Id,
                            AccountNumber = x.Client.AccountNumber,
                            AccountManager = (x.Client.Employee == null) ? null : new DTOs.GetPersonByPesel.EmployeeDtoResponse
                            {
                                Id = x.Client.Employee.Id,
                                Position = x.Client.Employee.Position,
                                Competences = x.Client.Employee.Competences
                                        .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries) // Przekształć w tablicę znaków
                                        .ToList(),
                            }
                        },
                        Documents = x.Documents.Select(z => new DTOs.GetPersonByPesel.DocumentDtoResponse
                        {
                            Id = z.Id,
                            Number = z.Number,
                            Country = z.Country,
                            From = z.From,
                            To = z.To,
                            DocumentType = z.DocumentType.Name,
                        }).ToList()
                    }).FirstOrDefaultAsync();
                if (person == null)
                {
                    return new SingleObjectResponse<DTOs.GetPersonByPesel.PersonDtoResponse>
                    {
                        IsSuccess = false,
                        Message = "Value not exist",
                        Value = null
                    };
                }
                return new SingleObjectResponse<DTOs.GetPersonByPesel.PersonDtoResponse>
                {
                    IsSuccess = true,
                    Message = "Exist",
                    Value = person,
                };
            }
            catch (Exception ex)
            {
                return new SingleObjectResponse<DTOs.GetPersonByPesel.PersonDtoResponse>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Value = null,
                };
            }
        }

        public async Task<DTOs.Response> PersonCreateProfileAsync(DTOs.PersonCreateProfile.PersonDtoRequest req)
        {
            try
            {
                var pesel = new Pesel(req.Pesel);

                var unique = _context.People.Where
                    (x =>
                    x.Pesel == req.Pesel || x.PhoneNumber == req.PhoneNumber || x.Email == req.Email)
                    .FirstOrDefault();

                if (unique != null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Number Pesel Or PhoneNumber or Email uncorrect"
                    };
                }

                var colocation = await _context.CollocationsDivisionsAndStreets
                   .Where(x =>
                   x.DivisionId == req.Adress.DivisionId &&
                   x.StreetId == req.Adress.StreetId
                   ).FirstOrDefaultAsync();

                if (colocation == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Address Data uncorrect"
                    };
                }

                var doamin = new Domain.Entites.PersonPart.Person
                    (
                    req.FirstName,
                    req.HandName,
                    req.LastName,
                    req.BirthDate,
                    req.Email,
                    req.PhoneNumber,
                    req.Pesel,
                    req.IsPep,
                    req.LastPositionPep
                    );

                await _context.People.AddAsync(new Database.Models.PersonPart.Person
                {
                    FirstName = req.FirstName,
                    HandName = req.HandName,
                    LastName = req.LastName,
                    BirthDate = req.BirthDate,
                    Email = req.Email,
                    PhoneNumber = req.PhoneNumber,
                    Pesel = req.Pesel,
                    LastPositionPep = (!req.IsPep) ? (string)(null) : req.LastPositionPep,
                    Address = new Address
                    {
                        StreetId = req.Adress.StreetId,
                        DivisionId = req.Adress.DivisionId,
                        BuldingNumber = req.Adress.BuildingNumber,
                        ApartmentNumber = req.Adress.ApartmentNumber,
                    }
                });

                await _context.SaveChangesAsync();
                return new Response
                {
                    IsSuccess = true,
                    Message = "Sucess",
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }

        }

        public async Task<DTOs.Response> PersonUpdateProfileAsync(Guid id, DTOs.PersonCreateProfile.PersonDtoRequest req)
        {
            try
            {
                var pesel = new Pesel(req.Pesel);

                var person = _context.People.Where
                    (x =>
                    x.Pesel == req.Pesel || x.PhoneNumber == req.PhoneNumber || x.Email == req.Email)
                    .FirstOrDefault();

                if (person != null && person.Id != id)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Input uncorrect data"
                    };
                }

                if (person == null)
                {
                    person = await _context.People.FindAsync(id);
                }
                if (person == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Input uncorrect Id"
                    };
                }

                var colocation = await _context.CollocationsDivisionsAndStreets
                   .Where(x =>
                   x.DivisionId == req.Adress.DivisionId &&
                   x.StreetId == req.Adress.StreetId
                   ).FirstOrDefaultAsync();

                if (colocation == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Address Data uncorrect"
                    };
                }

                var doamin = new Domain.Entites.PersonPart.Person
                    (
                    req.FirstName,
                    req.HandName,
                    req.LastName,
                    req.BirthDate,
                    req.Email,
                    req.PhoneNumber,
                    req.Pesel,
                    req.IsPep,
                    req.LastPositionPep
                    );


                person.FirstName = req.FirstName;
                person.HandName = req.HandName;
                person.LastName = req.LastName;
                person.BirthDate = req.BirthDate;
                person.Email = req.Email;
                person.PhoneNumber = req.PhoneNumber;
                person.Pesel = req.Pesel;
                person.LastPositionPep = (!req.IsPep) ? (string)(null) : req.LastPositionPep;
                person.Address = new Address
                {
                    StreetId = req.Adress.StreetId,
                    DivisionId = req.Adress.DivisionId,
                    BuldingNumber = req.Adress.BuildingNumber,
                    ApartmentNumber = req.Adress.ApartmentNumber,
                };

                await _context.SaveChangesAsync();
                return new Response
                {
                    IsSuccess = true,
                    Message = "Sucess",
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }

        }

        public async Task<DTOs.Response> DeleteProfileAsync(Guid id)
        {
            var preson = await _context.People.Where(x => x.Id == id).ToListAsync();
            if (preson == null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Not Exist person"
                };
            }

            var eduHistory = await _context.EducationHistories.Where(x => x.Id == id).ToListAsync();
            _context.EducationHistories.RemoveRange(eduHistory);

            var empHistory = await _context.EmploymentHistories.Where(x => x.Id == id).ToListAsync();
            _context.EmploymentHistories.RemoveRange(empHistory);

            var emp = await _context.Employees.Where(x => x.Id == id)
                .Include(x => x.ManagerDepratments)
                .Include(x => x.EmployeeDepratments)
                .ToListAsync();
            foreach (var employee in emp)
            {
                employee.ManagerDepratments.Clear();
                employee.EmployeeDepratments.Clear();
            }
            _context.Employees.RemoveRange(emp);

            var dok = await _context.Documents.Where(x => x.Id == id).ToListAsync();
            _context.Documents.RemoveRange(dok);

            _context.People.RemoveRange(preson);

            await _context.SaveChangesAsync();
            return new Response
            {
                IsSuccess = true,
                Message = "Sucess"
            };
        }

        //DocumentPart Ok
        //======================================================================================================
        public async Task<DTOs.Response> SetDocumentAsync(Guid personId, DTOs.DocumentPart.DocumentDtoRequest req)
        {
            var person = await _context.People.FindAsync(personId);
            if (person == null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Uncoreect Id Person",
                };
            }

            var doaminPerson = new Domain.Entites.PersonPart.Person
                    (
                    person.FirstName,
                    person.HandName,
                    person.LastName,
                    person.BirthDate,
                    person.Email,
                    person.PhoneNumber,
                    person.Pesel,
                    (string.IsNullOrWhiteSpace(person.LastPositionPep)),
                    person.LastPositionPep
                    );

            var domainDocument = new Domain.Entites.DocumentPart.Document
                (
                req.Number,
                req.Country,
                req.From,
                req.To,
                Domain.Entites.DocumentPart.DocumentType.Paszport,
                doaminPerson
                );

            if (!domainDocument.IsValid())
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Document Data invalid",
                };
            }

            await _context.Documents.AddAsync(new Application.Database.Models.DocumentPart.Document
            {
                Number = req.Number,
                Country = req.Country,
                From = req.From,
                To = req.To,
                DocumentTypeId = req.DocumentTypeId,
                PersonId = personId,
            });
            await _context.SaveChangesAsync();

            return new Response
            {
                IsSuccess = true,
                Message = "Sucess",
            };
        }

        public async Task<DTOs.Response> UpdateDocumentAsync(Guid documentId, DTOs.DocumentPart.DocumentDtoRequest req)
        {
            var document = await _context.Documents.FindAsync(documentId);
            if (document == null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Uncoreect Id Document",
                };
            }

            var person = await _context.People.FindAsync(document.PersonId);
            if (person == null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Uncoreect Id Person",
                };
            }

            var doaminPerson = new Domain.Entites.PersonPart.Person
                    (
                    person.FirstName,
                    person.HandName,
                    person.LastName,
                    person.BirthDate,
                    person.Email,
                    person.PhoneNumber,
                    person.Pesel,
                    (string.IsNullOrWhiteSpace(person.LastPositionPep)),
                    person.LastPositionPep
                    );

            var domainDocument = new Domain.Entites.DocumentPart.Document
                (
                req.Number,
                req.Country,
                req.From,
                req.To,
                Domain.Entites.DocumentPart.DocumentType.Paszport,
                doaminPerson
                );

            if (!domainDocument.IsValid())
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Document Data invalid",
                };
            }

            document.Number = req.Number;
            document.Country = req.Country;
            document.From = req.From;
            document.To = req.To;
            document.DocumentTypeId = req.DocumentTypeId;

            await _context.SaveChangesAsync();

            return new Response
            {
                IsSuccess = true,
                Message = "Sucess",
            };
        }

        public async Task<List<DocumentTypeDtoResponse>> GetDocumentTypesAsync()
        {
            return await _context.DocumentTypes.Select(x => new DocumentTypeDtoResponse
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
        }

        //Adress Part Ok
        //======================================================================================================
        public async Task<List<DTOs.AdressPart.AdministrativeDivisionDto>> GetDivisionsAsync(string nazwa)
        {
            return await _context.Divisions.Include(x => x.Collocations)
                .Include(x => x.Type)
                .Where(x => x.Name == nazwa).Select(x => new DTOs.AdressPart.AdministrativeDivisionDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ParentId = x.ParentId,
                    SourceId = x.SourceId,
                    Type = x.Type.Name,
                    Depth = x.Type.Depth,
                })
                .ToListAsync();

        }

        public async Task<List<DTOs.AdressPart.AdministrativeDivisionDto>> GetDivisionsUpByDivisionAsync(int id)
        {
            var list = new List<DTOs.AdressPart.AdministrativeDivisionDto>();
            var div = await _context.Divisions.Where(x => x.Id == id)
                .Include(x => x.Type).FirstOrDefaultAsync();

            while (div != null)
            {
                list.Add(ParseAdministrativeDivisionToDto(div));
                div = await _context.Divisions.Where(x => x.Id == div.ParentId)
                .Include(x => x.Type).FirstOrDefaultAsync();
            }
            return list;
        }

        public async Task<IList<DTOs.AdressPart.StreetDto>> GetStreetsByDivisionIdAsync(long divisionId)
        {
            var list = await _context.CollocationsDivisionsAndStreets
                .Where(x => x.DivisionId == divisionId).Include(x => x.Street)
                .ThenInclude(x => x.Type).Select(x => new DTOs.AdressPart.StreetDto
                {
                    Id = x.StreetId,
                    Name1 = x.Street.Name1,
                    Name2 = x.Street.Name2,
                    IdSource = x.Street.IdSource,
                    Type = x.Street.Type.Name,
                }).ToListAsync();
            return list;
        }


        //ClientPart
        //====================================================================================================
        public async Task<Response> ClientCreateProfileAsync(Guid id)
        {
            var person = await _context.People.FindAsync(id);
            if (person == null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Person with this Id not exist",
                };
            }
            string account = Guid.NewGuid().ToString();
            var client = await _context.Clients
                .Where(x => x.AccountNumber == account).FirstOrDefaultAsync();
            while (client != null)
            {
                account = Guid.NewGuid().ToString();
                client = await _context.Clients
                    .Where(x => x.AccountNumber == account).FirstOrDefaultAsync();
            }

            await _context.Clients.AddAsync(new Database.Models.PersonPart.Client
            {
                Id = id,
                AccountNumber = account,
            });
            await _context.SaveChangesAsync();

            return new Response
            {
                IsSuccess = true,
                Message = "Sucess",
            };
        }

        //Emploee
        //====================================================================================================
        public async Task<SingleObjectResponse<EmploeeDtoResponse>> GetEmploeeDataAsync(Guid id)
        {
            var emploee = await _context.Employees.Where(x => x.Id == id)
                .Include(x => x.ManagerDepratments)
                .Include(x => x.EmployeeDepratments)
                .Include(x => x.EmploymentHistories).ThenInclude(x => x.Company)
                .Include(x => x.EducationHistories).ThenInclude(x => x.University)
                .ThenInclude(x => x.Company)
                .Select(x => new DTOs.EmploeePart.MethodGet.EmploeeDtoResponse
                {
                    Id = x.Id,
                    Position = x.Position,
                    Competences = x.Competences
                                        .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries) // Przekształć w tablicę znaków
                                        .ToList(),
                    AsEmploeeInDepartments = x.EmployeeDepratments.Select(y =>
                    new DTOs.EmploeePart.MethodGet.DepratmentDtoResponse
                    {
                        Id = y.Id,
                        Name = y.Name,
                        Email = y.Email,
                    }).ToList(),
                    AsManagerInDepartments = x.ManagerDepratments.Select(y =>
                    new DTOs.EmploeePart.MethodGet.DepratmentDtoResponse
                    {
                        Id = y.Id,
                        Name = y.Name,
                        Email = y.Email,
                    }).ToList(),
                    Clients = x.Clients.Select(y => new DTOs.EmploeePart.MethodGet.EmploeeClientDtoResponse
                    {
                        Id = y.Id,
                        AccountNumber = y.AccountNumber,
                    }).ToList(),
                    EducationHistory = x.EducationHistories.Select(y =>
                    new DTOs.EmploeePart.MethodGet.EducationHistoryDtoResponse
                    {
                        Id = y.Id,
                        From = y.From,
                        To = y.To,
                        Degree = y.Degree,
                        Corse = y.Corse,
                        Fild = y.Fild,
                        University = new DTOs.EmploeePart.MethodGet.UniversityDtoResponse
                        {
                            Id = y.University.Id,
                            UniversityType = y.University.UniversityType,
                            Name = y.University.Company.Name,
                            Nip = y.University.Company.Nip,
                            Regon = y.University.Company.Regon,
                            Status = y.University.Company.Status,
                            IsOurClient = y.University.Company.IsOurClient,
                            Email = y.University.Company.Email,
                        },
                    }).ToList(),
                    EmploymentHistory = x.EmploymentHistories.Select(y =>
                    new DTOs.EmploeePart.MethodGet.EmploymentHistoryDtoResponse
                    {
                        Id = y.Id,
                        From = y.From,
                        To = y.To,
                        Company = new DTOs.EmploeePart.MethodGet.UniversityDtoResponse
                        {
                            Id = y.Company.Id,
                            Name = y.Company.Name,
                            Nip = y.Company.Nip,
                            Regon = y.Company.Regon,
                            Status = y.Company.Status,
                            IsOurClient = y.Company.IsOurClient,
                            Email = y.Company.Email,
                        },
                    }).ToList(),
                }).FirstOrDefaultAsync();
            if (emploee == null)
            {
                return new SingleObjectResponse<EmploeeDtoResponse>
                {
                    IsSuccess = false,
                    Message = "by this id not exist emploee"
                };
            }
            return new SingleObjectResponse<EmploeeDtoResponse>
            {
                IsSuccess = true,
                Message = "sucess",
                Value = emploee
            };
        }

        public async Task<DTOs.Response> CreateEmploeeAsync(Guid emploeeIdWhichInserted, EmploeeDtoRequest req)
        {
            var prime = await _context.Employees.FindAsync(emploeeIdWhichInserted);

            if (prime == null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Emploee Which Inserted not exist",
                };
            }
            var person = await _context.People.FindAsync(req.Id);

            if (person == null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Person which profile as emploee not exist not exist",
                };
            }

            await _context.Employees.AddAsync(new Database.Models.PersonPart.Employee
            {
                Id = req.Id,
                Position = req.Position,
                Competences = string.Join(";", req.Competences),
            });
            await _context.SaveChangesAsync();
            return new Response
            {
                IsSuccess = true,
                Message = "Sucess",
            };
        }

        public async Task<Response> EmploeeToDepartmentAsync(Guid emploeeId, Guid departmentId)
        {
            var dep = await _context.Depratments.FindAsync(departmentId);
            if (dep == null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Department by this Id not exist"
                };
            }
            var emp = await _context.Employees.FindAsync(emploeeId);
            if (emp == null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Employee by this Id not exist"
                };
            }

            emp.EmployeeDepratments.Add(dep);
            await _context.SaveChangesAsync();
            return new Response
            {
                IsSuccess = true,
                Message = "Sucess",
            };
        }

        public async Task<DTOs.Response> SetEducationHistoryAsync(EducationHistoryDtoRequest req)
        {
            var emploee = await _context.Employees.FindAsync(req.EmploeeId);
            if (emploee == null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "in system not exist emploee with this id"
                };
            }

            var universiy = await _context.Universities.Include(x => x.Company)
                .Where(x => x.Company.Regon == req.Regon).FirstOrDefaultAsync();
            if (universiy == null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "in system not exist universities with this Regon"
                };
            }

            await _context.EducationHistories.AddAsync(new Database.Models.UniversityPart.EducationHistory
            {
                From = req.From,
                To = req.To,
                Fild = req.Fild,
                Degree = req.Degree,
                Corse = req.Corse,
                EmployeeId = req.EmploeeId,
                UniversityId = universiy.Id,
            });
            await _context.SaveChangesAsync();

            return new Response
            {
                IsSuccess = true,
                Message = "Sucess"
            };
        }

        public async Task<DTOs.Response> SetEmploymentHistoryAsync(EmploymentHistoryDtoRequest req)
        {
            var person = await _context.People.FindAsync(req.EmploeeId);
            var emploee = await _context.Employees.FindAsync(req.EmploeeId);
            if (emploee == null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "in system not exist emploee with this id"
                };
            }

            var company = await _context.Companies.Where(x => x.Regon == req.Regon)
                .FirstOrDefaultAsync();
            if (company == null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "in system not exist Companies with this Regon"
                };
            }
            //Domain logic
            var domainCompany = new Domain.Entites.CompanyPart.Company
            {
                Id = company.Id,
                Name = company.Name,
                Nip = company.Nip,
                Regon = company.Regon,
                Status = company.Status,
            };

            var doaminPerson = new Domain.Entites.PersonPart.Person
                    (
                    person.FirstName,
                    person.HandName,
                    person.LastName,
                    person.BirthDate,
                    person.Email,
                    person.PhoneNumber,
                    person.Pesel,
                    (string.IsNullOrWhiteSpace(person.LastPositionPep)),
                    person.LastPositionPep
                    );

            var domainEmploee = new Domain.Entites.PersonPart.Employee
                (
                    doaminPerson,
                    emploee.Position,
                    emploee.Competences.Split(";").ToList()
                );

            var doaminEmploymentHistory = new Domain.Entites.CompanyPart.EmploymentHistory
                (
                req.From,
                req.To,
                req.Position,
                domainEmploee,
                domainCompany
                );
            var collision = doaminEmploymentHistory.IsColision();

            if (collision)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Collision with other companies"
                };
            }

            await _context.EmploymentHistories.AddAsync(new Database.Models.CompanyPart.EmploymentHistory
            {
                From = req.From,
                To = req.To,
                Position = req.Position,
                EmployeeId = req.EmploeeId,
                CompanyId = company.Id,
            });
            await _context.SaveChangesAsync();

            return new Response
            {
                IsSuccess = true,
                Message = "Sucess"
            };
        }

        public async Task<DTOs.Response> CreateDepartment(DepartmentDtoRequest req)
        {
            var coloc = await _context.CollocationsDivisionsAndStreets
                .Where(x =>
                x.StreetId == req.Adress.StreetId &&
                x.DivisionId == req.Adress.DivisionId
                ).FirstOrDefaultAsync();
            if (coloc == null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Not exist this colocaton of street and division"
                };
            }

            await _context.Depratments.AddAsync(new Database.Models.Depratment
            {
                Name = req.Name,
                Email = req.Email,
                Address = new Address
                {
                    DivisionId = req.Adress.DivisionId,
                    StreetId = req.Adress.StreetId,
                    BuldingNumber = req.Adress.BuildingNumber,
                    ApartmentNumber = req.Adress.ApartmentNumber,
                },
            });

            await _context.SaveChangesAsync();
            return new Response
            {
                IsSuccess = true,
                Message = "Sucess"
            };
        }

        //====================================================================================================

        public async Task<List<EmploeeSimpleDataDtoResponse>> GetSimpleDataEmploeesAsync()
        {
            var list = await _context.Employees.Include(x => x.Person).Select(x =>
            new EmploeeSimpleDataDtoResponse
            {
                Id = x.Id,
                Position = x.Position,
                Competences = x.Competences
                                        .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries) // Przekształć w tablicę znaków
                                        .ToList(),
                FirstName = x.Person.FirstName,
                HandName = x.Person.HandName,
                LastName = x.Person.LastName,
                Email = x.Person.Email,
                PhoneNumber = x.Person.PhoneNumber,
            }).ToListAsync();
            return list;
        }

        public async Task<List<PersonDtoResponse>> GetSimpleDataPeopleAsync()
        {
            var list = await _context.People.Select(x => new PersonDtoResponse
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                BirthDate = x.BirthDate,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Pesel = x.Pesel,
                IsPep = (string.IsNullOrWhiteSpace(x.LastPositionPep)),
                LastPositionPep = x.LastPositionPep,

            }).ToListAsync();
            return list;
        }

        //====================================================================================================

        private DTOs.AdressPart.AdministrativeDivisionDto ParseAdministrativeDivisionToDto(AdministrativeDivision x)
        {
            return new DTOs.AdressPart.AdministrativeDivisionDto
            {
                Id = x.Id,
                Name = x.Name,
                ParentId = x.ParentId,
                SourceId = x.SourceId,
                Type = x.Type.Name,
                Depth = x.Type.Depth,
            };
        }
    }
}
