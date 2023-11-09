using PPM.Model;

namespace PPM.Domain
{
    public class ProjectRepo : IProjectRepo
    {

        public void AddProject(Project project)
        {
            using (var context = new DbContextFile())
            {
                context.Projects.Add(project);
                context.SaveChanges();
            }
        }

        public List<Project> ListAllProjectsWithoutEmployeeDetails()
        {
            using (var context = new DbContextFile())
            {
                return context.Projects.ToList();
            }
        }

        public void DeleteProject(int projectId)
        {
            using (var context = new DbContextFile())
            {
                var projectValid = context.Projects.FirstOrDefault(e => e.ProjectId == projectId)!;
                context.Projects.Remove(projectValid);
                context.SaveChanges();
            }
        }

        public void AddEmployeeToExistingProject(int projectId, int employeeId)
        {
            using (var context = new DbContextFile())
            {
                var employeeDetails = context.Employees.Find(employeeId)!;
                employeeDetails.ProjectId = projectId;
                context.SaveChanges();
            }
        }

        public void DeleteEmployeeFromProject(int projectId, int employeeId)
        {
            using (var context = new DbContextFile())
            {
                var employeeDetails = context.Employees.Find(employeeId)!;
                employeeDetails.ProjectId = 0;
                context.SaveChanges();
            }
        }

        public Project ViewProjectDetail(int projectId)
        {
            using (var context = new DbContextFile())
            {
                var projectDetails = context.Projects.Find(projectId)!;
                if(projectDetails != null)
                {
                    projectDetails.ProjectEmployees = context.Employees.Where(e => e.ProjectId == projectId).ToList();
                }
                return projectDetails!;
            }
            
            // Project project = new();
            // using (SqlConnection connection = new SqlConnection(connectionString.Connection()))
            // {
            //     connection.Open();

            //     // Retrieve project details
            //     string selectSql = "SELECT ProjectName, ProjectStartDate, ProjectEndDate FROM Projects WHERE ProjectId = @ProjectId";

            //     using (SqlCommand command = new SqlCommand(selectSql, connection))
            //     {
            //         command.Parameters.AddWithValue("@ProjectId", projectId);

            //         using (SqlDataReader reader = command.ExecuteReader())
            //         {
            //             if(reader.Read())
            //             {
            //             project.ProjectName = (string)reader["ProjectName"];
            //             project.ProjectStartDate = (DateTime)reader["ProjectStartDate"];
            //             project.ProjectEndDate = (DateTime)reader["ProjectEndDate"];

            //             project.ProjectEmployees = GetEmployeesInProject(projectId);
            //             }
            //         }
            //     }
            // }
            // return project;
        }

        public List<int> GetEmployeesInProject(int projectId)
        {
            List<int> employeeIds = new();
            // using (SqlConnection connection = new SqlConnection(connectionString.Connection()))
            // {
            //     connection.Open();
            //     string selectSql = "SELECT EmployeeId FROM ProjectEmployees WHERE ProjectId = @ProjectId";
            //     using (SqlCommand command = new SqlCommand(selectSql, connection))
            //     {
            //         command.Parameters.AddWithValue("@ProjectId", projectId);
            //         using (SqlDataReader reader = command.ExecuteReader())
            //         {
            //             while (reader.Read())
            //             {
            //                 employeeIds.Add(reader.GetInt32(0));
            //             }
            //         }
            //     }
            // }
            return employeeIds;
        }
    }
}
