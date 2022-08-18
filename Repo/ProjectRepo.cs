using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PMS_Net.Data;
using PMS_Net.Models;

namespace PMS_Net.Repo
{
    public class ProjectRepo :IProjectRepo
    {
        private Connection _connection;
        private readonly AppDbContext _context;

        public ProjectRepo(Connection con, AppDbContext context)
        {
            //Read local JSON file and initiate project list
            _connection = con;
            _context = context;

        }
        public List<Project> getAll()
        {
            List<Project> projectList = new List<Project>();
            MySqlCommand cmd = GetMySqlCommand("SELECT * FROM project");
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                projectList.Add(new Project { Id = Convert.ToInt16(reader["id"]), Name = reader["name"].ToString() });
            }

            reader.Close();
            return projectList;
        }

        public int create(Project project)
        {
            /* _projectList.Add(project);*/

            MySqlCommand cmd1 = GetMySqlCommand("INSERT INTO project (name) VALUES(@name)");
            cmd1.Parameters.AddWithValue("@name", project.Name);
            cmd1.Prepare();
            cmd1.ExecuteNonQuery();

            MySqlCommand cmd2 = new MySqlCommand("SELECT LAST_INSERT_ID()", _connection.con);
            var result = cmd2.ExecuteScalar();
            int id = Convert.ToInt16(result);

            return id;
        }

        public bool delete(int id)
        {
            MySqlCommand cmd = GetMySqlCommand("DELETE FROM project WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            if (cmd.ExecuteNonQuery() == 1)
                return true;

            return false;
        }

        public bool update(int id, Project project)
        {
            MySqlCommand cmd = GetMySqlCommand("UPDATE project SET name = @name WHERE id = @id ");
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("name", project.Name);
            cmd.Prepare();
            if (cmd.ExecuteNonQuery() == 1)
                return true;
            return false;
        }

        private MySqlCommand GetMySqlCommand(string sql)
        {
            return new MySqlCommand(sql, _connection.con);
        }
    }
}
