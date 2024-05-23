using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using SimpleApp04__System.Data.SqlClient_.Models;
using SimpleApp04__System.Data.SqlClient_.Models.DTOs;
using System.Data.Common;

namespace SimpleApp04__System.Data.SqlClient_.Entities
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly string? _connectionString;
        public TeamsRepository(IConfiguration conf) 
        {
            _connectionString = conf.GetConnectionString("DBString");
        }

        /* Do all in one Method */
        public async Task<Request<List<ChampionshipDTO>>> GetChampionshipDetailsAsync(int? IdChampionship) 
        {
            var list = new List<ChampionshipDTO>();
            await using ( SqlConnection con = new SqlConnection(_connectionString)) 
            {
                using SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT IdChampionship, OfficialName, Year FROM Championship";
                if (IdChampionship != null && IdChampionship >=0 ) 
                {
                    cmd.CommandText = "SELECT IdChampionship, OfficialName, Year FROM Championship WHERE IdChampionship = @IdChampionship";
                    cmd.Parameters.AddWithValue("@IdChampionship", IdChampionship);
                }

                try
                {
                    await con.OpenAsync();
                    await using (var reader = await cmd.ExecuteReaderAsync()) { 
                        while (await reader.ReadAsync())
                        {
                            list.Add(new ChampionshipDTO()
                            {  
                                IdChampionship = (int)reader["IdChampionship"],
                                OfficialName = reader["OfficialName"].ToString(),
                                Year = (int)reader["Year"],
                            });
                        }
                    }

                    if (list.Count == 0) 
                    {
                        return new Request<List<ChampionshipDTO>>()
                        {
                            Code = 204,
                            IsExistValue = false,
                        };
                    }

                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT IdChampionshipTeam, Score,  Team.IdTeam, TeamName, MaxAge " +
                        "FROM  Championship JOIN Championship_Team ON Championship.IdChampionship = Championship_Team.IdChampionship " +
                        "JOIN Team ON Championship_Team.IdTeam = Team.IdTeam " +
                        "WHERE Championship.IdChampionship = @IdChampionship1";

                    foreach (var item in list) 
                    {
                        var teamsDtoList = new List<ChampionshipTeamDTO>();

                        cmd.Parameters.AddWithValue("@IdChampionship1", item.IdChampionship);
                        await using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                teamsDtoList.Add(new ChampionshipTeamDTO() 
                                {
                                    IdChampionshipTeam = (int)reader["IdChampionshipTeam"],
                                    Score = float.Parse( reader["Score"].ToString()),
                                    IdTeam = (int)reader["IdTeam"],
                                    TeamName = reader["TeamName"].ToString(),
                                    MaxAge = (int)reader["MaxAge"],
                                });
                            }
                        }
                        item.Teams = teamsDtoList;
                        cmd.Parameters.Clear();
                    }

                }
                catch (SqlException ex) 
                { 
                    Console.WriteLine(ex.ToString()); 
                    return new Request <List<ChampionshipDTO>> () 
                        { 
                            Code = 500,
                            IsExistValue = false,
                        };
                }
                catch (Exception ex) 
                { 
                    Console.WriteLine(ex.ToString());
                    return new Request<List<ChampionshipDTO>>()
                    {
                        Code = 500,
                        IsExistValue = false,
                    };
                }
            }
            return new Request<List<ChampionshipDTO>>()
            {
                Code = 200,
                IsExistValue = true,
                Value = list,
            };
        }

        public async Task<Request<List<TeamDTO>>> GetTeamsDetailsAsync(int? IdTeam)
        {
            var list = new List<TeamDTO>();
            await using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT IdTeam, TeamName, MaxAge FROM Team";
                if (IdTeam != null && IdTeam >= 0)
                {
                    cmd.CommandText = "SELECT IdTeam, TeamName, MaxAge FROM Team WHERE IdTeam = @IdTeam";
                    cmd.Parameters.AddWithValue("@IdTeam", IdTeam);
                }

                try
                {
                    await con.OpenAsync();
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            list.Add(new TeamDTO()
                            {
                                IdTeam = (int)reader["IdTeam"],
                                TeamName = (string)reader["TeamName"],
                                MaxAge = (int)reader["MaxAge"],
                            });
                        }
                    }

                    if (list.Count == 0)
                    {
                        return new Request<List<TeamDTO>>()
                        {
                            Code = 204,
                            IsExistValue = false,
                        };
                    }

                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT IdPlayerTeam, Player.IdPlayer, FirstName, LastName, DateOfBirth,  NumOnShirt, Comment " +
                        "FROM Team JOIN Player_Team ON Team.IdTeam = Player_Team.IdTeam " +
                        "JOIN Player ON Player_Team.IdPlayer = Player.IdPlayer " +
                        "Where Team.IdTeam = @IdTeam1";

                    foreach (var item in list)
                    {
                        var playersDtoList = new List<TeamPlayerDTO>();

                        cmd.Parameters.AddWithValue("@IdTeam1", item.IdTeam);
                        await using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                playersDtoList.Add(new TeamPlayerDTO()
                                {
                                    IdPlayerTeam = (int)reader["IdPlayerTeam"],
                                    IdPlayer = (int)reader["IdPlayer"],
                                    FirstName = (string)reader["FirstName"],
                                    LastName = (string)reader["LastName"],
                                    DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString()),
                                    NumOnShirt = (int)reader["NumOnShirt"],
                                    Comment = reader["Comment"].ToString().IsNullOrEmpty() ? null : reader["Comment"].ToString()
                                }); ;
                            }
                        }
                        item.Players = playersDtoList;
                        cmd.Parameters.Clear();
                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return new Request<List<TeamDTO>>()
                    {
                        Code = 500,
                        IsExistValue = false,
                    };
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return new Request<List<TeamDTO>>()
                    {
                        Code = 500,
                        IsExistValue = false,
                    };
                }
            }
            return new Request<List<TeamDTO>>()
            {
                Code = 200,
                IsExistValue = true,
                Value = list,
            };
        }

        /*Use Transaction */
        public async Task<Request<string>> PostPlayerTeamAsync(int IdTeam, int IdPlayer, Player_TeamDTO pt) 
        {

            await using (SqlConnection con = new SqlConnection(_connectionString)) 
            {
                using SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Team WHERE IdTeam = @IdTeam";
                cmd.Parameters.AddWithValue("@IdTeam", IdTeam);

                await con.OpenAsync();
                DbTransaction tran  = await con.BeginTransactionAsync();
                cmd.Transaction = (SqlTransaction) tran;

                try 
                {
                    bool isExistTeam = false;
                    bool isExistPlayer = false;
                    await using ( var reader = await cmd.ExecuteReaderAsync()) 
                    {
                        while ( await reader.ReadAsync() ) 
                        {
                            isExistTeam = true; 
                            break;
                        }
                    }
                    
                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT * FROM Player WHERE IdPlayer = @IdPlayer";
                    cmd.Parameters.AddWithValue("@IdPlayer", IdPlayer);
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            isExistPlayer = true;
                            break;
                        }
                    }
                    if (!isExistTeam || !isExistPlayer) 
                    {
                        await tran.RollbackAsync();
                        return new Request<string>()
                        {
                            Code = 400,
                            IsExistValue = true,
                            Value = $"No exist:{(!isExistPlayer ? $" Player  by IdPlayer = {IdPlayer}" : "")} {(!isExistTeam ? $" Team   by IdTeam = {IdTeam}" : "")}",
                        };
                    }

                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT  DATEDIFF(YEAR,  DateOfBirth , SYSDATETIME()) AS AGE, " +
                        "(SELECT MaxAge FROM Team WHERE IdTeam = @IdTeam ) AS MaxAge " +
                        "FROM Player WHERE IdPlayer = @IdPlayer";
                    cmd.Parameters.AddWithValue("@IdTeam", IdTeam);
                    cmd.Parameters.AddWithValue("@IdPlayer", IdPlayer);
                    int age = -1, maxAge = -1;
                    bool isQualifies = false; 
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            age = (int)reader["AGE"];
                            maxAge = (int)reader["MaxAge"];
                            isQualifies |= age <= maxAge;
                            break;
                        }
                    }
                    if (!isQualifies) 
                    {
                        await tran.RollbackAsync();
                        return new Request<string>()
                        {
                            Code = 400,
                            IsExistValue = true,
                            Value = $"Age of Payer by IdPlayer ({IdPlayer}) older than MaxAge in Team by IdTeam ({IdTeam})  : {age} > {maxAge}",
                        };
                    }
                    
                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT * FROM Player_Team WHERE IdTeam = @IdTeam AND IdPlayer = @IdPlayer";
                    cmd.Parameters.AddWithValue("@IdTeam", IdTeam);
                    cmd.Parameters.AddWithValue("@IdPlayer", IdPlayer);
                    bool existEntion = false;
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            existEntion = true;
                            break;
                        }
                    }
                    if (existEntion) 
                    {
                        await tran.RollbackAsync();
                        return new Request<string>()
                        {
                            Code = 400,
                            IsExistValue = true,
                            Value = $"This Connection Exist",
                        };
                    }

                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO Player_Team ( IdPlayer, IdTeam, NumOnShirt, Comment)  " +
                        "VALUES ( @IdPlayer, @IdTeam, @NumOnShirt, @Comment) ";
                    cmd.Parameters.AddWithValue("@IdTeam", IdTeam);
                    cmd.Parameters.AddWithValue("@IdPlayer", IdPlayer);
                    cmd.Parameters.AddWithValue("@NumOnShirt", pt.NumOnShirt);
                    cmd.Parameters.AddWithValue("@Comment", pt.Comment == null ? DBNull.Value : pt.Comment);

                    await cmd.ExecuteNonQueryAsync();

                    await tran.CommitAsync();
                } 
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                    await tran.RollbackAsync();
                    return new Request<string>()
                    {
                        Code = 500,
                        IsExistValue = false,
                    };                    
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.ToString());
                    await tran.RollbackAsync();
                    return new Request<string>()
                    {
                        Code = 500,
                        IsExistValue = false,
                    };
                }
            }
            return new Request<string>()
            {
                Code = 200,
                IsExistValue = true,
                Value = $"Has Add",
            };
        }
    }
}
