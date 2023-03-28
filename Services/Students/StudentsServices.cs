using LearnAdoDotnet.Models;
using Microsoft.Data.SqlClient;

public class StudentsService
{
    private readonly DataAccessService _dataAccessService;

    public StudentsService(DataAccessService dataAccessService)
    {
        _dataAccessService = dataAccessService;
    }

    // TODO: Separate query strings into different class
    public void AddStudent(Student student)
    {
        var query = "INSERT INTO Students (Name, Email) VALUES (@Name, @Email)";
        var parameters = new SqlParameter[]
        {
            new SqlParameter("@Name", student.Name),
            new SqlParameter("@Email", student.Email)
        };

        _dataAccessService.ExecuteNonQuery(query, parameters);
    }

    public Student? GetStudent(int id)
    {
        var query = "SELECT * FROM Students WHERE Id = @Id ";
        SqlParameter[] parameters = new SqlParameter[]
        {
            new SqlParameter("@Id", id)
        };

        var dataReader = _dataAccessService.ExecuteReader(query, parameters);
        if (dataReader.Read())
        {
            Student student = new Student();
            // Use this
            // student.Id = dataReader.GetInt32(0);
            // student.Name = dataReader.GetString(1);
            // student.Email = dataReader.GetString(2);
            // Or this
            student.Id = (int) dataReader["Id"];
            student.Name = (string) dataReader["Name"];
            student.Email = (string) dataReader["Email"];
            return student;
        }

        return null;
    }

    public List<Student> GetStudents(int pageNumber = 1, int pageSize = 10)
    {
        var offset = (pageNumber - 1) * pageSize;
        if (offset < 0 || pageSize <= 0)
        {
            return new List<Student>();
        }

        var query = "SELECT * FROM Students ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
        var parameters = new SqlParameter[]
        {
            new SqlParameter("@Offset", offset),
            new SqlParameter("@PageSize", pageSize)
        };

        var dataReader = _dataAccessService.ExecuteReader(query, parameters);
        var students = new List<Student>();

        while (dataReader.Read())
        {
            Student student = new Student();
            // Read data from the dataReader
            student.Id = dataReader.GetInt32(0);
            student.Name = dataReader.GetString(1);
            student.Email = dataReader.GetString(2);

            students.Add(student);
        }

        return students;
    }

    public object? StudentsCount()
    {
        var query = "SELECT COUNT(*) FROM Students";
        return _dataAccessService.ExecuteScalar(query); ;
    }

    public int DeleteStudent(int id)
    {
        var query = "DELETE FROM Students WHERE Id = @Id";
        var parameters = new SqlParameter[]
        {
            new SqlParameter("@Id", id)
        };

        return _dataAccessService.ExecuteNonQuery(query, parameters);
    }
}
