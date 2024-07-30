
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using SimpleApp03__System.Data.SqlClient_.Models;
using SimpleApp03__System.Data.SqlClient_.Models.DTOs;
using System.Data.Common;
using System.Reflection.PortableExecutable;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimpleApp03__System.Data.SqlClient_.Entities
{
    public class PrescriptionsRepository : IPrescriptionsRepository
    {
        private readonly string _connectionString;

        public PrescriptionsRepository(IConfiguration conf) 
        {
            _connectionString = conf.GetConnectionString("DBString");
        }
        /*Part Get*/
        public async Task<IEnumerable<PrescriptionDTO>> GetPrescriptionsAsync(string? PatientName = null) {
            var prescriptions = new List<PrescriptionDTO>();
            await using (SqlConnection con = new SqlConnection(_connectionString)) 
            { 
                using SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                /*CommandText Part Compose */
                string selectPrescriptionPersonalDetalis = "SELECT IdPrescription, Date, DueDate, " +
                    "Doctor.FirstName AS DoctorName , Doctor.LastName AS DoctorLastName, Email, " +
                    "Patient.FirstName AS PatientName, Patient.LastName AS PatientLastName, Birthdate " +
                    "FROM Prescription JOIN Doctor on Doctor.IdDoctor = Prescription.IdDoctor " + 
                    "JOIN Patient ON Patient.IdPatient = Prescription.IdPatient ";
                if ( !PatientName.IsNullOrEmpty() ) 
                {
                    // Warning at this part "AS PatientName" AND "PatientName" indetifise as the same
                    selectPrescriptionPersonalDetalis +=                   
                   "WHERE Patient.FirstName = @PatientName1 ORDER BY Date DESC";
                   cmd.Parameters.AddWithValue("@PatientName1", PatientName);
                }
                 else 
                {
                    selectPrescriptionPersonalDetalis += "ORDER BY  Date DESC";
                }

                /*CommandText Initiation*/
                cmd.CommandText = selectPrescriptionPersonalDetalis;
                if ( !PatientName.IsNullOrEmpty() ) { cmd.Parameters.AddWithValue("@PatientName", PatientName); }

                try 
                { 
                    await con.OpenAsync();
                    await using var reader = await cmd.ExecuteReaderAsync();
                    
                    while (await reader.ReadAsync()) 
                    {
                        prescriptions.Add( new PrescriptionDTO() {
                            IdPrescription = (int) reader["IdPrescription"],
                            Date = DateOnly.FromDateTime(DateTime.Parse(reader["Date"].ToString())),
                            DueDate = DateOnly.FromDateTime(DateTime.Parse(reader["DueDate"].ToString())),
                            DoctorName = reader["DoctorName"].ToString(),
                            DoctorLastName = reader["DoctorLastName"].ToString(),
                            DoctorEmail = reader["Email"].ToString(),
                            PatientName = reader["PatientName"].ToString(),
                            PatientLastName = reader["PatientLastName"].ToString(),
                            PatientBirthdate = DateOnly.FromDateTime(DateTime.Parse(reader["Birthdate"].ToString())),
                        });
                    }
                } 
                catch (SqlException ex) { PrintSqlExceptionsErrors(ex); }
            }

            foreach (var prescription in prescriptions) 
            { 
                var details = await GetPrescriptionsListByDetails(prescription.IdPrescription);
                prescription.Details = details;
            }
            return prescriptions;
        }

        private async Task<IEnumerable<PrescriptionDetailsDTO>> GetPrescriptionsListByDetails( int IdPrescription) 
        {
            var list = new List<PrescriptionDetailsDTO>();
            await using (SqlConnection con = new SqlConnection(_connectionString)) 
            {
                using SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT Dose, Details, Name, Description,Type " +
                    "FROM Prescription JOIN Prescription_Medicament ON Prescription.IdPrescription = Prescription_Medicament.IdPrescription " +
                    "JOIN Medicament ON Medicament.IdMedicament = Prescription_Medicament.IdMedicament " +
                    "WHERE Prescription.IdPrescription = @IdPrescription1";
                cmd.Parameters.AddWithValue("@IdPrescription1", IdPrescription);

                try 
                { 
                    await con.OpenAsync();
                    await using var reader = await cmd.ExecuteReaderAsync();

                    while ( await reader.ReadAsync() ) 
                    {
                        list.Add( new PrescriptionDetailsDTO() 
                        { 
                             Dose = (int) reader["Dose"],
                             Details = reader["Details"].ToString(),
                             Name = reader["Name"].ToString(),
                             Description = reader["Description"].ToString(),
                             Type = reader["Type"].ToString(),
                        });
                    }
                }
                catch (SqlException ex) { PrintSqlExceptionsErrors (ex); }
            }
            return list;
        }
        /*
         * Part Post 
         * Make by one Transaction*/
        public async Task<Request> AddMedicineToPrescriptionTransactionAsync(int IdPrescription, List<PostMedicinePrescription> pm) 
        {
            if (pm.Count <1)
            {
                return new Request()
                {
                    Code = 400,
                    ReturnInformation = true,
                    Information = $"List empty",
                };
            }
            int result = -1;
            await using (SqlConnection con = new SqlConnection(_connectionString)) 
            {
                /* 
                 * 1 Is exist Prescription, if not rollback
                 * 2 Are exists all Medicines, if not rollback
                 * 3 Are exists That medicine in prescription
                 * 4 Add another Medicine to prescription
                 * */

                using SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Prescription WHERE IdPrescription = @IdPrescription";
                cmd.Parameters.AddWithValue("@IdPrescription", IdPrescription);

                await con.OpenAsync();
                DbTransaction tran = await con.BeginTransactionAsync();
                cmd.Transaction = (SqlTransaction)tran;

                try
                {
                    using ( var reader = await cmd.ExecuteReaderAsync()) 
                    {
                        while (await reader.ReadAsync()) 
                        {
                            result = 1;
                        }     
                    }

                    if (result < 1) 
                    {
                        await tran.RollbackAsync();
                        return new Request()
                        {
                            Code = 400,
                            ReturnInformation = true,
                            Information = $"Has no exist prescription by this id: {IdPrescription}",
                        };
                    }

                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT IdMedicament FROM Medicament WHERE NAME = @NAME";
                    var list = new List<PostMedicinePrescriptionWithId>();

                    foreach (var x in pm) 
                    {
                        cmd.Parameters.AddWithValue("@NAME", x.Name);
                        using ( var reader = await cmd.ExecuteReaderAsync() ) 
                        {
                            while (await reader.ReadAsync()) 
                            {
                                list.Add( new PostMedicinePrescriptionWithId() 
                                {  
                                    IdMedicament = (int)reader["IdMedicament"],
                                    Name = x.Name,
                                    Details = x.Details,
                                    Dose = x.Dose,
                                });
                            }
                        }
                        cmd.Parameters.Clear();
                    }

                    if (pm.Count != list.Count) 
                    {
                        var pmNames = new List<string>();
                        foreach ( var x in pm) { pmNames.Add(x.Name);}
                        foreach (var x in list) { pmNames.Remove(x.Name); }
                        string names = string.Join(", ", pmNames);
                        await tran.RollbackAsync();
                        return new Request()
                        {
                            Code = 400,
                            ReturnInformation = true,
                            Information = $"Part of medicines no exist: {names}",
                        };
                    }
                    cmd.CommandText = "SELECT * FROM Prescription_Medicament WHERE  IdPrescription = @IdPrescription AND IdMedicament = @IdMedicament";


                    var listForDelete = new List<PostMedicinePrescriptionWithId>();  
                    foreach (var x in list) 
                    {
                        cmd.Parameters.AddWithValue("@IdPrescription", IdPrescription);
                        cmd.Parameters.AddWithValue("@IdMedicament", x.IdMedicament);
                        using (var reader = await cmd.ExecuteReaderAsync() ) 
                        { 
                            while ( await reader.ReadAsync() ) 
                            {
                                listForDelete.Add(x);
                                /*
                                 *list.Remove(x); 
                                 * Unsave -> Exeptions
                                 */
                            }
                        }
                        cmd.Parameters.Clear();
                    }
                    foreach (var x in listForDelete) { list.Remove(x); }

                    if (list.Count ==0) 
                    { 
                        await tran.RollbackAsync();
                        return new Request() 
                        { 
                            Code = 400,
                            ReturnInformation = true,
                            Information = "All that medicines are in this Prescription",
                        };
                    }

                    cmd.CommandText = "INSERT INTO Prescription_Medicament (IdMedicament, IdPrescription, DOSE, DETAILS) " +
                        "VALUES ( @IdMedicament, @IdPrescription, @Dose, @Details)";

                    foreach ( var x in list) 
                    {
                        cmd.Parameters.AddWithValue("@IdMedicament", x.IdMedicament);
                        cmd.Parameters.AddWithValue("@IdPrescription", IdPrescription);
                        cmd.Parameters.AddWithValue("@Dose", x.Dose);
                        cmd.Parameters.AddWithValue("@Details", x.Details);

                        result += await cmd.ExecuteNonQueryAsync();

                        cmd.Parameters.Clear();

                    }                   
                    Console.WriteLine($"Inserted {result} - {list.Count} List Count");
                    await tran.CommitAsync();
                }
                catch (SqlException ex)
                {
                    await tran.RollbackAsync();
                    PrintSqlExceptionsErrors(ex);
                    return new Request()
                    {
                        Code = 500,
                        ReturnInformation = false,
                    };
                }
                catch (Exception ex) 
                { 
                    await tran.RollbackAsync();
                    Console.WriteLine (ex.ToString ());
                    return new Request()
                    {
                        Code = 500,
                        ReturnInformation = false,
                    };
                }
            }
            return new Request() 
            { 
                Code = 200,
                ReturnInformation = false,
            };
        }


        /*Exception*/
        protected static void PrintSqlExceptionsErrors(SqlException ex)
        {
            /* https://learn.microsoft.com/pl-pl/dotnet/api/system.data.sqlclient.sqlexception?view=dotnet-plat-ext-8.0
                    */
            StringBuilder errorMessages = new StringBuilder();
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                errorMessages.Append("Index #" + i + "\n" +
                    "Message: " + ex.Errors[i].Message + "\n" +
                    "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                    "Source: " + ex.Errors[i].Source + "\n" +
                    "Procedure: " + ex.Errors[i].Procedure + "\n");
            }
            Console.WriteLine(errorMessages.ToString());
        }
    }
}