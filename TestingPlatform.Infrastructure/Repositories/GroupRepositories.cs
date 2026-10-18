using TestingPlatform.Application.Interfaces;
using TestingPlatform.Domain.Models;
using TestingPlatform.Infrastructure.Data;

namespace TestingPlatform.Infrastructure.Repositories;

public class GroupRepository(AppDbContext appDbContext) : IGroupRepository
{
    public List<Group> GetAll()
    {
        var groups = appDbContext.Groups.ToList();

        return groups;
    }

    public Group GetById(int id)
    {
        var group = appDbContext.Groups.FirstOrDefault(g => g.Id == id);
        if (group is null)
            throw new Exception("Группа не найдена.");

        return group;
    }

    public int Create(Group group)
    {
        var direction = appDbContext.Directions.Any(d => d.Id == group.DirectionId);
        var course = appDbContext.Courses.Any(c => c.Id == group.CourseId);
        var project = appDbContext.Projects.Any(p => p.Id == group.ProjectId);

        if (!direction || !course || !project)
            throw new Exception("Убедитесь, что DirectionId, CourseId и ProjectId существуют");

        if (group.Students.Any())
        {
            var ids = group.Students.Select(s => s.Id).ToList();
            var students = appDbContext.Students.Where(s => ids.Contains(s.Id)).ToList();
            if (students.Count != ids.Count)
                throw new Exception("Некоторые студенты не найдены");

            group.Students = students;
        }

        var groupId = appDbContext.Add(group);
        appDbContext.SaveChanges();

        return groupId.Entity.Id;
    }

    public void Update(Group group)
    {
        var exists = appDbContext.Groups.FirstOrDefault(g => g.Id == group.Id);
        if (exists is null)
            throw new Exception("Группа не найдена");

        var directionOk = appDbContext.Directions.Any(d => d.Id == group.DirectionId);
        var courseOk = appDbContext.Courses.Any(c => c.Id == group.CourseId);
        var projectOk = appDbContext.Projects.Any(p => p.Id == group.ProjectId);

        if (!directionOk || !courseOk || !projectOk)
            throw new Exception("Убедитесь, что DirectionId, CourseId и ProjectId существуют");

        if (group.Students.Any())
        {
            var ids = group.Students.Select(s => s.Id).ToList();
            var students = appDbContext.Students.Where(s => ids.Contains(s.Id)).ToList();
            if (students.Count != ids.Count)
                throw new Exception("Некоторые студенты не найдены");

            exists.Students = group.Students;
        }

        exists.Name = group.Name;
        exists.DirectionId = group.DirectionId;
        exists.CourseId = group.CourseId;
        exists.ProjectId = group.ProjectId;

        appDbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var group = appDbContext.Groups.FirstOrDefault(group => group.Id == id);

        if (group == null)
        {
            throw new Exception("Группа не найдена.");
        }

        appDbContext.Groups.Remove(group);
        appDbContext.SaveChanges();
    }
}

